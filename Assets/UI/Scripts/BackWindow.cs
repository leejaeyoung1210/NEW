using System.Xml.Serialization;
using UnityEngine;

public class BackWindow : MonoBehaviour
{
    
    public GameObject StartPanel;
    public void Back()
    {
        gameObject.SetActive(false);
        StartPanel.SetActive(true);
    }
}
