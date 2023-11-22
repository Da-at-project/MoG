using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    AudioSource s;
    void Awake()
    {
        s = GetComponent<AudioSource>();
        s.Play();
    }
}
