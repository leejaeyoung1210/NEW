using Mono.Cecil.Cil;
using System.Collections.Generic;
using UnityEngine;

public class ItemTableTest : DataTable
{
    public class ItemData
    {// ������Ƽ��
        public string Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Value { get; set; }
        public int Cost { get; set; }
        public string String { get; set; }
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
                Debug.LogError("���! ��");
            }
        } //��ȸ�ϸ鼭 ��ųʸ��� Ű���� �������� �Ҵ��Ų��.

    }

   public ItemData Get(string key)
    {
        if (!dic.ContainsKey(dic[key].Id))//�ž������ϼ�
        {
            return null;
        }
        return dic[key]; //�θ��� id�� �°� ��ȯ���ָ�ȴ�. 
    }






}
