using UnityEngine;
using Zenject;
using System;
using System.Collections.Generic;

namespace  QuestionGame.General
{
    [CreateAssetMenu(fileName = "QuestionsInstaller", menuName = "Installers/QuestionsInstaller")]
    public class QuestionsInstaller : ScriptableObjectInstaller<QuestionsInstaller>
    {
        [SerializeField] private QuestionModel _config;
        public override void InstallBindings()
        {
            Container.Bind<QuestionModel>().FromInstance(_config);
        }
    }
    
    [Serializable]
    public class QuestionModel
    {
        public List<Question> questions;
    }

    [Serializable]
    public class Question
    {
        public string question;
        public List<Choice> choices;
    }

    [Serializable]
    public class Choice
    {
        public string choice;
        public bool isAnswer;
    }
}
