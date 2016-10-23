using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Scripts
{
    public class ResetInput : MonoBehaviour
    {
        public InputField Text;

        public void OnClick()
        {
            Text.text = "";
        }
    }
}