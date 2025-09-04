using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;




public enum ItemTypes
{
    Weapon,
    Equip,
    Consumable,
}

public class ItemData
{//�Ľ̹� �����Ϳ뵵 // cs ���� �ű�¿뵵 //������ ���� desc ����Ʈ���� ���� ��������Ʈ => ������Ƽ 
    public string Id { get; set; }
    public ItemTypes Type { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public int Value { get; set; }
    public int Cost { get; set; }
    public string Icon { get; set; } // ������ ��ο� 

    public override string ToString()
    {
        return $"{Id}/{Type}/{Name}/{Desc}/{Value}/{Cost}/{Icon}";
    }

    public string StringName => DataTableManger.StringTable.Get(Name);
    public string StringDesc => DataTableManger.StringTable.Get(Desc);

    public Sprite SpriteIcon => Resources.Load<Sprite>($"icon/{Icon}"); // ���ҽý����ִ� ���ϰ�ο��ִ� ������ ��������
    //(���) ���ͷ� ���X
}





public class ItemTable : DataTable
{
    private readonly Dictionary<string, ItemData> table = new Dictionary<string, ItemData>();
    public override void Load(string filename)
    {
        table.Clear();

        var path = string.Format(FormatPath, filename);
        var textAsset = Resources.Load<TextAsset>(path);
        var list = LoadCSV<ItemData>(textAsset.text);

        foreach (var item in list)
        {

            if (!table.ContainsKey(item.Id))
            {
                table.Add(item.Id, item);//������?
            }
            else
            {
                Debug.LogError("������ ���̵� �ߺ�!");
            }
        }

        foreach(var item in table)//�׽�Ʈ ��¿�   
        {
            //Debug.Log(item.Value);
            //var data = table.
            //Debug.Log(data.StringName);
        }
    }




    public ItemData Get(string id)
    {
        if (!table.ContainsKey(id))
        {
            return null;
        }
        return table[id];
    }

    // ó�� ���� 1���� ���� �ܰ������� �ø���?
    //��������� ǥ���ϴ»�Ȳ
    //����ִ»�Ȳ
    //Ŭ���� ����ǥ�� //������ư�� �����
    //�����տ� ��ư �����̹��� ��� �Ʒ� �ؽ�Ʈ
    //������ ��ũ��Ʈ�� �����պٿ��� �����


}
