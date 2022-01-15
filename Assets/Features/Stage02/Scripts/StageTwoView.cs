using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using ModestTree;
using QuestionGame.General.Popups;
using UnityEngine;
using QuestionGame.General;
using TMPro;
using UnityEngine.UI;
using Random = System.Random;

namespace QuestionGame.Stage02
{
    public class StageTwoView : Popup
    {
        [SerializeField] private TMP_Text _currenctQuestion;
        [SerializeField] private TMP_Text _totalQuestionCount;
        [SerializeField] private TMP_Text _questionTxt;
        [SerializeField] private List<TMP_Text> _choicesTxts;
        public List<Button> _choicesButtons;
        public bool buttonsInteractable;
        public RectTransform panelTransform;

        public void FillViewWithQuestion(Question question, int currentQuestion)
        {
           GetIn(null);
            _currenctQuestion.text = (currentQuestion + 1).ToString();
            _questionTxt.text = question.question;
            for (int i = 0; i < _choicesTxts.Count; i++)
            {
                _choicesTxts[i].text = question.choices[i].choice;
            }

            buttonsInteractable = true;
        }

        public void GetIn(Action onComplete)
        {
            panelTransform.anchoredPosition = new Vector2(-1000, 0);
            panelTransform.DOLocalMove(Vector3.zero, .3f).onComplete +=
                () =>
                {
                    onComplete?.Invoke();
                };
        }

        public void GetOut(Action onComplete)
        {
            panelTransform.anchoredPosition = new Vector2(0, 0);
            panelTransform.DOLocalMove(new Vector3(1920,0,0), .3f).onComplete +=
                () =>
                {
                    onComplete?.Invoke();
                };
        }

        public void ResteButtonColours(Sprite neutralSprite)
        {
            for (int i = 0; i < _choicesButtons.Count; i++)
            {
                _choicesButtons[i].image.sprite = neutralSprite;
            }
        }

        public void SetTotalQuestionCount(int totalCount)
        {
            _totalQuestionCount.text = totalCount.ToString();
        }

        public void SetButtonColour(int buttonIndex, Sprite sprite)
        {
            _choicesButtons[buttonIndex].image.sprite = sprite;
        }

        public void OscilateButton(int buttonIndex)
        {
            var trnsfrm = _choicesButtons[buttonIndex].transform;
            var sequence = DOTween.Sequence();
            sequence.Append(trnsfrm.DOScale(1.2f, .2f));
            sequence.Append(trnsfrm.DOScale(1f, .2f));
            sequence.Play();
        }

        private void Start()
        {
            ((StageTwoLogic) _logic).Initialize();
        }

        public void ChoiceClicked(int buttonIndex)
        {
            if (!buttonsInteractable)
                return;
            buttonsInteractable = false;
            ((StageTwoLogic) _logic).ChoiceClicked(buttonIndex);
        }

        public override void Close()
        {
            if (isClosing)
                return;
            isClosing = true;
            OnClose();
        }

        public override void OnClose()
        {
            base.OnClose();
            ((StageTwoLogic) _logic).PlayCloseSfx();
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            onCloseAction?.Invoke();
            Logic?.OnClose();
            Logic = null;
            _logic = null;
            Destroy(gameObject);
        }
    }
}