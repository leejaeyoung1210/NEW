using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardWindow : GenericWindow
{
    public List<Button> buttons;
    private string text;
    public Button button;
    StringBuilder sb;

    public GameObject startPanel;



    private void Awake()
    {
        //sb = new StringBuilder(); 
        //var buttons = gameObject.GetComponentsInChildren<Button>();

        //var buttontext = button.GetComponentInChildren<TextMeshPro>();
        //var key = buttontext.text;
        //button.onClick.AddListener(()=> OnKey(key));

    }

    public void OnKey(string key)
    {
        //sb.Append(key); 
        //text = sb.ToString(); 
    }

    public void Back()
    {
        gameObject.SetActive(false);
        startPanel.SetActive(true);
    }
    


}
