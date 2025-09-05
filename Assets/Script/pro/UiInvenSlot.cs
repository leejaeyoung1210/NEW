using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiInvenSlot : MonoBehaviour
{
    public int slotIndex {  get;set; }
    public Image imageIcon;

    public TextMeshProUGUI textName;
    public SaveItemData ItemData {  get; private set; }    

    //private void Update()
    //{
    //    //if(Input.GetKeyDown(KeyCode.Alpha1))
    //    //{
    //    //    SetEmpty();
    //    //}
    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        var data = DataTableManger.ItemTable.Get("Item4");
    //        SetItem(data);
    //    }

    //}

    public void SetEmpty()
    {
        ItemData = null;
        imageIcon.sprite = null;    
        textName.text = string.Empty;      

    }

    public void SetItem(SaveItemData data) //보여주기
    {
        ItemData = data;
        imageIcon.sprite = ItemData.itemData.SpriteIcon;
        textName.text = ItemData.itemData.StringName;
    }
}
