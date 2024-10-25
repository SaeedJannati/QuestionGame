using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace  QuestionGame.General.AudioSystem
{
    public class AudioManager : MonoBehaviour
    {
        [Inject] private AudioModel _model;
        private Transform _transform;
        private void Start()
        {
            _transform = transform;
        }

        public void RequestAudio(ClipName name)
        {
            if (ObjectPool.Instantiate
                    (_model.sfxPrefab,_transform ).TryGetComponent(out SfxObject sfx)
            )
            {
                
                sfx.SetAudioClip(
                    _model.clipsInfo.FirstOrDefault(item=>item.clipName==name)?.clip
                    );
            }
        }
    }
}

