using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Complete
{
    public class TankHealthUI : MonoBehaviour
    {
        public Slider m_Slider;                             // The slider to represent how much health the tank currently has.
        public Image m_FillImage;                           // The image component of the slider.
        public Color m_FullHealthColor = Color.green;       // The color the health bar will be when on full health.
        public Color m_ZeroHealthColor = Color.red;         // The color the health bar will be when on no health.
        public Text txtHealth;


        public void SetHealUI(float m_CurentHealth,float m_StartingHealth)
        {
            txtHealth.text = (Mathf.RoundToInt(m_CurentHealth)).ToString();
            // Set the slider's value appropriately.
            m_Slider.value = (m_CurentHealth / m_StartingHealth) * 100;
            // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
            m_FillImage.color = Color.Lerp(m_ZeroHealthColor, m_FullHealthColor, m_CurentHealth / m_StartingHealth);
        }


        private void OnValidate()
        {
            if (!txtHealth)
                txtHealth = GetComponentInChildren<Text>();
        }
    }
}