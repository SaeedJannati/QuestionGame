using System.Collections;
using System.Collections.Generic;
using QuestionGame.General;
using QuestionGame.General.Popups;
using QuestionGame.Stage02;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace QuestionGame.Stage03
{
    public class StageThreeLogic : IPopupLogic
    {
        public Popup View { get; set; }
         StageThreeModel _model;
         private PopupManger _popupManger;
         private GameManager _gameManager;
         private int _correctAnswerCount;
         private int _totalQuestionCount;
         private Sprite _resultSprite;
        [Inject]
        void Construct(PopupManger popupManger, StageThreeModel model,GameManager gameManager)
        {
            _popupManger = popupManger;
            _model = model;
            _gameManager = gameManager;
        }

        public IPopupModel GetConfig()
        {
            return _model;
        }

        public AssetReference reference { get; set; }
        public void OnClose()
        {
            if (reference != null)
                Addressables.Release(reference.Asset);
        }

        public void Close()
        {
            View.Close();
        }

        public void SetQuestionDetails(int correctAnswerCount,int totalQuestionCount)
        {
            _correctAnswerCount = correctAnswerCount;
            _totalQuestionCount = totalQuestionCount;
            var percentage = ((float) _correctAnswerCount / _totalQuestionCount)*100.0f;
            if (percentage > _gameManager.GetGreatJobPercentage())
            {
                _resultSprite = _model.greatJobSprite;
                return;
            }

            if (percentage > _gameManager.GetTerriblePercentage())
            {
                _resultSprite = _model.goodJobSprite;
                return; 
            }

            _resultSprite = _model.terribleSprtie;
        }
        public void StartAgainClicked()
        {
            Close();
            _popupManger.RequestPopup(PopupName.STAGE_02);
        }

        public void Initialize()
        {
            var view = ((StageThreeView) View);
            view.SetResultImage(_resultSprite);
            view.SetTotalQuestion(_totalQuestionCount);
            view.SetCorrectAnswerCount(_correctAnswerCount);
        }

        public class Factory : PlaceholderFactory<StageThreeLogic>
        {
        }

     
    }

}
