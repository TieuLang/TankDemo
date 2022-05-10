using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Complete
{
    public class AccelerationComp : MonoBehaviour
    {
        public float m_Acceleration = 5;
        public float MaxSpeed = 10;
        public Rigidbody rigid;
        private float currenSpeed = 0;
        private bool IsGotStartSpeed;

        private void Update()
        {
            if (!IsGotStartSpeed && rigid != default)
                SetStartSpeed();
            if (MaxSpeed > currenSpeed)
            {
                currenSpeed += m_Acceleration * Time.deltaTime;
                if (MaxSpeed < currenSpeed)
                    currenSpeed = MaxSpeed;
            }
            rigid.velocity = rigid.velocity.normalized * currenSpeed;
        }

        private void SetStartSpeed()
        {
            currenSpeed = rigid.velocity.magnitude;
            IsGotStartSpeed = true;
        }

        private void OnValidate()
        {
            if (!rigid)
                rigid = GetComponent<Rigidbody>();
        }
    }
}