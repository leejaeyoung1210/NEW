using UnityEngine;


public enum Languges
{
    Korean,
    English,
    Japanese,
}

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