using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry_FinishLineSound : MonoBehaviour
{
    [SerializeField] private AudioClip sound3;
    AudioSource audioSource;

    public void reachFinishLine()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound3);
    }
}
