using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QuestionGame.General;
using QuestionGame.General.Popups;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;
using QuestionGame.General;
using QuestionGame.Stage01;
using Random = UnityEngine.Random;

namespace QuestionGame.Stage02
{
    public class StageTwoLogic : IPopupLogic
    {
        private PopupManger _popupManger;
        private StageTwoModel _model;
        private QuestionModel _questionModel;
        [Inject] private GameManager _gameManager;
        private int _questionCount;
        private List<Question> _questions;
        private int _currentQuestionIndex;
        [Inject]
        public  StageTwoLogic(PopupManger popupManger,StageTwoModel model,QuestionModel questionModel)
        {
            _popupManger = popupManger;
            _model = model;
            _questionModel = questionModel;
        }

        public Popup View { get; set; }
        public IPopupModel GetConfig()
        {
            return _model;
        }

        public AssetReference reference { get; set; }
        public void OnClose()
        {
            if (reference != null)
                Addressables.Release(reference.Asset);
        }

        public void Close()
        {
            View.Close();
        }

        public void Initialize()
        {
            _questionCount = _gameManager.GetQuestionCount();
            _questions = new List<Question>();
            for (int i = 0; i < _questionCount; i++)
            {
                _questions.Add(GetNewQuestion(_questions));
            }

            _currentQuestionIndex = 0;
            if (!ShowNextQuestion())
            {
                ShowResult();
            }

        }

        void ShowResult()
        {
            _popupManger.RequestPopup(PopupName.STAGE_03);
        }

        bool ShowNextQuestion()
        {
            _currentQuestionIndex++;
            if (_currentQuestionIndex > _questionCount - 1)
                return false;

            ((StageTwoView) View).FillViewWithQuestion(_questions[_currentQuestionIndex],_currentQuestionIndex);
            return true;
        }

        Question GetNewQuestion(List<Question> chosenQuestions)
        {
          var questions= _questionModel.questions.
              Select(item=> item ).
              Where(item=>!chosenQuestions.Contains(item)).ToList();

          var randomQuestion = questions[Random.Range(0, questions.Count)];
          return randomQuestion;
        }

        public void ChoiceClicked(int chosenIndex)
        {
            Debug.Log(chosenIndex);
        }

        public class Factory:PlaceholderFactory<StageTwoLogic>
        {   
        }
    }
}

