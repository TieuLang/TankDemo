using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete
{
    public class Laser : MonoBehaviour
    {
        public LayerMask m_TankMask;                        // Used to filter what the explosion affects, this should be set to "Players".
        public ParticleSystem m_ExplosionParticles;         // Reference to the particles that will play on explosion.
        public AudioSource m_ExplosionAudio;                // Reference to the audio that will play on explosion.
        public GameObject shell;
        public float m_MaxDamage = 2f;                    // The amount of damage done if the explosion is centred on a tank.
        public float m_MaxLifeTime = 2f;                    // The time in seconds before the shell is removed.
        public float m_ExplosionForce = 1000f;              // The amount of force added to a tank at the centre of the explosion.
        public float m_ExplosionRadius = 5f;                // The maximum distance away from the explosion tanks can be and are still affected.
        public float m_MaxDistance;

        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, m_MaxLifeTime);
        }

        // Update is called once per frame
        void Update()
        {
            int mask = 1 << 5;
            mask = ~mask;
            //Debug.Log("3");
            Transform transform = GetComponentInParent<Transform>();
            RaycastHit hit;
            Vector3 rotate = transform.rotation * Vector3.forward;
            rotate.y = 0;
            //Debug.Log("x"+transform.position.ToString());
            Vector3 pos = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            //Debug.Log("y" + pos);
            LineRenderer line = GetComponentInParent<LineRenderer>();
            Vector3[] v = new Vector3[2];
            v[0] = pos;
            if (Physics.Raycast(pos, rotate, out hit, m_MaxDistance, layerMask: mask))
            {
                v[1] = hit.point;
                //return;
            }
            else
            {
                v[1] = pos + rotate*m_MaxDistance;
            }

            //Debug.DrawRay(pos, rotate * hit.distance, Color.green, 10f);
            line.SetPositions(v);
            if (hit.collider != null)
            {
                m_ExplosionParticles.transform.position = hit.point;
                m_ExplosionParticles.Play();
                Debug.Log("run");
                if (hit.collider.CompareTag("Player"))
                {
                    Rigidbody targetRigidbody = hit.collider.GetComponent<Rigidbody>();
                    if (targetRigidbody != null)
                    {
                        TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();
                        if (targetHealth != null) targetHealth.TakeDamage(m_MaxDamage);
                    }

                    // Deal this damage to the tank.
                }
                //Debug.Log(v[1].ToString());
            }
        }
    }
}