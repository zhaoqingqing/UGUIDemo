using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class EventTriggerScene : MonoBehaviour,IPointerClickHandler
{
	private EventTrigger eventTrigger;
	// Use this for initialization
	void Start ()
	{
		eventTrigger = GetComponent<EventTrigger>();
	}
	
	
	public  void OnPointerClick(PointerEventData eventData )
	{
		//Debug.Log(eventData.selectedObject);
	}
}
