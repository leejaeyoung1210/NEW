using UnityEngine;
using UnityEngine.UI;
public class DifficultyWindow : GenericWindow
{
    public int index = 1;

    public ToggleGroup toggleGroup;

    public Toggle[] toggles;

    public override void Open()
    {
        base.Open();
        toggles[index].isOn = true;
    }

    public void OnToggle()
    {
        for (int i = 0; i < toggles.Length; ++i)
        {
            if (toggles[i].isOn)
            {
                Debug.Log(i);
                break;
            }
        }
    }

    public void OnclickEasy(bool value)
    {
        if (value)
        {
            Debug.Log("e");
        }
    }
    public void OnclickNomal(bool value)
    {
        if (value)
        {
            Debug.Log("n");
        }
    }
    public void OnclickHard(bool value)
    {
        if (value)
        {
            Debug.Log("h");
        }
    }

}
