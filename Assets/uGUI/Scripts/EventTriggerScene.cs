using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class EventTriggerScene : MonoBehaviour, IPointerClickHandler
{
    public EventTrigger eventTrigger;

    // Use this for initialization
    void Start()
    {
        if (eventTrigger != null) 
        {
            //eventTrigger.OnPointerClick();
        }
        else
        {
            Debug.LogError("eventTrigger is null");
        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.selectedObject);
    }
}
