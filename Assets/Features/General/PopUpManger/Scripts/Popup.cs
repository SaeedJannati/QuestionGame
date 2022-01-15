using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestionGame.General.Popups
{
    public abstract class Popup : MonoBehaviour
    {
        #region Fields

        protected bool isClosing;
        [SerializeField] protected Canvas _canvas;
        public Action onCloseAction;

        protected IPopupLogic _logic;

        #endregion

        #region Properties

        public IPopupLogic Logic
        {
            get => _logic;
            set => _logic = value;
        }

        #endregion

        #region Methods

        public virtual void OnCreated()
        {
            isClosing = false;
            _canvas.worldCamera = Camera.main;

        }

        public virtual void OnClose()
        {
            isClosing = true;
        }

        public virtual void Close()
        {
        }

        public virtual void PlayCloseSFX()
        {

        }

        public virtual void DestorySelf()
        {
            Destroy(gameObject);
        }

        public void HideSelf()
        {
            gameObject.SetActive(false);
        }

        public void ShowSelf()
        {
            gameObject.SetActive(true);
        }



        #endregion
    }
}