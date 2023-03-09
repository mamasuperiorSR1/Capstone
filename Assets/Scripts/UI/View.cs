using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QSTXFrameWork.UI.MVP
{
    using Interface;
    public abstract class View : MonoBehaviour, IView
    {
        public virtual int SortLayer
        {
            get;
        }
        protected IPresenter _presenter;

        public abstract void PreInit();

        public abstract void OnViewEnter();

        public abstract void OnViewExit();
    }
}

