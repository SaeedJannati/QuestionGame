using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public void FillViewWithQuestion(Question question, int currentQuestion)
        {
         
            _currenctQuestion.text = (currentQuestion+1).ToString();
            _questionTxt.text = question.question;
            for (int i = 0; i < _choicesTxts.Count; i++)
            {
                _choicesTxts[i].text = question.choices[i].choice;
            }

            buttonsInteractable = true;
        }

        public void ResteButtonColours(Sprite neutralSprite)
        {
            for (int i =0 ; i < _choicesButtons.Count; i++)
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
            OnClose();
        }
        public override void OnClose()
        {
            base.OnClose();
            gameObject.SetActive(false);
           
        }

        private void OnDisable()
        {
            onCloseAction?.Invoke();
            Logic?.OnClose();
            Logic = null;
            _logic = null;
        }
    }
}