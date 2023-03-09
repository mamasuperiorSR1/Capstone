using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace QSTXFrameWork.UI.MVP
{
    using Interface;
    public class MainView : View
    {
        public override int SortLayer => 0;
        private Button _startGameBtn;
        private Button _howPlayBtn;
        private Button _moreInfoBtn;
        private Button _quitGameBtn;
        private void Awake()
        {
            PreInit();
        }
        public override void PreInit()
        {
            _startGameBtn = transform.Find("StartGameBtn").GetComponent<Button>();
            _howPlayBtn = transform.Find("HowPlayBtn").GetComponent<Button>();
            _moreInfoBtn = transform.Find("MoreInfoBtn").GetComponent<Button>();
            _quitGameBtn = transform.Find("QuitBtn").GetComponent<Button>();
        }
        public override void OnViewEnter()
        {
            _startGameBtn.onClick.AddListener(StartGame);
            _howPlayBtn.onClick.AddListener(OpenHowPlay);
            _moreInfoBtn.onClick.AddListener(OpenMoreInfo);
            _quitGameBtn.onClick.AddListener(QuitGame);
        }

        public override void OnViewExit()
        {
            _startGameBtn.onClick.RemoveListener(StartGame);
            _howPlayBtn.onClick.RemoveListener(OpenHowPlay);
            _moreInfoBtn.onClick.RemoveListener(OpenMoreInfo);
            _quitGameBtn.onClick.RemoveListener(QuitGame);
        }
        private void StartGame()
        {
            UIContainer.Instance.UIButtonSoundPlay();
            SceneManager.LoadScene("Demo Map");
            UIContainer.Instance.Exit(UIVIewID.MainViewID);
        }
        private void OpenMoreInfo()
        {
            UIContainer.Instance.UIButtonSoundPlay();
            UIContainer.Instance.Enter(UIVIewID.MoreInfoViewID, true);
        }
        private void OpenHowPlay()
        {
            UIContainer.Instance.UIButtonSoundPlay();
            UIContainer.Instance.Enter(UIVIewID.HowPlayViewID, true);
        }
        private void QuitGame()
        {
#if UNITY_EDITOR
            UIContainer.Instance.UIButtonSoundPlay();
            UnityEditor.EditorApplication.isPlaying = false;
#else
            UIContainer.Instance.UIButtonSoundPlay();
            Application.Quit();
#endif
        }
    }
}
