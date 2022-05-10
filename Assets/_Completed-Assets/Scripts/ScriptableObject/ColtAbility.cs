using UnityEngine;

namespace Complete
{
    [CreateAssetMenu(menuName = "Abilities/ColtAbility")]
    public class ColtAbility : GunAbility
    {
        public float m_TimeShell = 0f;
        public override void DoUpdate(FireStyleComp fireStyleComp)
        {
            base.DoUpdate(fireStyleComp);
            var firestyleComp = fireStyleComp as WaveFireStyle;
            firestyleComp.currentInterval -= Time.deltaTime;
            if (firestyleComp.currentInterval <= 0)
            {
                FireOneBullet1(fireStyleComp.FireTranPos);
                firestyleComp.bulletFired++;
                firestyleComp.currentInterval = m_TimeShell;
            }

            if (fireStyleComp.bulletFired >= m_NumBullet)
                firestyleComp.OnDoneTrigger();
        }
    }
}