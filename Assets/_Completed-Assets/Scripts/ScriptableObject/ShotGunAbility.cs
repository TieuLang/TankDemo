using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    [CreateAssetMenu(menuName = "Abilities/ShotGunAbility")]
    public class ShotGunAbility : GunAbility
    {
        public float m_Range = 120;
        public override void Update(FireStyleComp fireStyleComp)
        {
            base.Update(fireStyleComp);
            var firestyleComp = fireStyleComp as ShotGunFireStyle;

            //FireOneBullet(firestyleComp.FireTranPos.position, firestyleComp.FireTranPos.rotation.eulerAngles, firestyleComp.force);
            float RangeBullet = m_Range / m_NumBullet;
            for (int i=0;i<m_NumBullet ;++i)
            {
                
                Transform tmp = Instantiate(firestyleComp.FireTranPos);
                tmp.position = fireStyleComp.FireTranPos.position;
                tmp.rotation = fireStyleComp.FireTranPos.rotation;
                tmp.Rotate((new Vector3(0, -m_Range/2+i* RangeBullet, 0)));
                Debug.Log(i+" "+tmp.rotation.ToString());
                FireOneBullet1(tmp, firestyleComp.force);
                firestyleComp.bulletFired++;
                // if (fireStyleComp.bulletFired >= m_NumBullet) break;
                Destroy(tmp.gameObject);
            }

            if (fireStyleComp.bulletFired >= m_NumBullet)
                firestyleComp.OnDoneTrigger();
        }

        protected override void FireOneBullet1(Transform transform, float force)
        {
            base.FireOneBullet1(transform, force);
        }

        //public override void Fire(Transform transform, float force)
        //{
        //    ShellAbility[] fired_shell = new ShellAbility[m_NumBullet];
        //    for (int i=0;i<fired_shell.Length;++i)
        //    {
        //        fired_shell[i] = Instantiate(m_ShellType);
        //        Transform tf = transform;
        //        fired_shell[i].Init(transform, force*(1+i));
        //    }
        //}
    }
}
