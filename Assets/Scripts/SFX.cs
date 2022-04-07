using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public static SFX Instance;

    public List<AudioClip> soundsList = new List<AudioClip>();
    private AudioSource source;

    private void Awake()
    {
        Instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlayCurrencyIncrease()
    {
        source.PlayOneShot(soundsList[0]);
    }

    public void PlayBuy()
    {
        source.PlayOneShot(soundsList[1]);
    }
}