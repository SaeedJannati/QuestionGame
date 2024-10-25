using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace QuestionGame.General.Popups
{
    public interface IPopupLogic
    {
        Popup View { get; set; }
        IPopupModel GetConfig();
        AssetReference reference { get; set; }
        void OnClose();
        void Close();


    }

    public interface IPopupModel
    {
    }
}