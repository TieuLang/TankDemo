using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    [CreateAssetMenu(menuName = "Abilities/Shell_2_Ability")]
    public class Shell_2 : ShellAbility
    {
        public Shell_2()
        {
        }

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
