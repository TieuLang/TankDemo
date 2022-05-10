using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSoundComp : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update
    public void OnPlaySound()
    {
        source.PlayOneShot(clip);
    }
}
