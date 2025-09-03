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

        var path = string.Format(FormatPath, filename); //���� ���� ���ϰ�
        var textAsset = Resources.Load<TextAsset>(path);//Resources���� ����� string ������ => TextAsset�� ���� csv��ȯ
        var list = LoadCSV<ItemData>(textAsset.text);//��ȯ�� csv�� �ؽ�Ʈ���� �迭�� �ְ�

        foreach( var item in list )
        {
            if (!dic.ContainsKey(item.Id))//�˻�Ȯ���ʼ�
            {
                dic.Add(item.Id, item);
            }
            else
            {
                Debug.LogError("��� ��");
            }
        } //��ȸ�ϸ鼭 ��ųʸ��� Ű���� �������� �Ҵ��Ų��.

    }

   public ItemData Get(string key)
    {
        if (!dic.ContainsKey(dic[key].Id))
        {
            return null;
        }
        return dic[key]; //�θ��� id�� �°� ��ȯ���ָ�ȴ�. 
    }






}
