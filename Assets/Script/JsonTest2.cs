using Mono.Cecil;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonTest2 : MonoBehaviour
{
    public static readonly string fileName = "cube.json";
    public static string fileFullPath => Path.Combine(Application.persistentDataPath, fileName);

    public CubeSpawner spawner;

    public GameObject target;

    public List<CubeData> cubelist;

    private void Awake()
    {
        cubelist = new List<CubeData>();
    }

    //pos , rot , scale ,Color 저장
    public void Save()
    {
        cubelist.Clear();

        foreach (var i in spawner.cubes)
        {
            var p = i.transform;
            var r = i.GetComponent<Renderer>();
            var col = r.material.color;

            cubelist.Add(new CubeData
            {
                pos = p.position,
                rot = p.eulerAngles,
                scale = p.localScale,
                r = col.r,
                g = col.g,
                b = col.b,
                a = col.a,
            }
            );
        }

        var json = JsonConvert.SerializeObject(cubelist, new Vector3Converter());
        File.WriteAllText(fileFullPath, json);

    }
    //SerializeObject ( 객체,Formatting.Indented(어떻게 출력할건지)or&&설정 옵션 추가),
    public void Load()
    {
        var json = File.ReadAllText(fileFullPath);
        var position = JsonConvert.DeserializeObject<List<CubeData>>(json, new Vector3Converter());
        //target.transform.position = position;
        Debug.Log(json);
    }
}
