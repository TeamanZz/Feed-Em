using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonsSFX : MonoBehaviour
{
    public static DragonsSFX Instance;

    public List<AudioClip> chewingList = new List<AudioClip>();
    private AudioSource source;

    public AudioClip dragonSad;

    private void Awake()
    {
        Instance = this;
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ChangePitchValue();
    }

    public void ChangePitchValue()
    {
        StartCoroutine(ChangePitchValueAfterDelay());
    }

    public void PlayChewing()
    {
        source.PlayOneShot(chewingList[Random.Range(0, chewingList.Count)]);
    }

    public void PlaySad()
    {
        source.PlayOneShot(dragonSad);
    }

    private IEnumerator ChangePitchValueAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        source.pitch = Random.Range(0.6f, 1.4f);
    }
}