using UnityEngine;

namespace ProjectBase.Base
{
    public class SingletonMono<T> : MonoBehaviour where T:MonoBehaviour
    {
        private static T instance;

        public static T GetInstance()
        {
            return instance;
        }

        protected virtual void Awake()
        {
            instance = this as T;
        }
    }
}
