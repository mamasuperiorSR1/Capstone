using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QSTXFrameWork
{
    public class AppLife : Singleton<AppLife>
    {
        private bool _isFirst = true;
        public bool IsFirst
        {
            get
            {
                if (_isFirst)
                {
                    _isFirst = false;
                    return true;
                }
                return false;
            }
        }
    }
}
