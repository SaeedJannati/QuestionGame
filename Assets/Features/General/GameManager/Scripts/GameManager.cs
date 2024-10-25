using System;
using System.Collections;
using System.Collections.Generic;
using QuestionGame.General.Popups;
using UnityEngine;
using Zenject;

namespace  QuestionGame.General
{
    public class GameManager : MonoBehaviour
    {
        private PopupManger _popupManger;
        private GameMangerModel _model;
        [Inject]
        void Construct(PopupManger popupManger,GameMangerModel model)
        {
            _popupManger = popupManger;
            _model =model;
        }

        IEnumerator  Start()
        {
            yield return null;
            _popupManger.RequestPopup(PopupName.STAGE_01);
        }

        public int GetQuestionCount()
        {
            return _model.questionsCount;
        }

        public int GetTerriblePercentage()
        {
            return _model.terribleCriterianPercentage;
        }

        public int GetGreatJobPercentage()
        {
            return _model.greatJobCriterianPercentage;
        }
    }  
}

