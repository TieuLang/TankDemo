using Complete;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace Complete
{

    public class TankShooting : MonoBehaviour
    {
        public int m_PlayerNumber = 1;              // Used to identify the different players.
        public Transform m_FireTransform;           // A child of the tank where the shells are spawned.
        public AudioSource m_ShootingAudio;         // Reference to the audio source used to play the shooting audio. NB: different to the movement audio source.
        public AudioClip m_ChargingClip;            // Audio that plays when each shot is charging up.
        public AudioClip m_FireClip;                // Audio that plays when each shot is fired.
        private string m_FireButton;                // The input axis that is used for launching shells.
        private FireStyleComp FireStyleComp;


        private void Start()
        {
            m_FireButton = "Fire" + m_PlayerNumber;
            FireStyleComp = GetComponentInChildren<FireStyleComp>();
        }

        private void Update()
        {
            if (Input.GetButtonDown(m_FireButton))
            {
                m_ShootingAudio.clip = m_ChargingClip;
                m_ShootingAudio.loop = true;
                m_ShootingAudio.Play();
            }
            else if (Input.GetButtonUp(m_FireButton))
                Fire();
        }


        private void Fire()
        {
            m_ShootingAudio.loop = false;
            m_ShootingAudio.clip = m_FireClip;
            m_ShootingAudio.Play();
            FireStyleComp?.OnGunFireTrigger();
        }
    }
}