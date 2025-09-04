using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.UIElements;

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

    public readonly System.Comparison<SaveItemData>[] comparison =
    {
        (lhs,rhs) =>lhs.creationTime.CompareTo(rhs.creationTime),
        (lhs,rhs) =>rhs.creationTime.CompareTo(lhs.creationTime),

        (lhs,rhs) =>lhs.itemData.StringName.CompareTo(rhs.creationTime),
        (lhs,rhs) =>rhs.itemData.StringName.CompareTo(lhs.creationTime),

        (lhs,rhs) =>lhs.itemData.Cost.CompareTo(rhs.creationTime),
        (lhs,rhs) =>rhs.itemData.Cost.CompareTo(lhs.creationTime),
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
    private int itemCount = 0;

    private List<SaveItemData> testItemList = new List<SaveItemData>();

    private SortingOptions sorting = SortingOptions.NaemAccending;
    private FilteringOptions filtering = FilteringOptions.None;

    public SortingOptions Sorting
    {
        get=>sorting;
        set
        {
            sorting = value;

            var List = testItemList.Where(filterings[(int)filtering]).ToList();
            List.Sort(comparison[(int)sorting]);
            UpdateSlots(List);
        }
    }
    public FilteringOptions Filtering
    {
        get => filtering;
        set
        {
            filtering = value;
            var List = testItemList.Where(filterings[(int)filtering]).ToList();
            List.Sort(comparison[(int)sorting]);
            UpdateSlots(List);

        }
    }

    public void Save()
    {
        var jsonText = JsonConvert.SerializeObject(testItemList);
        var filePath = Path.Combine(Application.persistentDataPath, "test.json");
        File.WriteAllText(filePath, jsonText);
    }

    public void Load()
    {
        var filePath = Path.Combine(Application.persistentDataPath, "test.json");
        if (!File.Exists(filePath))
        {
            return;
        }
        var jsonText = File.ReadAllText(filePath);
        testItemList = JsonConvert.DeserializeObject<List<SaveItemData>>(jsonText);
        UpdateSlots(testItemList);
    }

    private void Awake()
    {
        for(int i =0; i< maxCount; i++)
        {
            var newSlot = Instantiate(prefab, scollRect.content);
            newSlot.slotIndex = i;
            newSlot.SetEmpty();
            newSlot.gameObject.SetActive(false);    //°¡¸®±â
            slotlist.Add(newSlot);
        }
    }
    private void OnEnable()
    {
        Load();
    }
    private void OnDisable()
    {
        Save(); 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddRandomItem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RemoveItem(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Load();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Sorting = (SortingOptions)Random.Range(0, 6);
            Debug.Log(Sorting);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Filtering = (SortingOptions)Random.Range(0, 6);
            Debug.Log(Sorting);
        }
    }

    private void UpdateSlots(List<SaveItemData> itemList)
    {
        if (slotlist.Count == itemList.Count)
        {            
            for (int i = slotlist.Count; i < itemList.Count; i++)
            {
                var newSlot = Instantiate(prefab, scollRect.content);
                newSlot.slotIndex = i;
                newSlot.SetEmpty();
                slotlist[i].gameObject.SetActive(false);
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
    }


    public void AddRandomItem()
    {       
        var itemInstance = new SaveItemData();
        itemInstance.itemData = DataTableManger.ItemTable.GetRandom();

        testItemList.Add(itemInstance);
        UpdateSlots(testItemList);
    }
    public void RemoveItem(int slotIndex)
    {        
        testItemList.RemoveAt(slotIndex);
        UpdateSlots(testItemList);
    }
    
}
