using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Moves")]
    public SfxClip[] moveClips;

    [Header("Death")]
    public AudioClip death;

    [Header("Money")]
    public float volumeMoney;
    public AudioClip[] moneyClip;
    new AudioSource audio;

    public static AudioManager Instance;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        audio = GetComponent<AudioSource>();
    }

    public void PlaySound(MoveType move)
    {
        foreach(SfxClip sfx in moveClips)
        {
            if (sfx.move == move)
            {
                audio.PlayOneShot(sfx.clip, sfx.volume);
                return;
            }
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audio.PlayOneShot(clip);
    }

    public void PlayDeathSound()
    {
        audio.PlayOneShot(death);
    }

    public void PlayMoneyClip()
    {
        audio.PlayOneShot(moneyClip[Random.Range(0, moneyClip.Length)], volumeMoney);
    }

    [System.Serializable]
    public struct SfxClip
    {
        public MoveType move;
        public AudioClip clip;
        public float volume;
    }
}
