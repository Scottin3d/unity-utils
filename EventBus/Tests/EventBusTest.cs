using UnityEngine;
using Utilities.EventBus.EventTypes;

// This code is based on the Unity Event Bus project by Adam Myhre.
// Source: https://github.com/adammyhre/Unity-Event-Bus

namespace Utilities.EventBus.Tests
{
    public class EventBusTest : MonoBehaviour
    {

        EventBinding<TestEvent> testEventBinding;

        void OnEnable(){
            testEventBinding = new EventBinding<TestEvent>(HandleTestEvent);
            EventBus<TestEvent>.Register(testEventBinding);
        }

        void OnDisable(){
            EventBus<TestEvent>.Deregister(testEventBinding);
        }

        void Update(){
            if (Input.GetKeyDown(KeyCode.Alpha1)){
                EventBus<TestEvent>.Raise(new TestEvent());
            }
        }

        void HandleTestEvent(){
            Debug.Log("Test event received");
        }
    }
}
