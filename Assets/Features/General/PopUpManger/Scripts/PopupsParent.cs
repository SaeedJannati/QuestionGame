using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Zenject;

namespace QuestionGame.General.Popups
{
    public class PopupsParent : MonoBehaviour
    {
        #region Fields

        private PopupManger _popupManager;
        
        #endregion

        #region Injections

        [Inject]
        void Construct(PopupManger popupManager)
        {
            _popupManager = popupManager;
        }

        #endregion

        #region MonoBehaviour events

        private void Start()
        {
            _popupManager.popupsParent = transform;
        }

        #endregion

        #region Methods



        #endregion
    }
}