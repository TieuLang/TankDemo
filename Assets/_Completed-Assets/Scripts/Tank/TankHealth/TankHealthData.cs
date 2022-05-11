using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Complete
{
    //[CreateAssetMenu(menuName = "Abilities/TankHealthData_1")]
    public class TankHealthData : MonoBehaviour
    {
        public float m_StartingHealth = 100f;
        public float m_CurrentHealth;
        private bool m_Dead;
        public UnityEventDoubleFloatEvent ChangeHealth;
        public UnityEvent TankDeath;

        private void OnEnable()
        {
            m_CurrentHealth = m_StartingHealth;
            m_Dead = false;
            ChangeHealth?.Invoke(m_CurrentHealth, m_StartingHealth);
        }

        public void TakeDamage(float amount)
        {
            // Reduce current health by the amount of damage done.
            m_CurrentHealth -= amount;

            ChangeHealth?.Invoke(m_CurrentHealth, m_StartingHealth);

            // If the current health is at or below zero and it has not yet been registered, call OnDeath.
            if (m_CurrentHealth <= 0f && !m_Dead)
            {
                OnDeath();
            }
        }

        private void OnDeath()
        {
            m_Dead = true;
            TankDeath?.Invoke();
            gameObject.SetActive(false);
            //// Set the flag so that this function is only called once.
            //m_Dead = true;

            //// Move the instantiated explosion prefab to the tank's position and turn it on.
            //m_ExplosionParticles.transform.position = transform.position;
            //m_ExplosionParticles.gameObject.SetActive(true);

            //// Play the particle system of the tank exploding.
            //m_ExplosionParticles.Play();

            //// Play the tank explosion sound effect.
            //m_ExplosionAudio.Play();

            //// Turn the tank off.
            //gameObject.SetActive(false);
        }
    }
    [System.Serializable]
    public class UnityEventDoubleFloatEvent : UnityEvent<float, float>
    {

    }
}