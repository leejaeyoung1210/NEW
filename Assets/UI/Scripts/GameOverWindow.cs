using UnityEngine;

public class GameOverWindow : GenericWindow
{

    public GameObject nextPanel;

    public void Next()
    {
        gameObject.SetActive(false);    
        nextPanel.SetActive(true);  
    }
}
