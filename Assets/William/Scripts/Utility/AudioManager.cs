using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{
    ARROW,
    LIGHTNING,
    WEBBLOB,
    SKELETON
    //add more here
}

namespace Code.Scripts.Managers
{
    public class AudioManager : Singleton<AudioManager>
    {
        //TO USE EXAMPLE:  AudioManager.Instance.PlayAudio(AudioType.PLAYERFOOTSTEP);
        [SerializeField] private AudioClip[] audioList;
        [SerializeField] private AudioSource audioSource;

        // Start is called before the first frame update
        void Start()
        {
            //audioSource = GetComponent<AudioSource>();
        }

        public void PlayAudioint(int sound, float volume = 1)
        {
            Instance.audioSource.PlayOneShot(Instance.audioList[sound], volume);
        }
    }
}