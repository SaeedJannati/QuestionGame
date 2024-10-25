using UnityEngine;
using Zenject;

namespace QuestionGame.Stage02
{
    public class StageTwoInstaller : Installer<StageTwoInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<StageTwoLogic,StageTwoLogic.Factory>();
        }
    }
}
