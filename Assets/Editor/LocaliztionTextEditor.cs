using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(LocalizationText))]
public class LocaliztionTextEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var text = target as LocalizationText;
        var newId = EditorGUILayout.TextField("String ID", text.stringId);
        var newLang = (Languges)EditorGUILayout.EnumPopup("Language", text.editorLang);

        if (newId != text.stringId || newLang != text.editorLang)
        {
            text.stringId = newId;
            text.editorLang = newLang;
            text.OnChangeLanguge(text.editorLang);

            EditorUtility.SetDirty(text);//갱실할놈 정해주는

        }


    }
}
