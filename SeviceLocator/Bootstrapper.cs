using UnityEngine;
using Utilities.Extensions;

// This code is based on the Unity Service Locator project by Adam Myhre.
// Source: https://github.com/adammyhre/Unity-Service-Locator

namespace Utilities.UnityServiceLocator {
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ServiceLocator))]
    public abstract class Bootstrapper : MonoBehaviour {
        ServiceLocator container;
        internal ServiceLocator Container => container.OrNull() ?? (container = GetComponent<ServiceLocator>());
        
        bool hasBeenBootstrapped;

        void Awake() => BootstrapOnDemand();
        
        /// <summary>
        /// Bootstraps the application if it hasn't been bootstrapped already.
        /// </summary>
        public void BootstrapOnDemand() {
            if (hasBeenBootstrapped) return;
            hasBeenBootstrapped = true;
            Bootstrap();
        }
        
        protected abstract void Bootstrap();
    }

    // context menu items
    [AddComponentMenu("ServiceLocator/ServiceLocator Global")]
    public class ServiceLocatorGlobal : Bootstrapper {
        [SerializeField] bool dontDestroyOnLoad = true;
        
        protected override void Bootstrap() {
            Container.ConfigureAsGlobal(dontDestroyOnLoad);
        }
    }
    
    [AddComponentMenu("ServiceLocator/ServiceLocator Scene")]
    public class ServiceLocatorScene : Bootstrapper {
        protected override void Bootstrap() {
            Container.ConfigureForScene();            
        }
    }
}