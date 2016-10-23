using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Scripts
{
    public class BindToInput : MonoBehaviour
    {
        public Text Field;

        void Update()
        {
            GetComponent<Text>().text = Field.text;
        }
    }
}