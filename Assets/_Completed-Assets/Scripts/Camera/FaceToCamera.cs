using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class FaceToCamera : MonoBehaviour
    {
        public Transform m_HealthTransform;
        public Transform m_Target;
        // Start is called before the first frame update
        void Start()
        {
            m_Target = Camera.main.transform;
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log("camera "+ m_Target != null);
            if (m_Target!=null) m_HealthTransform.LookAt(m_Target);
        }
    }
}
