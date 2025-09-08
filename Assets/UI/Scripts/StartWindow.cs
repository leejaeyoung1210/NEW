using UnityEngine;
using UnityEngine.UI;

public class StartWindow : GenericWindow
{
    public bool canContinue = true;

    public Button continueButton;

    public Button newGameButtonl;

    public Button optionButton;

    protected void Awake()
    {
        continueButton.onClick.AddListener(OnClickContinue);
        newGameButtonl.onClick.AddListener(OnClicknewGame);
        optionButton.onClick.AddListener(OnClickOption);
    }
    public override void Open()
    {
        continueButton.gameObject.SetActive(canContinue);
        firstSelectde = continueButton.gameObject.activeSelf ? continueButton.gameObject : newGameButtonl.gameObject;
                

        base.Open();
    }

    public void OnClickContinue()
    {
        Debug.Log("continue");
    }

    public void OnClicknewGame()
    {
        Debug.Log("newGame");
    }

    public void OnClickOption()
    {
        Debug.Log("Option");
    }
}
