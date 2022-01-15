using System;
using System.Collections;
using System.Collections.Generic;
using ModestTree;
using QuestionGame.General.Popups;
using UnityEngine;

namespace QuestionGame.Stage01
{
    public class StageOneView : Popup
    {
        public void StartClicked()
        {
           ((StageOneLogic) _logic).StartClicked(); 
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
