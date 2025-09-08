using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class SaveData
{
    public int Version { get; protected set; }

    public abstract SaveData VersionUp();
    
}


//클래스 이름으로 구별할거라 구분해줘야한다.
[Serializable]
public class SaveDataV1 : SaveData
{
    public string PlayerName {get; set;} = string.Empty;    


    public SaveDataV1()
    {
        Version = 1;
    }
    public override SaveData VersionUp()
    {
        var saveData = new SaveDataV2();    
        saveData.Name = PlayerName;
        saveData.Gold = 0;
        return saveData;    
    }
}

[Serializable]
public class SaveDataV2 : SaveData
{
    public string Name { get; set;} = string.Empty; //변경된것
    public int Gold; // 새로생긴거

    public SaveDataV2()
    {
        Version = 2;
    }
    public override SaveData VersionUp()
    {
        var saveData = new SaveDataV3();
        saveData.Name = Name;
        saveData.Gold = Gold;


        return saveData;
    }
}

[Serializable]
public class SaveDataV3 : SaveData
{
    public string Name { get; set; } = string.Empty; //변경된것
    public int Gold; // 새로생긴거
    public List<SaveItemData> ItemList = new List<SaveItemData>();

    public SaveDataV3()
    {
        Version = 3;
    }
    public override SaveData VersionUp()
    {
        throw new NotImplementedException();
    }
}

[Serializable]
public class SaveDataV4 : SaveData
{


    public SaveDataV4()
    {
        Version = 4;
    }
    public override SaveData VersionUp()
    {
        throw new NotImplementedException();
    }
}