using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
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
        [SerializeField] private CanvasGroup _canvasGroup;
        private void Start()
        {
            GetIn(null);
            ((StageThreeLogic) _logic).Initialize();
        }

        public void SetResultImage(Sprite sprite)
        {
            _resultImage.sprite = sprite;
        }
        public void GetIn(Action onComplete)
        {
            _canvasGroup.alpha = 0.0f;
            _canvasGroup.DOFade(1.0f, .3f).onComplete +=
                () =>
                {
                    onComplete?.Invoke();
                };
        }

        public void GetOut(Action onComplete)
        {
            _canvasGroup.alpha = 1.0f;
            _canvasGroup.DOFade(0.0f, .3f).onComplete +=
                () =>
                {
                    onComplete?.Invoke();
                };
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
            isClosing = true;
            GetOut(OnClose);
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
            Destroy(gameObject);
        }

        public void StartAgainClicked()
        {
            ((StageThreeLogic) _logic).StartAgainClicked();
        }
    }
}

