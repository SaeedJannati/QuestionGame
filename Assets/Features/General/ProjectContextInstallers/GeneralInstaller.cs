using QuestionGame.General;
using QuestionGame.General.AudioSystem;
using QuestionGame.General.Popups;
using QuestionGame.Stage02;
using QuestionGame.Stage03;
using UnityEngine;
using Zenject;

public class GeneralInstaller : MonoInstaller
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private AudioManager _audioManager;
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
        Container.Bind<AudioManager>().FromInstance(_audioManager).AsSingle();
    }

     void BindInstallers()
    {
        StageOneInstaller.Install(Container);
        StageTwoInstaller.Install(Container);
        StageThreeInstaller.Install(Container);
    }

     void InstallFactories()
     {
     }
}