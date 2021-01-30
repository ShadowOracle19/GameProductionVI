using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LC
{
    public class StaminaBar : MonoBehaviour
    {
        public Slider slider;

        public void SetMaxStamina(int maxStamina)
        {
            slider.maxValue = maxStamina;
            slider.value = maxStamina;
        }

        public void SetCurrentStamina(int currentStamina)
        {
            slider.value = currentStamina;
        }
    }
}
