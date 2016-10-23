using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
/// <summary>
/// InputField
/// doc:https://docs.unity3d.com/ScriptReference/UI.InputField.html
/// </summary>
public class InputTextScene : MonoBehaviour
{
    [SerializeField]
    private InputField inputField;
    [SerializeField]
    private Text textField;

    void Awake()
    {
        //inputField.validation = InputField.Validation.Name;
        inputField.characterValidation = InputField.CharacterValidation.Name;
        inputField.keyboardType = TouchScreenKeyboardType.Default;
        //inputField.GetComponent<EventTrigger>().OnSubmit();
    }

    void Start()
    {
        //inputField.onSubmit.AddListener(OnSubmit);//4.6 beta有此事件
        //inputField.OnSubmit(new BaseEventData(OnSubmit2()));
        //编辑完成，失去焦点或者按Enter键，都会触发此事件
        //inputField.onEndEdit.AddListener(OnSubmit);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            //OnSubmit1();
        }
    }

    public void OnSubmit(string text)
    {
        textField.text = textField.text + "\n\t\t\t\t" + text;
        inputField.text = "";
    }
    public void OnSubmit1()
    {

        var currentText = inputField.text;

    }
    public void OnSubmit2(EventSystem eventData)
    {
        var test = eventData;
        var currentText = inputField.text;

    }
}
