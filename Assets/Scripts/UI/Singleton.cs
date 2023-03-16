using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QSTXFrameWork
{
    public class Singleton<T> where T : Singleton<T>, new()
    {
        private static T _instance;
        private static object _locker = new object();
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if (_instance == null)
                            _instance = new T();
                    }
                }
                return _instance;
            }
        }
    }
}

