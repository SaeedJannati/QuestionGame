using System;
using System.Collections;
using System.Collections.Generic;
using QuestionGame.General.Popups;
using UnityEngine;
using QuestionGame.General;
using TMPro;
using UnityEngine.UI;

namespace  QuestionGame.Stage02
{
    public class StageTwoView : Popup
    {
        [SerializeField] private TMP_Text _currenctQuestion;
        [SerializeField] private TMP_Text _totalQuestionCount;
        [SerializeField] private TMP_Text _questionTxt;
        [SerializeField] private List<TMP_Text> _choicesTxts;
        public List<Button> _choicesButtons;
        public void FillViewWithQuestion(Question question,int currentQuestion)
        {
            _totalQuestionCount.text = (currentQuestion+1).ToString();
            _questionTxt.text = question.question;
            for (int i = 0; i < _choicesTxts.Count; i++)
            {
                _choicesTxts[i].text = question.choices[i].choice;
            }
        }

        private void Start()
        {
           ((StageTwoLogic)_logic).Initialize();
        }

        public void ChoiceClicked(int buttonIndex)
        {
            ((StageTwoLogic)_logic).ChoiceClicked(buttonIndex);
        }
    }
}

