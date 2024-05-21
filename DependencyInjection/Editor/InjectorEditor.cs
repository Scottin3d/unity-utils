using UnityEditor;
using UnityEngine;

// This code is based on the Unity Dependency Injection Lite project by Adam Myhre.
// Source: https://github.com/adammyhre/Unity-Dependency-Injection-Lite

namespace Utilities.DependencyInjection.Editor  {
#if UNITY_EDITOR
    [CustomEditor(typeof(Injector))]
    public class InjectorEditor : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();

            Injector injector = (Injector) target;

            if (GUILayout.Button("Validate Dependencies")) {
                injector.ValidateDependencies();
            }

            if (GUILayout.Button("Clear All Injectable Fields")) {
                injector.ClearDependencies();
                EditorUtility.SetDirty(injector);
            }
        }
    }
#endif
}