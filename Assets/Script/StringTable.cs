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
        
        var path = string.Format(FormatPath, filename);//파일경로만들어서
        var textAsset = Resources.Load<TextAsset>(path);
        var list = LoadCSV<Data>(textAsset.text);//읽어오는

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
//한번 딕셔너리 만들면 게임끝날때까지 사용 메모리 사용이과하ㅏ지않나? 자주사용할거임 쉽게접근할수있게해줘야함