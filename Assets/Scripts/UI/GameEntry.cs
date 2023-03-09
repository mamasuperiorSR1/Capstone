using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QSTXFrameWork;
using QSTXFrameWork.UI.MVP;
using QSTXFrameWork.UI.MVP.Interface;
public class GameEntry : MonoBehaviour
{
    private List<IAppEnter> _appEnterCollection = new List<IAppEnter> { UIContainer.Instance as IAppEnter};
    private void Awake()
    {
        if(AppLife.Instance.IsFirst)
            foreach (IAppEnter i in _appEnterCollection)
                i.OnAppEnter();
    }
    void Start()
    {
        UIContainer.Instance.Enter(UIVIewID.MainViewID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
