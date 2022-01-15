using UnityEngine;
using Zenject;
using System;
using QuestionGame.General.Popups;

namespace  QuestionGame.Stage02
{
    [CreateAssetMenu(fileName = "StageTwoModelInstaller", menuName = "Installers/StageTwoModelInstaller")]
    public class StageTwoModelInstaller : ScriptableObjectInstaller<StageTwoModelInstaller>
    {
        [SerializeField] StageTwoModel _config;
        public override void InstallBindings()
        {

            Container.Bind<StageTwoModel>().FromInstance(_config);
        }

  
    }
    [Serializable]
    public class StageTwoModel : IPopupModel
    {
        public Sprite correctSprite;
        public Sprite wrongSprite;
    } 
}
