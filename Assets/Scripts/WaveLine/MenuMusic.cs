using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class MenuMusic : MonoBehaviour
{
    public AudioSource intro;
    public AudioClip loop;
    private bool isDead = false;
    private void Start()
    {
        loop.LoadAudioData();
    }
    IEnumerator waitForSound()
    {
        while (intro.isPlaying)
        {
            yield return null;
        }
        if (!isDead)
        {
            intro.clip = loop;
            intro.loop = true;
            intro.Play();
        }
    }
    public void stopStartMusic(bool start)
    {
        if (start)
        {
            isDead = false;
            intro.Play();
            StartCoroutine(waitForSound());
        }
        else
        {
            isDead=true;
            intro.Stop();
        }
    }
}
