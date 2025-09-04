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
{//파싱및 데이터용도 // cs 파일 옮기는용도 //아이콘 네임 desc 설명스트링및 실제 스프라이트 => 프로퍼티 
    public string Id { get; set; }
    public ItemTypes Type { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public int Value { get; set; }
    public int Cost { get; set; }
    public string Icon { get; set; } // 아이템 경로용 

    public override string ToString()
    {
        return $"{Id}/{Type}/{Name}/{Desc}/{Value}/{Cost}/{Icon}";
    }

    public string StringName => DataTableManger.StringTable.Get(Name);
    public string StringDesc => DataTableManger.StringTable.Get(Desc);

    public Sprite SpriteIcon => Resources.Load<Sprite>($"icon/{Icon}"); // 리소시스에있는 파일경로에있는 아이콘 가져오기
    //(경로) 리터럴 언어X
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
                table.Add(item.Id, item);//아이콘?
            }
            else
            {
                Debug.LogError("아이템 아이디 중복!");
            }
        }

        foreach(var item in table)//테스트 찍는용   
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

    // 처음 슬롯 1개를 만들어서 단계적으로 늘리는?
    //어떤아이템을 표현하는상황
    //비어있는상황
    //클릭시 정보표현 //삭제버튼시 지우기
    //프리팹에 버튼 위에이미지 배경 아래 텍스트
    //아이템 스크립트에 프리팹붙여서 만들고


}
