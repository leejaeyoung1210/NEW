using Mono.Cecil.Cil;
using System.Collections.Generic;
using UnityEngine;

public class ItemTable : DataTable
{
    public class ItemData
    {
        public string Id;
        public string Name;
        public string Icon;
        public int Num1;
        public int Num2;
        public string String;
    }

     public readonly static Dictionary<string, ItemData> dic = new Dictionary<string, ItemData>();    

    public override void Load(string filename)
    {
        dic.Clear();

        var path = string.Format(FormatPath, filename); //저장 순서 정하고
        var textAsset = Resources.Load<TextAsset>(path);//Resources에서 저장된 string 가져와 => TextAsset를 통해 csv변환
        var list = LoadCSV<ItemData>(textAsset.text);//변환된 csv중 텍스트들을 배열에 넣고

        foreach( var item in list )
        {
            if (!dic.ContainsKey(item.Id))//검사확인필수
            {
                dic.Add(item.Id, item);
            }
            else
            {
                Debug.LogError("비상 구");
            }
        } //순회하면서 딕셔너리에 키값과 벨류값을 할당시킨다.

    }

   public ItemData Get(string key)
    {
        if (!dic.ContainsKey(dic[key].Id))
        {
            return null;
        }
        return dic[key]; //부르는 id에 맞게 반환해주면된다. 
    }






}
