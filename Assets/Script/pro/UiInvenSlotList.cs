using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class UiInvenSlotList : MonoBehaviour
{
    public enum SortingOptions
    {
        CreationTimeAccending,
        CreationTimeDeccending,
        NaemAccending,
        NaemDeccending,
        CostAccending,
        CostDeccending,
    }
    public enum FilteringOptions
    {
        None,
        Weapon,
        Equip,
        Consumable,
    }

    public readonly System.Comparison<SaveItemData>[] comparisons =
    {
        (lhs, rhs) => lhs.creationTime.CompareTo(rhs.creationTime),
        (lhs, rhs) => rhs.creationTime.CompareTo(lhs.creationTime),
        (lhs, rhs) => lhs.itemData.StringName.CompareTo(rhs.itemData.StringName),
        (lhs, rhs) => rhs.itemData.StringName.CompareTo(lhs.itemData.StringName),
        (lhs, rhs) => lhs.itemData.Cost.CompareTo(rhs.itemData.Cost),
        (lhs, rhs) => rhs.itemData.Cost.CompareTo(lhs.itemData.Cost),
    };

    public readonly System.Func<SaveItemData, bool>[] filterings =
    {
        x=>true,
        x=>x.itemData.Type ==ItemTypes.Weapon,
        x=>x.itemData.Type ==ItemTypes.Equip,
        x=>x.itemData.Type ==ItemTypes.Consumable,
    };

    public UiInvenSlot prefab;
    public ScrollRect scollRect;

    private List<UiInvenSlot> slotlist = new List<UiInvenSlot>();

    public int maxCount = 30;
    

    private List<SaveItemData> saveitemlist = new List<SaveItemData>();

    private SortingOptions sorting = SortingOptions.NaemAccending;
    private FilteringOptions filtering = FilteringOptions.None;

    public SortingOptions Sorting
    {
        get=>sorting;
        set
        {
            sorting = value;            
            UpdateSlots(saveitemlist);
        }
    }
    public FilteringOptions Filtering
    {
        get => filtering;
        set
        {
            filtering = value;            
            UpdateSlots(saveitemlist);
        }
    }

    private int selectedSlotIndex = -1;

    public UnityEvent onUpdateSlots;
    public UnityEvent<SaveItemData> onSelectSlot;
    public void Save()
    {
        SaveLoadManager.Data.ItemList = saveitemlist;
        SaveLoadManager.Save();

        //var jsonText = JsonConvert.SerializeObject(testItemList);
        //var filePath = Path.Combine(Application.persistentDataPath, "test.json");
        //File.WriteAllText(filePath, jsonText);
    }

    public void Load()
    {
        if(SaveLoadManager.Load())
        {
            saveitemlist = SaveLoadManager.Data.ItemList;   
        }
        SaveLoadManager.Load();
        saveitemlist = SaveLoadManager.Data.ItemList;


        //var filePath = Path.Combine(Application.persistentDataPath, "test.json");
        //if (!File.Exists(filePath))
        //{
        //    return;
        //}
        //var jsonText = File.ReadAllText(filePath);
        //testItemList = JsonConvert.DeserializeObject<List<SaveItemData>>(jsonText);
        UpdateSlots(saveitemlist);
    }

    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        Load();
    }
    private void OnDisable()
    {
        Save(); 
    }

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        AddRandomItem();
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        RemoveItem();
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha3))
    //    {
    //        Save();
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha4))
    //    {
    //        Load();
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha5))
    //    {
    //        Sorting = (SortingOptions)Random.Range(0, 6);
    //        Debug.Log(Sorting);
    //    }

    //    if (Input.GetKeyDown(KeyCode.Alpha6))
    //    {
    //        Filtering = (FilteringOptions)Random.Range(0, 4);
    //        Debug.Log(Filtering);
    //    }
    //}
  

    private void UpdateSlots(List<SaveItemData> itemList)
    {
        var list = itemList.Where(filterings[(int)filtering]).ToList();
        list.Sort(comparisons[(int)sorting]);

        if (slotlist.Count < list.Count)
        {            
            for (int i = slotlist.Count; i < list.Count; i++)
            {
                var newSlot = Instantiate(prefab, scollRect.content);
                newSlot.slotIndex = i;
                newSlot.SetEmpty();
                newSlot.gameObject.SetActive(false);

                var button = newSlot.GetComponent<Button>();
                button.onClick.AddListener(() =>
                {
                    selectedSlotIndex = newSlot.slotIndex;
                    onSelectSlot.Invoke(newSlot.ItemData);
                });

                slotlist.Add(newSlot);
            }
        }


        for (int i = 0;i<slotlist.Count;++i)
        {
            if(i<itemList.Count)
            {
                slotlist[i].gameObject.SetActive(true);
                slotlist[i].SetItem(itemList[i]);
            }
            else
            {
                slotlist[i].SetEmpty();
                slotlist[i].gameObject.SetActive(false);
            }
        }
        selectedSlotIndex = -1;
        onUpdateSlots.Invoke();
    }


    public void AddRandomItem()
    {       
        var itemInstance = new SaveItemData();
        itemInstance.itemData = DataTableManger.ItemTable.GetRandom();

        saveitemlist.Add(itemInstance);
        UpdateSlots(saveitemlist);
    }
    public void RemoveItem()
    {
        if(selectedSlotIndex == -1 )
        {
            return;
        }
        saveitemlist.Remove(slotlist[selectedSlotIndex].ItemData);
        UpdateSlots(saveitemlist);

    }
    
}
