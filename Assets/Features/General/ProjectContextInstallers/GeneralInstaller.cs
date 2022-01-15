using QuestionGame.General;
using QuestionGame.General.Popups;
using QuestionGame.Stage02;
using UnityEngine;
using Zenject;

public class GeneralInstaller : MonoInstaller
{
    [SerializeField] private GameManager _gameManager;
    public override void InstallBindings()
    {
        BindInstallers();
        BindGeneralClasses();
        InstallFactories();
    }

     void BindGeneralClasses()
    {
        Container.Bind<PopupManger>().AsSingle();
        Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
    }

     void BindInstallers()
    {
        StageOneInstaller.Install(Container);
        StageTwoInstaller.Install(Container);
    }

     void InstallFactories()
     {
     }
}