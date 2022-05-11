using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simpled3DSoundComp : MonoBehaviour
{
    public AudioClip clip;
    public void OnPlaySound()
    {
        AudioSource.PlayClipAtPoint(clip,Vector3.zero);
    }

    public void OnPlaySound(AudioClip _clip)
    {
        AudioSource.PlayClipAtPoint(_clip, Vector3.zero);
    }
}
