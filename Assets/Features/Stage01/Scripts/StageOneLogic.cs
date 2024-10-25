using System.Collections;
using System.Collections.Generic;
using QuestionGame.General.AudioSystem;
using QuestionGame.General.Popups;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace QuestionGame.Stage01
{
    public class StageOneLogic : IPopupLogic
    {
        private PopupManger _popupManger;
        private AudioManager _audioManager;

        [Inject]
        public  StageOneLogic(PopupManger popupManger,AudioManager audioManager )
        {
            _popupManger = popupManger;
            _audioManager = audioManager;
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

        public void PlayPopSfx()
        {
            _audioManager.RequestAudio(ClipName.POP);
        }
        public void   PlayCloseSfx()
        {
            _audioManager.RequestAudio(ClipName.DRAG);
        }
        public class Factory:PlaceholderFactory<StageOneLogic>
        {   
        }
    }
}
