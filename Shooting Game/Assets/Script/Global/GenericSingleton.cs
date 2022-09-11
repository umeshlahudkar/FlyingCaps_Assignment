using UnityEngine;

namespace Shooter.Global
{
    public class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
    {
        private static T instance;
        public static T Instance { get { return instance; } }

        public void Awake()
        {
            if (instance == null)
            {
                instance = (T)this;
            }
            else
            {
                Destroy(this);
            }
        }
    }
}


