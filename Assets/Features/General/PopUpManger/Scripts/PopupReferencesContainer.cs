using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace QuestionGame.General.Popups
{
    [CreateAssetMenu(fileName = "PopupReferencesContainer", menuName = "Installers/PopupReferencesContainer")]
    public class PopupReferencesContainer : ScriptableObjectInstaller<PopupReferencesContainer>
    {
        [SerializeField] private PopUpReferences _references;

        public override void InstallBindings()
        {
            Container.Bind<PopUpReferences>().FromInstance(_references).AsSingle();
        }
    }

    [Serializable]
    public class PopUpReferences
    {
      
        public List<PopupReferences> AssetReferences;
    }


    [Serializable]
    public class PopupReferences
    {
        public string Name;
        public PopupName name;
        public AssetReference reference;
    }
}