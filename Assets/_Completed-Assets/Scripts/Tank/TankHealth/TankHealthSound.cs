using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class TankHealthSound : MonoBehaviour
    {
        public GameObject m_ExplosionPrefab;                // A prefab that will be instantiated in Awake, then used whenever the tank dies.
        private AudioSource m_ExplosionAudio;               // The audio source to play when the tank explodes.
        private ParticleSystem m_ExplosionParticles;        // The particle system the will play when the tank is destroyed.

        private void Awake()
        {
            // Instantiate the explosion prefab and get a reference to the particle system on it.
            m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();

            // Get a reference to the audio source on the instantiated prefab.
            m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();
            Debug.Log(m_ExplosionAudio != null);
            // Disable the prefab so it can be activated when it's required.
            m_ExplosionParticles.gameObject.SetActive(true);
        }

        public void OnLostHealth()
        {
            //m_ExplosionParticles.transform.position = transform.position;
            m_ExplosionAudio?.Play();
        }

        public void OnDeath()
        {
            m_ExplosionParticles.transform.position = transform.position;
            m_ExplosionParticles.gameObject.SetActive(true);

            // Play the particle system of the tank exploding.
            m_ExplosionParticles.Play();

            // Play the tank explosion sound effect.
            m_ExplosionAudio.Play();

            // Turn the tank off.
            //gameObject.SetActive(false);
        }    

    }
}
