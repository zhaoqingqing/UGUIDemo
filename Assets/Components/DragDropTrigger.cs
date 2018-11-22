using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//拖动组件
//复制一份图标，用于拖动，当取消拖动时Destory复制出来的对象，不修改原始gameobject。
//https://www.cnblogs.com/zhaoqingqing/p/3974275.html
public class DragDropTrigger : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Vector3 onDownScale = new Vector3(0.7f, 0.7f, 0.7f);
    //作为唯一标识：用于事件回调
    public string key = "";

    public Transform targetPanel = null;  
    //放入事件
    public Action<string> OnPutIn = null;
    public GameObject cloneObj;

    public static DragDropTrigger Create(GameObject obj, Transform _target,  string _key)
    {
        if (obj == null)
        {
            return null;
        }
        var compoent = obj.GetComponent<DragDropTrigger>() ?? obj.AddComponent<DragDropTrigger>();
        compoent.targetPanel = _target;       
        compoent.key = _key;

        return compoent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (cloneObj != null)
        {
            transform.localScale = Vector3.zero;
            cloneObj.GetComponent<RectTransform>().pivot.Set(0, 0);
            cloneObj.transform.position = Input.mousePosition;
        }
        else
        {
            OnPointerDown(eventData);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (cloneObj == null)
        {
            cloneObj = GameObject.Instantiate(gameObject);
            cloneObj.transform.localScale = onDownScale;
            cloneObj.transform.parent = targetPanel;
            cloneObj.transform.position = transform.position;
        }
        else
        {
            Destroy(cloneObj);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        cloneObj.transform.localScale = new Vector3(1f, 1f, 1f);
        //限定distance，否则在图标的正上方松手后也会检测到
        RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, -Vector2.up,2);

        if (hit.collider != null)
        {
//            Debug.LogFormat("hit ,{0}", hit.collider.gameObject.name);
            //如果射线检测到的gameobject为grid，则放在grid节点下
            if (hit.collider.gameObject.name == targetPanel.name)
            {
                cloneObj.transform.parent = targetPanel;
                cloneObj.transform.localPosition = Vector3.zero;
                if (OnPutIn != null)
                {
                    OnPutIn.Invoke(key);
                }
            }
            else
            {
                ShowOriginal();
            }
        }
        else
        {
            ShowOriginal();
        }
    }

    //显示原来的
    public void ShowOriginal()
    {
        Destroy(cloneObj);
        transform.localScale = Vector3.one;
    }
}