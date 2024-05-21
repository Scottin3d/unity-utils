using System;
using System.Collections.Generic;
using UnityEngine;

// This code is based on the Unity Service Locator project by Adam Myhre.
// Source: https://github.com/adammyhre/Unity-Service-Locator

namespace Utilities.UnityServiceLocator {
    public class ServiceManager {
        readonly Dictionary<Type, object> services = new Dictionary<Type, object>();
        public IEnumerable<object> RegisteredServices => services.Values;
        
        public bool TryGet<T>(out T service) where T : class {
            Type type = typeof(T);
            if (services.TryGetValue(type, out object obj)) {
                service = obj as T;
                return true;
            }

            service = null;
            return false;
        }

        /// <summary>
        /// Retrieves an instance of the specified type from the service locator.
        /// </summary>
        /// <typeparam name="T">The type of the service to retrieve.</typeparam>
        /// <returns>An instance of the specified service type.</returns>
        /// <exception cref="ArgumentException">Thrown when the service of the specified type is not registered.</exception>
        public T Get<T>() where T : class {
            Type type = typeof(T);
            if (services.TryGetValue(type, out object obj)) {
                return obj as T;
            }
            
             throw new ArgumentException($"ServiceManager.Get: Service of type {type.FullName} not registered");
        }

        /// <summary>
        /// Registers a service with the service locator.
        /// </summary>
        /// <typeparam name="T">The type of service to register.</typeparam>
        /// <param name="service">The service to register.</param>
        /// <returns>The ServiceManager instance after registering the service.</returns>
        public ServiceManager Register<T>(T service) {
            Type type = typeof(T);
            
            if (!services.TryAdd(type, service)) {
                Debug.LogError($"ServiceManager.Register: Service of type {type.FullName} already registered");
            }
            
            return this;
        }

        /// <summary>
        ///  Registers a service with the service locator.
        /// </summary>
        /// <param name="type">The type to use for registration.</param>
        /// <param name="service">The service to register.</param>
        /// <returns>The ServiceManager instance after registering the service.</returns>
        /// <exception cref="ArgumentException">Thrown when the type of the service does not match the type of the service interface.</exception>
        public ServiceManager Register(Type type, object service) {
            if (!type.IsInstanceOfType(service)) {
                throw new ArgumentException("Type of service does not match type of service interface", nameof(service));
            }
            
            if (!services.TryAdd(type, service)) {
                Debug.LogError($"ServiceManager.Register: Service of type {type.FullName} already registered");
            }
            
            return this;
        }
    }
}