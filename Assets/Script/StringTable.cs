using System.Collections.Generic;
using UnityEngine;

public class StringTable : DataTable
{
    public static readonly string Unknown = "키없음";
    public class Data
    {
        public string Id { get; set; }
        public string String { get; set; }
    }
   

    //키 밸류
    private readonly Dictionary<string, string> dictionary = new Dictionary<string, string>();


    public override void Load(string filename)
    {//경로(아이디)생성
        dictionary.Clear();

        var path = string.Format(FormatPath, filename);
        var textAsset = Resources.Load<TextAsset>(path);
        var list = LoadCSV<Data>(textAsset.text);//읽어오고

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
    {//키가아닌지 맞는지 검사 습관적으로해야한다.
        if(!dictionary.ContainsKey(key))
        {
            return Unknown;
        }

        return dictionary[key];
    }

}
