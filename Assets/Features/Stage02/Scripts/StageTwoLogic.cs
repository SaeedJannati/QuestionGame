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
using System.Threading.Tasks;
using DG.Tweening;
using QuestionGame.General.AudioSystem;
using QuestionGame.Stage03;

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
        private int _correctAnswerIndex;
        private int _userCorrectAnswers;
        [Inject] private AudioManager _audioManager;

        [Inject]
        public StageTwoLogic(PopupManger popupManger, StageTwoModel model, QuestionModel questionModel)
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
            ShowNextQuestion();
        }

        void ShowResult()
        {
            var logic = _popupManger.RequestPopup(PopupName.STAGE_03);
            ((StageThreeLogic) logic).SetQuestionDetails(_userCorrectAnswers, _questionCount);
            Close();
        }

        public void PlayPopSfx()
        {
            _audioManager.RequestAudio(ClipName.POP);
        }

        public void PlayCloseSfx()
        {
            _audioManager.RequestAudio(ClipName.DRAG);
        }

        public void PlayCorrectSfx()
        {
            _audioManager.RequestAudio(ClipName.CORRECT);
        }

        public void PlayWrongSfx()
        {
            _audioManager.RequestAudio(ClipName.WRONG);
        }

        void ShowNextQuestion()
        {
            if (_currentQuestionIndex > _questionCount - 1)
            {
               ShowResult();
                return;
            }

            PlayPopSfx();
            var view = ((StageTwoView) View);
            var question = _questions[_currentQuestionIndex];
            var rnd = new System.Random();
            question.choices = question.choices.OrderBy(item => rnd.Next()).ToList();
            _correctAnswerIndex = question.choices.IndexOf(question.choices.FirstOrDefault(item => item.isAnswer));
            view.FillViewWithQuestion(question, _currentQuestionIndex);
            view.ResteButtonColours(_model.neutralSprite);
            view.SetTotalQuestionCount(_questions.Count);
            _currentQuestionIndex++;
        }

        Question GetNewQuestion(List<Question> chosenQuestions)
        {
            var questions = _questionModel.questions.Select(item => item).Where(item => !chosenQuestions.Contains(item))
                .ToList();

            var randomQuestion = questions[Random.Range(0, questions.Count)];
            return randomQuestion;
        }

        public void ChoiceClicked(int chosenIndex)
        {
            var view = ((StageTwoView) View);
            if (chosenIndex == _correctAnswerIndex)
            {
                view.SetButtonColour(chosenIndex, _model.correctSprite);
                view.OscilateButton(chosenIndex);
                _userCorrectAnswers++;
                PlayCorrectSfx();
            }
            else
            {
                view.SetButtonColour(chosenIndex, _model.wrongSprite);
                PlayWrongSfx();
                view.panelTransform.DOShakePosition(.2f, Vector3.one * 20, 20);
                view.SetButtonColour(_correctAnswerIndex, _model.correctSprite);
            }

            ShowNextQuiestionAfterDelay();
        }

        async void ShowNextQuiestionAfterDelay()
        {
            await Task.Delay(_model.periodBetweenQuiestionsInms);
            ((StageTwoView) View).GetOut(ShowNextQuestion);
        }

        public class Factory : PlaceholderFactory<StageTwoLogic>
        {
        }
    }
}