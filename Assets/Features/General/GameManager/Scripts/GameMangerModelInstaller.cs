using System;
using UnityEngine;
using Zenject;

namespace QuestionGame.General
{
    [CreateAssetMenu(fileName = "GameMangerModelInstaller", menuName = "Installers/GameMangerModelInstaller")]

    public class GameMangerModelInstaller : ScriptableObjectInstaller<GameMangerModelInstaller>
    {
        [SerializeField] private GameMangerModel _config;

        public override void InstallBindings()
        {
            Container.Bind<GameMangerModel>().FromInstance(_config);
        }


    }

    [Serializable]
    public class GameMangerModel
    {
        public int questionsCount;
        public int terribleCriterianPercentage;
        public int greatJobCriterianPercentage;
    }
}