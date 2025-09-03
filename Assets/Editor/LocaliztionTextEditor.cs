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

            EditorUtility.SetDirty(text);//갱실할놈 정해주는 중요 이걸해야 바뀐다.
        }
    }
    //추가 아이템 3가지중 랜덤 위에서부터차고 4가지?
    // 아이템클릭시 오른쪽에 아이템 정보가 보임 //이름,카테고리,수치,금액,설명텍스트
    // 아이콘은=> 파일이름 경로? 로 저장 스프라이트 로드가능
    // 정렬 오름차순 내림차순 / 카테고리로 나눠서보기
    //아이템 테이블 
    // csv파일을 어떻게 넘길건가

    //csv 파일만들기
    //아이템테이블 만들기
    //만든놈을 데이터테이블매니져에 추가해봐라
}
