using UnityEngine;
using Utilities.EventBus.EventTypes;

// This code is based on the Unity Event Bus project by Adam Myhre.
// Source: https://github.com/adammyhre/Unity-Event-Bus

namespace Utilities.EventBus.Tests
{
    public class EventBusTest : MonoBehaviour
    {
        public int health = 100;
        public int mana = 75;

        EventBinding<TestEvent> testEventBinding;
        EventBinding<PlayerEvent> playerEventBinding;

        void OnEnable(){
            testEventBinding = new EventBinding<TestEvent>(HandleTestEvent);
            EventBus<TestEvent>.Register(testEventBinding);
            
            playerEventBinding = new EventBinding<PlayerEvent>(HandlePlayerEvent);
            EventBus<PlayerEvent>.Register(playerEventBinding);
        }

        void OnDisable(){
            EventBus<TestEvent>.Deregister(testEventBinding);
            EventBus<PlayerEvent>.Deregister(playerEventBinding);
        }

        void Update(){
            if (Input.GetKeyDown(KeyCode.Alpha1)){
                EventBus<TestEvent>.Raise(new TestEvent());
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)){
                EventBus<PlayerEvent>.Raise(new PlayerEvent{
                    health = health,
                    mana = mana
                });
            }

            // if + increase health
            if (Input.GetKeyDown(KeyCode.Alpha3)){
                health += 10;
                EventBus<PlayerEvent>.Raise(new PlayerEvent{
                    health = health,
                    mana = mana
                });
            }

            // if - decrease health
            if (Input.GetKeyDown(KeyCode.Alpha4)){
                health -= 10;
                EventBus<PlayerEvent>.Raise(new PlayerEvent{
                    health = health,
                    mana = mana
                });
            }
        }

        

        void HandleTestEvent(){
            Debug.Log("Test event received");
        }

        void HandlePlayerEvent(PlayerEvent playerEvent){
            Debug.Log($"Player event received: health {playerEvent.health}, mana {playerEvent.mana}");
        }
    }
}
