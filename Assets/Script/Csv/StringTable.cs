using System.Collections.Generic;
using UnityEngine;

public class StringTable : DataTable
{
    public static readonly string Unknown = "키없음";
    public class Data //파싱 구분하기위해
    {
        public string Id { get; set; }
        public string String { get; set; }
    }
   
    //실질적인 멤버
    //키 밸류 데이터형이 스트링인애들 
    private readonly Dictionary<string, string> dictionary = new Dictionary<string, string>();

    //딕셔너리 초기화하고 셋팅하는과정이 load 
    public override void Load(string filename)
    {//경로(아이디)생성
        dictionary.Clear();
        
        var path = string.Format(FormatPath, filename);//(파일자리를 가져와,그자리에 벨류값을 넣는다.)
        var textAsset = Resources.Load<TextAsset>(path);//TextAsset은 .txt, .csv, .json 같은 텍스트 파일을 메모리에 그대로 불러오는 용도로 쓰입니다.
        //textAsset.text 속성을 사용하면 그 파일의 문자열 내용을 얻을 수 있습니다.
        var list = LoadCSV<Data>(textAsset.text);//csv파일 가져온걸 Data 형태에 맞게 리스트화함

        foreach(var item in list)
        {
            if (!dictionary.ContainsKey(item.Id))
            {
                dictionary.Add(item.Id, item.String); //중복 허용안함 예외나고죽음
            }
            else
            {//문자 중복 예외나면 문자나는테스트
                Debug.LogError($"키 중복: {item.Id}");
            }
        }
    }

    public string Get(string key)//순자는 좀 난해하다.
    {//키가아닌지 맞는지 검사 습관적으로해야한다.//맞는키를 가져다쓰려고
        if(!dictionary.ContainsKey(key))
        {
            return Unknown;
        }

        return dictionary[key];
    }

}
//한번 딕셔너리 만들면 게임끝날때까지 사용 메모리 사용이과함? 자주사용할거임 쉽게접근할수있게해줘야함