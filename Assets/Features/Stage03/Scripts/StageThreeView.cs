using System;
using System.Collections;
using System.Collections.Generic;
using QuestionGame.General.Popups;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuestionGame.Stage03
{
    public class StageThreeView : Popup
    {
        [SerializeField] private Image _resultImage;
        [SerializeField] private TMP_Text _totalQuestionCount;
        [SerializeField] private TMP_Text _correctAnswerCount;

        private void Start()
        {
            ((StageThreeLogic) _logic).Initialize();
        }

        public void SetResultImage(Sprite sprite)
        {
            _resultImage.sprite = sprite;
        }

        public void SetTotalQuestion(int count)
        {
            _totalQuestionCount.text = count.ToString();
        }

        public void SetCorrectAnswerCount(int count)
        {
            _correctAnswerCount.text=count.ToString();
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

        public void StartAgainClicked()
        {
            ((StageThreeLogic) _logic).StartAgainClicked();
        }
    }
}

