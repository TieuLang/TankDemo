using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    [CreateAssetMenu(menuName = "Abilities/Shell_1_Ability")]
    public class Shell_1 : ShellAbility
    {
        public Shell_1()
        {
        }

        public override void Init(Transform transform, float force)
        {
            Debug.Log("Shot: " + transform.position.ToString());
            base.Init(transform,force);
        }

        public override void CalculateDamage()
        {
            base.CalculateDamage();
        }
    }
}