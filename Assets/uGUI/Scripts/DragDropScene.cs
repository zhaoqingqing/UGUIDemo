using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DragDropScene : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler {

	[SerializeField] GameObject grid=null,rootCanvas=null;

	public void OnDrag(PointerEventData eventData)
	{
		GetComponent<RectTransform>().pivot.Set(0,0);
		transform.position=Input.mousePosition;
	}
	
	public void OnPointerDown(PointerEventData eventData)
	{
		transform.localScale=new Vector3(0.7f,0.7f,0.7f);
		transform.parent=rootCanvas.transform;
	}
	
	public void OnPointerUp(PointerEventData eventData)
	{
		transform.localScale=new Vector3(1f,1f,1f);
	
		RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition,-Vector2.up);
		if (hit.collider != null) {
			//如果射线检测到的gameobject为grid，则放在grid节点下
			if(hit.collider.gameObject.name=="Grid")
				transform.parent=grid.transform;
		}
	}
}
