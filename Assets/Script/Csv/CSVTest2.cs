using UnityEngine;
using TMPro;

public class CSVTest2 : MonoBehaviour
{
    public TextMeshProUGUI text;
    //private void Start()
    //{
    //    var stringTable = new StringTable();
    //    stringTable.Load("StringTableKr");

    //    text.text = stringTable.Get("Hello");
    //}


    private void Start()
    {
        var table = new ItemTable();
        table.Load("ItemTable");
    }


}
