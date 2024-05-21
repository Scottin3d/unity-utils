using UnityEngine;

// This code is based on the Unity Event Bus project by Adam Myhre.
// Source: https://github.com/adammyhre/Unity-Event-Bus

namespace Utilities.EventBus.EventTypes
{
    public interface IEvent { }

    // concrete types
    public struct TestEvent : IEvent { }

    public struct ClickEvent : IEvent
    {
        public Vector3 worldPosition;
    }

    public struct ButtonClickEvent : IEvent
    {
        public string ButtonType;
    }
}