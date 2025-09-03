using UnityEngine;
using System.Collections.Generic;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cube;
    public int count = 10;
   private Transform preant;

    public List<GameObject> cubes;
    // Update is called once per frame

    private void Awake()
    {
        cubes = new List<GameObject>(count);
    }

    public void Add()
    {        
        for (int i = 0; i < count; i++)
        {            
            var obj  = Instantiate(cube, preant);
            cubes.Add(obj);
        }
    }

    public void Reset()
    {
        foreach(var a in cubes)
        {
            Destroy(a);
        }
        cubes.Clear();
    }


}
