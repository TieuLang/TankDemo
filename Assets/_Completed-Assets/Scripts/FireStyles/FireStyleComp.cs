using System;
using UnityEngine;
using UnityEngine.Events;

namespace Complete
{
    public abstract class FireStyleComp : MonoBehaviour
    {
        [SerializeField]
        private GunAbility gunAbility;
        [SerializeField]
        private float reloadTime = 1;
        private float currentReloadTime = 0;
        internal int bulletFired  = 0;
        internal bool IsReady = true;
        public Transform FireTranPos;

        public UnityEvent OnTriggerEvent;
        public UnityEvent OnFinishTriggerEvent;

        public void InitWeapon(Transform FireTranPos)
        {
            this.FireTranPos = FireTranPos;
        }

        public void Update()
        {
            if (!IsReady)
                gunAbility.DoUpdate(this);
        }

        public void OnGunFireTrigger()
        {
            if (!IsReady && currentReloadTime > 0)
                return;
            IsReady = false;
            currentReloadTime = reloadTime;
            bulletFired = 0;
            OnTriggerEvent?.Invoke();
        }


        public virtual void OnDoneTrigger()
        {
            IsReady = true;
            OnFinishTriggerEvent?.Invoke();
        }
    }

}