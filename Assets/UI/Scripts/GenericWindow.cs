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
        // Ŀ��Ʈ =>�ڵ����� ��������� �̺�Ʈ�ý��ۺپ��ִ� ������Ʈ�� �ִٸ� ����� ���۷����� ������
        //�Ű����� ���ӿ�����Ʈ�� ����Ʈ���°���
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
