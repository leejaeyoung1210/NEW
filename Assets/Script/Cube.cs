using System;
using UnityEngine;
using Random = UnityEngine.Random;
//[Serializable]
public class Cube : MonoBehaviour
{

    private MeshRenderer rend;
   
    private void Start()
    {
      
        float x = Random.Range(-10,10);
        float y = Random.Range(-5,5);
        rend = GetComponent<MeshRenderer>();
        transform.position = new Vector3(x, y, 0);
        rend.material.color = Random.ColorHSV();
        rend.transform.rotation = Random.rotation;
        rend.transform.localScale = new Vector3(Random.value, Random.value, Random.value);
    }
}
