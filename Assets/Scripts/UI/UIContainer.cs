using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QSTXFrameWork.UI.MVP
{
    using Interface;
    public enum UIVIewID
    {
        MainViewID,
        GameEndViewID,
        MoreInfoViewID,
        HowPlayViewID,
        PauseViewID,
    }
    public class UIContainer : Singleton<UIContainer>, IAppEnter
    {
        private Dictionary<UIVIewID, GameObject> _uiViewPrefabDict;
        private Dictionary<UIVIewID, IView> _uiViewDict;
        private Stack<UIVIewID> _uiViewStack;
        private GameObject _canvasRootObj;
        private GameObject _mainViewObj;
        private GameObject _moreInfoViewObj;
        private GameObject _gameEndViewObj;
        private GameObject _howPlayViewObj;
        private GameObject _pauseViewObj;
        private AudioSource _audioSource;
        public void Register(UIVIewID viewID)
        {
            GameObject viewObj = GameObject.Instantiate(_uiViewPrefabDict[viewID]);
            viewObj.transform.SetParent(_canvasRootObj.transform.GetChild(viewObj.GetComponent<View>().SortLayer),false);
            _uiViewDict.Add(viewID, viewObj.GetComponent<IView>());
        }
        public void UnRegister(UIVIewID viewID)
        {
            GameObject.Destroy((_uiViewDict[viewID] as View).gameObject);
            _uiViewDict.Remove(viewID);
        }
        private void UIPrefabRegister()
        {
            _uiViewPrefabDict.Add(UIVIewID.MainViewID, _mainViewObj);
            _uiViewPrefabDict.Add(UIVIewID.MoreInfoViewID, _moreInfoViewObj);
            _uiViewPrefabDict.Add(UIVIewID.GameEndViewID, _gameEndViewObj);
            _uiViewPrefabDict.Add(UIVIewID.HowPlayViewID, _howPlayViewObj);
            _uiViewPrefabDict.Add(UIVIewID.PauseViewID, _pauseViewObj);
        }
        public void Enter(UIVIewID viewID, bool isPop = false)
        {
            Register(viewID);
            _uiViewDict[viewID].OnViewEnter();
            if (!isPop)
            {
                while (_uiViewStack.Count > 0)
                    Exit(_uiViewStack.Pop());
            }
            _uiViewStack.Push(viewID);
        }
        public void Exit(UIVIewID viewID)
        {
            _uiViewDict[viewID].OnViewExit();
            UnRegister(viewID);
            _uiViewStack.Pop();
            //if (_uiViewStack.Count>0)
            //    Enter(_uiViewStack.Pop(), true);
        }
        public void OnAppEnter()
        {
            _mainViewObj = Resources.Load<GameObject>("UI/MainView");
            _moreInfoViewObj = Resources.Load<GameObject>("UI/MoreInfoView");
            _gameEndViewObj = Resources.Load<GameObject>("UI/GameEndView");
            _howPlayViewObj = Resources.Load<GameObject>("UI/HowPlayView");
            _pauseViewObj = Resources.Load<GameObject>("UI/PauseView");
            _uiViewDict = new Dictionary<UIVIewID, IView>();
            _uiViewPrefabDict = new Dictionary<UIVIewID, GameObject>();
            _uiViewStack = new Stack<UIVIewID>();
            _canvasRootObj = GameObject.Instantiate(Resources.Load<GameObject>("UI/CanvasRoot"));
            GameObject.DontDestroyOnLoad(_canvasRootObj);
            GameObject.DontDestroyOnLoad(GameObject.Instantiate(Resources.Load<GameObject>("UI/EventSystem")));
            UIPrefabRegister();
            _audioSource = new GameObject("UIAudioSource").AddComponent<AudioSource>();
            _audioSource.playOnAwake = false;
            _audioSource.clip = Resources.Load<AudioClip>("Sounds/SFX_UI_Button_Keyboard_Enter_Thick_1");
            _audioSource.loop = false;
            GameObject.DontDestroyOnLoad(_audioSource.gameObject);
        }
        public void UIButtonSoundPlay()
        {
            _audioSource.Play();
        }
    }
}