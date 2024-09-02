using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class MenuMusic : MonoBehaviour
{
    public AudioSource music;
    public AudioClip intro;
    public AudioClip loop;
    public AudioClip menuStart;
    public AudioClip menuLoop;
    private bool isDead = false;
    private void Start()
    {
        intro.LoadAudioData();
        loop.LoadAudioData();
        menuStart.LoadAudioData();
        menuLoop.LoadAudioData();
        stopStartMusic(true);
    }
    IEnumerator waitForSound()
    {
        while (music.isPlaying)
        {
            yield return null;
        }
        if (!isDead)
        {
            music.clip = loop;
            music.loop = true;
            music.Play();
        }
        if(isDead && music.clip == menuStart)
        {
            music.clip = menuLoop;
            music.loop = true;
            music.Play();
        }
    }
    public void stopStartMusic(bool start)
    {
        if (start)
        {
            isDead = false;
            music.loop = false;
            music.Stop();
            ChangeMusic();
        }
        else
        {
            isDead = true;
            music.loop = false;
            music.Stop();
            DefaultMusic();
        }
    }
    public void DefaultMusic()
    {
        music.clip = menuStart;
        music.Play();
        StartCoroutine(waitForSound());
    }
    public void ChangeMusic()
    {
        music.clip = intro;
        music.Play();
        StartCoroutine(waitForSound());
    }
}
