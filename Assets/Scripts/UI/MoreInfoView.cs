using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QSTXFrameWork.UI.MVP
{
    using Interface;
    public class MoreInfoView : View
    {
        public override int SortLayer => 1;
        private Button _yesBtn;
        private void Awake()
        {
            PreInit();
        }
        public override void PreInit()
        {
            _yesBtn = transform.Find("Panel/Text (TMP)/Button").GetComponent<Button>();
        }
        public override void OnViewEnter()
        {
            _yesBtn.onClick.AddListener(OnYes);
        }
        public override void OnViewExit()
        {
            _yesBtn.onClick.RemoveListener(OnYes);
        }
        private void OnYes()
        {
            UIContainer.Instance.UIButtonSoundPlay();
            UIContainer.Instance.Exit(UIVIewID.MoreInfoViewID);
        }
    }
}