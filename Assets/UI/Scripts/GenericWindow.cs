using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GenericWindow : MonoBehaviour
{
    public GameObject firstSelectde;

    protected WindowManager manager;
    public void Init(WindowManager mgr)
    {
        manager = mgr;
    }
    public void OnFocus()
    {
        // 커런트 =>코드실행시 실행씬에서 이벤트시스템붙어있는 컴포넌트가 있다면 고놈의 래퍼런스를 가져옴
        //매개변수 게임오브젝트가 셀렉트상태가됨
        EventSystem.current.SetSelectedGameObject(firstSelectde); 
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
        OnFocus();
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
    }
}
