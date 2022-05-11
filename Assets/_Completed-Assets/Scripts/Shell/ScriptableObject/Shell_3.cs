using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    [CreateAssetMenu(menuName = "Abilities/Shell_3_Ability")]
    public class Shell_3 : ShellAbility
    {
        [SerializeField]
        private float m_Acceleration;
        [SerializeField]
        private float m_MaxSpeed;
        public float m_TimeForSpeed;
        public AccelerationComp buff_Speed =new AccelerationComp();
        public override void CalculateDamage()
        {
            base.CalculateDamage();
        }

        public override void Init(Transform transform, float force)
        {
            base.Init(transform, force); 
        }
    }
}