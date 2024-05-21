using System;
using Utilities.EventBus.EventTypes;

// This code is based on the Unity Event Bus project by Adam Myhre.
// Source: https://github.com/adammyhre/Unity-Event-Bus

namespace Utilities.EventBus
{
    public interface IEventBinding<T>{
        public Action<T> OnEvent { get; set; }
        public Action OnEventNoArgs { get; set; }
    }

    public class EventBinding<T> : IEventBinding<T> where T : IEvent
    {
        public Action<T> OnEvent = _ => { };
        public Action OnEventNoArgs = () => { };

        Action<T> IEventBinding<T>.OnEvent { get => OnEvent; set => OnEvent = value; }
        Action IEventBinding<T>.OnEventNoArgs { get => OnEventNoArgs; set => OnEventNoArgs = value; }

        public EventBinding(Action<T> onEvent) => OnEvent = onEvent;
        public EventBinding(Action onEventNoArgs) => OnEventNoArgs = onEventNoArgs;

        public void Add(Action<T> onEvent) => OnEvent += onEvent;
        public void Remove(Action<T> onEvent) => OnEvent -= onEvent;

        public void Add(Action onEventNoArgs) => OnEventNoArgs += onEventNoArgs;
        public void Remove(Action onEventNoArgs) => OnEventNoArgs -= onEventNoArgs;
    }
}