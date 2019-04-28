using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathing : MonoBehaviour
{
    new AudioSource audio;
    public static Breathing Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audio.time = Random.Range(0, audio.clip.length);
    }

    public static void Stop()
    {
        Instance.audio.Stop();
    }
}
