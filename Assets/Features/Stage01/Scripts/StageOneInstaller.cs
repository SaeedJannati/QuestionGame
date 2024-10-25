using QuestionGame.Stage01;
using UnityEngine;
using Zenject;

public class StageOneInstaller : Installer<StageOneInstaller>
{
    public override void InstallBindings()
    {
        Container.BindFactory<StageOneLogic, StageOneLogic.Factory>();
    }
    
}