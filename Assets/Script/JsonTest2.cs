using Mono.Cecil;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class JsonTest2 : MonoBehaviour
{
    public static readonly string fileName = "cube.json";
    public static  string fileFullPath =>Path.Combine(Application.persistentDataPath, fileName);

    public CubeSpawner spawner;
 
    public GameObject target;

    //pos , rot , scale ,Color ¿˙¿Â
    public void Save()
    {
        var json = JsonConvert.SerializeObject(target.transform.position, new Vector3Converter());
        File.WriteAllText(fileFullPath, json);

    }

    public void Load()
    {
        var json = File.ReadAllText(fileFullPath);
        var position = JsonConvert.DeserializeObject<Vector3>(json, new Vector3Converter());
            target.transform.position = position;
        Debug.Log(position);
    }
}
