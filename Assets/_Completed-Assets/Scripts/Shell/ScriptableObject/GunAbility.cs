using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    
    public abstract class GunAbility : ScriptableObject
    {
        public int m_NumBullet = 3;
        public ShellAbility m_ShellType;
        public float bulletStartSpeed = 3;

        public virtual void DoUpdate(FireStyleComp fireStyleComp)
        {
            // Non
        }

        protected virtual void FireOneBullet1(Transform transform)
        {
            var bullet = Instantiate(m_ShellType.m_Shell, transform.position, transform.rotation);
            if (bullet.TryGetComponent<Rigidbody>(out var rigid))
                rigid.velocity = transform.forward * bulletStartSpeed;
        }

        protected virtual void FireOneBullet(Vector3 startFirePos, Vector3 fireDir)
        {
            var bullet = Instantiate(m_ShellType.m_Shell, startFirePos, Quaternion.Euler(fireDir));
            if (bullet.TryGetComponent<Rigidbody>(out var rigid))
                rigid.velocity = fireDir * bulletStartSpeed;
        }
    }
}