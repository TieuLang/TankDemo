using UnityEngine;

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
        public float force = 10;

        public void Update()
        {
            //Debug.Log("IsReady: "+IsReady.ToString());
            if (!IsReady)
            {
                //Debug.Log("Start fired");
                gunAbility.Update(this);
            }
        } 

        public void OnGunFireTrigger()
        {
            if (!IsReady && currentReloadTime > 0)
                return;
            IsReady = false;
            currentReloadTime = reloadTime;
            bulletFired = 0;
            //Debug.Log("reload");
        }

        public virtual void OnDoneTrigger()
        {
            //bulletFired = 0;
            IsReady = true;
            //Debug.Log("readly when done: " + IsReady.ToString());
        }
    }
}