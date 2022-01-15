using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;
using QuestionGame.Stage01;
using QuestionGame.Stage02;
using UnityEngine.AddressableAssets;
namespace QuestionGame.General.Popups
{
    public class PopupManger
    {
        [SerializeField] private PopUpReferences _config;
        [Inject] public StageOneLogic.Factory stageOneFactory;

        [Inject] public StageTwoLogic.Factory stageTwoFactory;
        //All pop ups being created as a child of this transform
     
        public Transform popupsParent;

        [Inject]
        public PopupManger(PopUpReferences config)
        {
            _config = config;
            Addressables.InitializeAsync();
        }
        public PopUpReferences GetConfig()
        {
            return _config;
        }

        public IPopupLogic RequestPopup(PopupName name)
        {
            var assetReference = (_config.AssetReferences.Find
                (item => item.name == name)).reference;
            var req = Addressables.LoadAssetAsync<GameObject>(assetReference);
            var logic = GetLogicAndReference(name);
            req.Completed += (opration) =>
            {
                logic.reference = assetReference;
                var view = GameObject.Instantiate(req.Result, popupsParent).GetComponent<Popup>();
                view.Logic = logic;
                logic.View = view;
                if (view.Logic == default)
                {
                    view.Close();
                }
                else
                {
                    view.OnCreated();
                }
            };
            return logic;
        }

       

        IPopupLogic GetLogicAndReference(PopupName name)
        {
            switch (name)
            {
                case PopupName.STAGE_01:
                    return stageOneFactory.Create();
                case PopupName.STAGE_02:
                   return stageTwoFactory.Create();
                case PopupName.STAGE_03:
                    // return heroInfoLogicFactory.Create();
                default:
                    return null;
            }
        }
    }

    [Serializable]
    public enum PopupName
    {
        STAGE_01,
        STAGE_02,
        STAGE_03,
    }
}