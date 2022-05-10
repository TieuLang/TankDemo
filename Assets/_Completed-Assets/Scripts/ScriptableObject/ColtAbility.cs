using UnityEngine;

namespace Complete
{
    [CreateAssetMenu(menuName = "Abilities/ColtAbility")]
    public class ColtAbility : GunAbility
    {
        public float m_TimeShell = 0f;
        public WaveFireStyle FireStyleComp;

        //public override void Fire(Transform transform, float force)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public override void Fire(Transform transform, float force)
        //{
        //    //for (int i = fired_shell.Length-1; i>-1; --i)
        //    //{
        //    //    fired_shell[i] = Instantiate(m_ShellType);
        //    //    Transform tf = Instantiate(transform);
        //    //    tf.position = transform.position;
        //    //    tf.rotation = transform.rotation;
        //    //    Vector3 rotate = (tf.rotation * (Vector3.forward));
        //    //    Vector3 pos = new Vector3(tf.position.x, tf.position.y, tf.position.z);
        //    //    pos = pos + rotate * m_TimeShell *i;
        //    //    tf.position = pos;
        //    //    tf.position=new Vector3(tf.position.x, transform.position.y, tf.position.z);
        //    //    fired_shell[i].Init(tf, force);
        //    //    Destroy(tf.gameObject);
        //    //}
        //}

        public override void Update(FireStyleComp fireStyleComp)
        {
            base.Update(fireStyleComp);
            var firestyleComp = fireStyleComp as WaveFireStyle;
            firestyleComp.currentInterval -= Time.deltaTime;
            if (firestyleComp.currentInterval <= 0)
            {
                //FireOneBullet(firestyleComp.FireTranPos.position, firestyleComp.FireTranPos.rotation.eulerAngles, firestyleComp.force);

                FireOneBullet1(fireStyleComp.FireTranPos, firestyleComp.force);
                firestyleComp.bulletFired++;
                firestyleComp.currentInterval = m_TimeShell;
            }

            if (fireStyleComp.bulletFired >= m_NumBullet)
                firestyleComp.OnDoneTrigger();
        }

        protected override void FireOneBullet1(Transform transform, float force)
        {
            base.FireOneBullet1(transform, force);
        }

        protected override void FireOneBullet(Vector3 startFirePos, Vector3 fireDir, float force)
        {
            base.FireOneBullet(startFirePos, fireDir, force);
        }
    }
}