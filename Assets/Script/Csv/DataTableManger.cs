using System.Collections.Generic;
using UnityEngine;

//��� ���������̺��� �ʱ�ȭ�������. ���Ҷ����� ���ϴ� ���̺��� ������ �����Ҽ��ְ��������.
public static class DataTableManger
{
    private static readonly Dictionary<string, DataTable> tables = new Dictionary<string, DataTable>(); // ���̺��� �����ϴ� ��ųʸ�

    static DataTableManger()
    {
        Init();
    }

    private static void Init()
    {

#if UNITY_EDITOR
        foreach (var id in DataTableIds.StringTableIds)
        {
            var table = new StringTable();

            table.Load(id);
            tables.Add(id, table);
        }
#else
          var stringTable = new StringTable();

        stringTable.Load(DataTableIds.StringTableIds[(int)Variables.Languge]);
        tables.Add(DataTableIds.String, stringTable);  
#endif        
        var itemTable = new ItemTable();
        itemTable.Load(DataTableIds.Item);
        tables.Add(DataTableIds.Item, itemTable); //��ũ��Ʈ�� �����ϴ°� ��ΰ��� 
    }
    public static StringTable StringTable
    {
        get
        {
            return Get<StringTable>(DataTableIds.String);
        }
    }
    public static ItemTable ItemTable
    {
        get
        {
            return Get<ItemTable>(DataTableIds.Item);
        }
    }


    public static T Get<T>(string id) where T : DataTable
    {
        if (!tables.ContainsKey(id))
        {
            Debug.LogError("���̺� ����");
            return null;
        }
        return tables[id] as T;
    }

}
