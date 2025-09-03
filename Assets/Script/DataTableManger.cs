using System.Collections.Generic;
using UnityEngine;

//모든 데이터테이블을 초기화해줘야함. 원할때마다 원하는 테이블을 가져와 셋팅할수있게해줘야함.
public static class DataTableManger
{
    private static readonly Dictionary<string, DataTable> tables = new Dictionary<string, DataTable>(); //여러 테이블 가질예정

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
        
    }

    public static StringTable StringTable
    {
        get
        {
            return Get<StringTable>(DataTableIds.String);
        }
    }

    public static T Get<T>(string id) where T : DataTable
    {
        if (!tables.ContainsKey(id))
        {
            Debug.LogError("테이블 없음");
            return null;
        }
        return tables[id] as T;
    }

}
