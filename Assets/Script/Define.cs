using UnityEngine;


public enum Languges
{
    Korean,
    English,
    Japanese,
}
//모든 데이터테이블의 아이디를 가지고있음 
public static class DataTableIds
{
    public static readonly string[] StringTableIds =
    {
        "StringTableKr",
        "StringTableEn",
        "StringTableJp",
    };

    public static string String => StringTableIds[(int)Variables.Languge];
}

public static class Variables
{
    public static Languges Languge = Languges.Korean;
}