using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace QSTXFrameWork.UI.MVP
{
    using Interface;
    public class GameEndView : View
    {
        public override int SortLayer => 2;
        private Button _playAgainBtn;
        private Button _back2MenuBtn;
        private void Awake()
        {
            PreInit();
        }
        public override void PreInit()
        {
            _playAgainBtn = transform.Find("PlayAgainBtn").GetComponent<Button>();
            _back2MenuBtn = transform.Find("BackBtn").GetComponent<Button>();
        }
        public override void OnViewEnter()
        {
            _playAgainBtn.onClick.AddListener(PlayAgain);
            _back2MenuBtn.onClick.AddListener(Back2Menu);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        public override void OnViewExit()
        {
            _playAgainBtn.onClick.RemoveListener(PlayAgain);
            _back2MenuBtn.onClick.RemoveListener(Back2Menu);
            Time.timeScale = 1;
        }
        private void PlayAgain()
        {
            UIContainer.Instance.UIButtonSoundPlay();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            UIContainer.Instance.Exit(UIVIewID.GameEndViewID);
        }
        private void Back2Menu()
        {
            UIContainer.Instance.UIButtonSoundPlay();
            SceneManager.LoadScene("MainScene");
            UIContainer.Instance.Exit(UIVIewID.GameEndViewID);
        }
    }
}
