using UnityEngine;
using TMPro;
public class StringTableText : MonoBehaviour
{
    public string id;
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        //DataTableManger.StringTable.Load();
        //var stringTable = DataTableManger.Get<StringTable>("String");
        textMeshPro.text = DataTableManger.StringTable.Get(id);
    }
}
