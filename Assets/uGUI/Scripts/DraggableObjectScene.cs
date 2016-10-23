using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Drag事件 示例
/// </summary>
public class DraggableObjectScene : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
	//Drag事件，设置目标的位置为鼠标的位置
	public void OnDrag(PointerEventData eventData)
	{
        Debug.Log("OnDrag");
		GetComponent<RectTransform>().pivot.Set(0,0);
		transform.position=Input.mousePosition;
	}
	
	public void OnPointerDown(PointerEventData eventData)
	{
        Debug.Log("OnPointerDown");
        //缩小
		transform.localScale=new Vector3(0.7f,0.7f,0.7f);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
        Debug.Log("OnPointerUp");
        //正常大小
		transform.localScale=new Vector3(1f,1f,1f);
	}
}
