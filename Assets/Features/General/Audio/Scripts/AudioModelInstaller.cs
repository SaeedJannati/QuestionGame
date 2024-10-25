using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace QuestionGame.General.AudioSystem
{
    [CreateAssetMenu(fileName = "AudioModelInstaller", menuName = "Installers/AudioModelInstaller")]
    public class AudioModelInstaller : ScriptableObjectInstaller<AudioModelInstaller>
    {
        [SerializeField] AudioModel _audioModel;
        public override void InstallBindings()
        {
            Container.Bind<AudioModel>().FromInstance(_audioModel);
        }
    }

    [Serializable]
    public class AudioModel
    {
        public List<ClipData> clipsInfo;
        public GameObject sfxPrefab;
    }

    [Serializable]
    public class ClipData
    {
        public string name;
        public ClipName clipName;
        public AudioClip clip;
    }

    [Serializable]
    public enum ClipName
    {
        CORRECT,
        WRONG,
        POP,
        DRAG
    }
}
