using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QSTXFrameWork.UI.MVP.Interface
{
    public interface IAppEnter
    {
        void OnAppEnter();
    }
    public interface IView
    {
        void PreInit();
        void OnViewEnter();
        void OnViewExit();
    }
    public interface IModel
    {
        
    }
    public interface IPresenter
    {

    }
}
