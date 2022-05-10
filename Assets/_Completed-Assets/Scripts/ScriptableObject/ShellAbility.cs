using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Complete
{ 
    public abstract class ShellAbility : ScriptableObject
    {
        public LayerMask m_TankMask;                        // Used to filter what the explosion affects, this should be set to "Players".
        public GameObject m_Shell;                            // used to Create shell
        public float m_MaxDamage = 2f;                    // The amount of damage done if the explosion is centred on a tank.
        public float m_MaxLifeTime = 2f;                    // The time in seconds before the shell is removed.
        public float m_ExplosionForce = 1000f;              // The amount of force added to a tank at the centre of the explosion.
        public float m_ExplosionRadius = 5f;                // The maximum distance away from the explosion tanks can be and are still affected.

        public ShellAbility()
        { }

        public virtual void Init(Transform transform, float force)
        {
            m_Shell = Instantiate(m_Shell, transform.position, transform.rotation);
            Rigidbody ShellRigid = m_Shell.GetComponent<Rigidbody>();
            ShellRigid.velocity = transform.forward * force;

        }

        public virtual void Init(Transform transform, float force, float TimeShell)
        { 
            
        }

        public virtual void CalculateDamage()
        { 

        }

    }
}   