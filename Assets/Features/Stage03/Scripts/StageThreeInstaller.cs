using UnityEngine;
using Zenject;

namespace QuestionGame.Stage03
{
    public class StageThreeInstaller : Installer<StageThreeInstaller>
    {
        public override void InstallBindings()
        {
            BindFactories();
        }

        void BindFactories()
        {
            Container.BindFactory<StageThreeLogic, StageThreeLogic.Factory>();
        }
    }
}
