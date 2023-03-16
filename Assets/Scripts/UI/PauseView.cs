using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace QSTXFrameWork.UI.MVP
{
    public class PauseView : View
    {
        public override int SortLayer => 1;
        private Button _continueBtn;
        private Button _quitBtn;
        private void Awake()
        {
            PreInit();
        }
        public override void PreInit()
        {
            _continueBtn = transform.Find("ContinueBtn").GetComponent<Button>();
            _quitBtn = transform.Find("QuitBtn").GetComponent<Button>();
        }
        public override void OnViewEnter()
        {
            _continueBtn.onClick.AddListener(ContinueGame);
            _quitBtn.onClick.AddListener(QuitGame);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }

        public override void OnViewExit()
        {
            _continueBtn.onClick.RemoveListener(ContinueGame);
            _quitBtn.onClick.RemoveListener(QuitGame);
            Time.timeScale = 1;
        }
        private void ContinueGame()
        {
            UIContainer.Instance.UIButtonSoundPlay();
            UIContainer.Instance.Exit(UIVIewID.PauseViewID);
            Cursor.lockState = CursorLockMode.Locked;
        }
        private void QuitGame()
        {
            UIContainer.Instance.UIButtonSoundPlay();
            SceneManager.LoadScene("MainScene");
            UIContainer.Instance.Exit(UIVIewID.PauseViewID);
        }
    }
}