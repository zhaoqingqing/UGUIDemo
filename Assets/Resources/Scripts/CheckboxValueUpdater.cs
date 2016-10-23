using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Scripts
{
    public class CheckboxValueUpdater : MonoBehaviour
    {
        public Text TextField;

        public void CheckboxChanged()
        {
            var checkbox = GetComponent<Toggle>();
            TextField.text = checkbox.isOn ? "On" : "Off";
        }
    }
}
