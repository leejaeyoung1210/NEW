using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InvenSlot : MonoBehaviour
{
    public Image imageIcon;

    public TextMeshProUGUI textName;

    private ItemData itemData;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetEmpty();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            var data = DataTableManger.ItemTable.Get("Item4");
            SetItem(data);
        }

    }

    public void SetEmpty()
    {
        itemData = null;
        imageIcon.sprite = null;    
        textName.text = string.Empty;      

    }

    public void SetItem(ItemData data) //보여주기
    {
        imageIcon.sprite = data.SpriteIcon;
        textName.text = data.StringName;
    }
}
