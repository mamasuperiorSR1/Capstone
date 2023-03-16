using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QSTXFrameWork.UI.MVP
{
    using Interface;
    public abstract class Presenter : IPresenter
    {
        protected IView _view;
        protected IModel _model;
    }
}

