using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Scripts
{
    public class SliderRotator : MonoBehaviour
    {
        public Text Text;

        public void OnSliderValueChanged()
        {
            var slider = GetComponent<Slider>();

            if(slider != null)
                Text.text = slider.value.ToString("N2");
        }
    }
}