using System.Collections.Generic;
using Utilities.EventBus.EventTypes;
using UnityEngine;

// This code is based on the Unity Event Bus project by Adam Myhre.
// Source: https://github.com/adammyhre/Unity-Event-Bus

namespace Utilities.EventBus
{
    /// <summary>
    /// Represents an event bus that allows registering, deregistering, and raising events of type T.
    /// </summary>
    /// /// <typeparam name="T">The type of event to be handled by the event bus.</typeparam>
    public static class EventBus<T> where T : IEvent
    {
        static readonly HashSet<IEventBinding<T>> bindings = new HashSet<IEventBinding<T>>();

        /// <summary>
        /// Registers an event binding.
        /// </summary>
        /// /// <param name="binding">The event binding to register.</param>
        public static void Register(EventBinding<T> binding) => bindings.Add(binding);
        
        /// <summary>
        /// Deregisters an event binding from the event bus.
        /// </summary>
        /// /// <param name="binding">The event binding to deregister.</param>
        public static void Deregister(EventBinding<T> binding) => bindings.Remove(binding);

        /// <summary>
        /// Raises the specified event by invoking all registered event handlers.
        /// </summary>
        /// <typeparam name="T">The type of the event.</typeparam>
        /// /// <param name="event">The event to raise.</param>
        public static void Raise(T @event)
        {
            foreach (var binding in bindings)
            {
                binding.OnEvent.Invoke(@event);
                binding.OnEventNoArgs.Invoke();
            }
        }

        /// <summary>
        /// Clears all the bindings for the specified event type.
        /// /// </summary>
        static void Clear()
        {
            Debug.Log($"Clearing {typeof(T).Name} bindings");
            bindings.Clear();
        }
    }
}
