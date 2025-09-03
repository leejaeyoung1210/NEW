using System.Collections.Generic;
using UnityEngine;

public class StringTable : DataTable
{
    public static readonly string Unknown = "Ű����";
    public class Data //�Ľ� �����ϱ�����
    {
        public string Id { get; set; }
        public string String { get; set; }
    }
   
    //�������� ���
    //Ű ��� ���������� ��Ʈ���ξֵ� 
    private readonly Dictionary<string, string> dictionary = new Dictionary<string, string>();

    //��ųʸ� �ʱ�ȭ�ϰ� �����ϴ°����� load 
    public override void Load(string filename)
    {//���(���̵�)����
        dictionary.Clear();
        
        var path = string.Format(FormatPath, filename);//���ϰ�θ���
        var textAsset = Resources.Load<TextAsset>(path);
        var list = LoadCSV<Data>(textAsset.text);//�о����

        foreach(var item in list)
        {
            if (!dictionary.ContainsKey(item.Id))
            {
                dictionary.Add(item.Id, item.String); //�ߺ� ������ ���ܳ�������
            }
            else
            {//���� �ߺ� ���ܳ��� ���ڳ����׽�Ʈ
                Debug.LogError($"Ű �ߺ�: {item.Id}");
            }
        }
    }

    public string Get(string key)//���ڴ� �� �����ϴ�.
    {//Ű���ƴ��� �´��� �˻� �����������ؾ��Ѵ�.//�´�Ű�� �����پ�����
        if(!dictionary.ContainsKey(key))
        {
            return Unknown;
        }

        return dictionary[key];
    }

}
//�ѹ� ��ųʸ� ����� ���ӳ��������� ��� �޸� ����̰��Ϥ����ʳ�? ���ֻ���Ұ��� ���������Ҽ��ְ��������