using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class FaceToDirection : MonoBehaviour
    {
        public Transform m_HealthTransform;
        public Vector3 rotation;
        void Update()
        {
            m_HealthTransform.rotation = Quaternion.Euler(rotation); 
        }
    }
}
