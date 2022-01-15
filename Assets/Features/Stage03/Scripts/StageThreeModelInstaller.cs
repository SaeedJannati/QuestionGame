using System;
using QuestionGame.General.Popups;
using UnityEngine;
using Zenject;

namespace QuestionGame.Stage03
{
    [CreateAssetMenu(fileName = "StageThreeModelInstaller", menuName = "Installers/StageThreeModelInstaller")]
    public class StageThreeModelInstaller : ScriptableObjectInstaller<StageThreeModelInstaller>
    {
        [SerializeField] private StageThreeModel _stageThreeModelModel;
        public override void InstallBindings()
        {
            Container.Bind<StageThreeModel>().FromInstance(_stageThreeModelModel);
        }

      
    }
    [Serializable]
    public class StageThreeModel:IPopupModel
    {
        public Sprite terribleSprtie;
        public Sprite goodJobSprite;
        public Sprite greatJobSprite;
    }
}