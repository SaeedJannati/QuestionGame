using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  QuestionGame.General.AudioSystem
{
    public class SfxObject : MonoBehaviour
    {
        [SerializeField] AudioSource _audioSource;

      
        public void SetAudioClip(AudioClip clip)
        {
            _audioSource.clip = clip;
          StartCoroutine(DisableAfterPlay(clip.length)) ;
            _audioSource.Play();
        }

        IEnumerator DisableAfterPlay(float length)
        {
            yield return  new WaitForSeconds(length);
            gameObject.SetActive(false);
        }
    }
}

