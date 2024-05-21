using KBCore.Refs;
using UnityEngine;

namespace UnityUtils.Extensions {

    /// <summary>
    /// Singleton, will destroy any other older components of the same type it finds on awake
    /// </summary>
    public class Singleton<T> : MonoBehaviour where T : Component {
        protected static T instance;

        public static bool HasInstance => instance != null;
        public static T TryGetInstance() => HasInstance ? instance : null;

        public static T Instance {
            get {
                if (instance == null) {
                    instance = FindAnyObjectByType<T>();
                    if (instance == null) {
                        var go = new GameObject(typeof(T).Name + " Auto-Generated");
                        instance = go.AddComponent<T>();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Make sure to call base.Awake() in override if you need awake.
        /// </summary>
        protected virtual void Awake() {
            InitializeSingleton();
        }

        protected virtual void InitializeSingleton() {
            if (!Application.isPlaying) return;

            instance = this as T;
        }
    }

    /// <summary>
    /// Singleton, will destroy any other older components of the same type it finds on awake.
    /// Uses KBCore.Refs ValidatedMonoBehaviour.
    /// </summary>
    public class ValidatedSingleton<T> : ValidatedMonoBehaviour where T : Component {
        protected static T instance;

        public static bool HasInstance => instance != null;
        public static T TryGetInstance() => HasInstance ? instance : null;

        public static T Instance {
            get {
                if (instance == null) {
                    instance = FindAnyObjectByType<T>();
                    if (instance == null) {
                        var go = new GameObject(typeof(T).Name + " Auto-Generated");
                        instance = go.AddComponent<T>();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Make sure to call base.Awake() in override if you need awake.
        /// </summary>
        protected virtual void Awake() {
            InitializeSingleton();
        }

        protected virtual void InitializeSingleton() {
            if (!Application.isPlaying) return;

            instance = this as T;
        }
    }
}
