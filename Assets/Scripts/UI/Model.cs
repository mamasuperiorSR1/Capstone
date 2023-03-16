using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QSTXFrameWork.UI.MVP
{
    using Interface;
    public abstract class Model : IModel
    {
        protected IPresenter _presenter;
    }
}
