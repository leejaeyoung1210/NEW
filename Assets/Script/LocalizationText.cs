using System.Data.Common;
using TMPro;
using UnityEngine;
using static Unity.VisualScripting.Icons;

[ExecuteInEditMode]//에디터하는중에 호출된다.
[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizationText : MonoBehaviour
{
    public  string stringId;

#if UNITY_EDITOR
    public Languges editorLang;
#endif

    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>(); 
    }

    private void OnEnable()
    {
#if UNITY_EDITOR
        if (Application.isPlaying)
        {
            OnChangeLanguge();
        }
        else
        {
            OnChangeLanguge(editorLang);
        }
#else
#endif
    }

    public void OnChangeLanguge()
    {
        var stringTable = DataTableManger.StringTable;
        text.text = stringTable.Get(stringId);
    }
#if UNITY_EDITOR
    public void OnChangeLanguge(Languges lang)
    {
        var tableId = DataTableIds.StringTableIds[(int)lang];

        var stringTable = DataTableManger.Get<StringTable>(tableId);    
        text.text = stringTable.Get(stringId);
    }
#endif
}
