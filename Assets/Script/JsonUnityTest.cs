using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO; 


[Serializable] // <=Newtonsoft 사용하려면 필요
public class SomeClasse
{
    public int number;
}



public class PlayerState
{

    public string playerName;
    public int lives;
    public float health;
    public Vector3 position;
    public int[] array;
    public SomeClasse someObj;

    public override string ToString()
    {
        return $"{playerName}/{lives}/{health}/{array[0]}";
    }
    //public string SaveTostring()
    //{
    //    return JsonUtility.ToJson();
    //}

}

public class JsonUnityTest : MonoBehaviour
{
    private void Start()
    {
        var obj = new PlayerState
        {
            playerName = "ABC",
            lives = 10,
            health = 10.999f,
            array = new int[]{ 9, 8, 7, 6 },
        };
        //var json = JsonUtility.ToJson(obj);
        //Debug.Log(json);

        //var obj2 = JsonUtility.FromJson<PlayerState>(json);
        //Debug.Log(obj2);
        var path = Path.Combine(Application.persistentDataPath, "test.json");
        string json = JsonConvert.SerializeObject(obj, Formatting.Indented,new Vector3Converter());
        File.WriteAllText(path, json);

        var json2 = File.ReadAllText(path);
        var obj2 = JsonConvert.DeserializeObject<PlayerState>(json2,new Vector3Converter());
        Debug.Log(json);
        Debug.Log(json2);



        //string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
        //Debug.Log(json);

        //var obj2 = JsonConvert.DeserializeObject<PlayerState>(json);
        //Debug.Log(obj2);
    }
}

