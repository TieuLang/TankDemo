using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    
    public abstract class GunAbility : ScriptableObject
    {
        public int m_NumBullet = 3;
        public ShellAbility m_ShellType;

        public virtual void Update(FireStyleComp fireStyleComp)
        {
            // Non
        }

        protected virtual void FireOneBullet1(Transform transform, float force)
        {
            //m_ShellType.Init(transform,force);
            var bullet = Instantiate(m_ShellType.m_Shell, transform.position, transform.rotation);
            if (bullet.TryGetComponent<Rigidbody>(out var rigid))
            {
                rigid.velocity = transform.forward * force;
                //rigid.AddForce(fireDir*force);
            }
        }

        protected virtual void FireOneBullet(Vector3 startFirePos, Vector3 fireDir, float force )
        {
            //fireDir = new Vector3(90,0,90);
            Debug.Log("fireDir: "+fireDir.ToString());
            var bullet = Instantiate(m_ShellType.m_Shell, startFirePos, Quaternion.Euler(fireDir));
            if (bullet.TryGetComponent<Rigidbody>(out var rigid))
            {
                rigid.velocity = fireDir * force;
                //rigid.AddForce(fireDir*force);
            }
        }
    }
}