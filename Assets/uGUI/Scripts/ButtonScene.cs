using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScene : MonoBehaviour, IPointerClickHandler
{
    //[SerializeField]
    public Button mButton1;

    // Use this for initialization
    void Start()
    {
        if (mButton1 == null)
        {
            mButton1 = transform.GetComponentInChildren(typeof(Button), true) as Button;
            //FindChild只能寻找单层节点
            //mButton1 = transform.FindChild("Button1").GetComponent<Button>();
        }
        if (mButton1 != null)
        {
            mButton1.onClick.AddListener(OnClickBtn1);

            mButton1.onClick.AddListener(delegate()
            {
                OnClickBtn1(mButton1);
            });
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.selectedObject);
    }

    void OnClickBtn1()
    {

        Debug.Log(this.name);
    }
    void OnClickBtn1(Button btn)
    {
        if (btn == null) return;
        Debug.Log(btn.name);
    }

    public void ButtonTest(string arg)
    {
        Debug.Log(arg);
    }
}
