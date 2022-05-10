using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Complete
{
    public class AccelerationScript : MonoBehaviour
    {
        public float m_Acceleration = 5;
        public float m_MaxSpeed = 30;
        public ShellAbility m_Shell;
        public float m_TimeForUpSpeed = 0.5f;
        private float m_Timer = 0;
        private Vector3 PreLocation;

        private void Start()
        {
            PreLocation = GetComponentInParent<Transform>().position;
        }
        void Update()
        {
            m_Timer += Time.deltaTime;
            Vector3 NowLocation = GetComponentInParent<Transform>().position;
            float length = Mathf.Sqrt(Mathf.Sqrt(Mathf.Pow(NowLocation.x - PreLocation.x, 2) + Mathf.Pow(NowLocation.y - PreLocation.y, 2)) + Mathf.Pow(NowLocation.z - PreLocation.z, 2));
            PreLocation = NowLocation;
            if (m_Timer>=m_TimeForUpSpeed && m_MaxSpeed>length/Time.deltaTime)
            {
                m_Timer = 0;
                Rigidbody rigid = GetComponentInParent<Rigidbody>();
                rigid.AddForce(GetComponentInParent<Transform>().forward * Mathf.Min(m_Acceleration, m_MaxSpeed- length / Time.deltaTime));
            }
            
        }
    }

}