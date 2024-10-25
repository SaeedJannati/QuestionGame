using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using ModestTree;
using QuestionGame.General.Popups;
using UnityEngine;

namespace QuestionGame.Stage01
{
    public class StageOneView : Popup
    {
        [SerializeField] private RectTransform _panelTransform;
        private void Start()
        {
            ((StageOneLogic) _logic).PlayPopSfx();
            GetIn(null);
        }

        public void GetIn(Action onComplete)
        {
            _panelTransform.anchoredPosition = new Vector2(0, 2000);
            _panelTransform.DOLocalMove(Vector3.zero, .3f).onComplete +=
                () =>
                {
                    onComplete?.Invoke();
                };
        }

        public void GetOut(Action onComplete)
        {
            _panelTransform.anchoredPosition = new Vector2(0, 0);
            _panelTransform.DOLocalMove(new Vector3(0,-2000,0), .3f).onComplete +=
                () =>
                {
                    onComplete?.Invoke();
                };
        }

      

        public void StartClicked()
        {
            GetOut(() => { ((StageOneLogic) _logic).StartClicked(); });
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
            ((StageOneLogic) _logic).PlayCloseSfx();
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
