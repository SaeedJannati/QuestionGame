using System.Collections;
using System.Collections.Generic;
using QuestionGame.General.Popups;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace QuestionGame.Stage01
{
    public class StageOneLogic : IPopupLogic
    {
        private PopupManger _popupManger;

        [Inject]
        public  StageOneLogic(PopupManger popupManger)
        {
            _popupManger = popupManger;
        }

        public Popup View { get; set; }
        public IPopupModel GetConfig()
        {
            return default;
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

        public void StartClicked()
        {
            _popupManger.RequestPopup(PopupName.STAGE_02);
            Close();
        }
        
        public class Factory:PlaceholderFactory<StageOneLogic>
        {   
        }
    }
}
