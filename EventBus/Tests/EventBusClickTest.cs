using UnityEngine;
using Utilities.EventBus.EventTypes;

namespace Utilities.EventBus.Tests
{
    /// <summary>
    /// Represents a test class for handling click events using an event bus.
    /// </summary>
    public class EventBusClickTest : MonoBehaviour
    {
        EventBinding<ClickEvent> clickEventBinding;
        [SerializeField] private ParticleSystem clickEffect;

        void OnEnable(){
            clickEventBinding = new EventBinding<ClickEvent>(HandleClickEvent);
            EventBus<ClickEvent>.Register(clickEventBinding);
        }

        void OnDisable(){
            EventBus<ClickEvent>.Deregister(clickEventBinding);
        }

        void HandleClickEvent(ClickEvent clickEvent){
            Debug.Log("Click event at " + clickEvent.worldPosition);
            Instantiate(clickEffect, clickEvent.worldPosition += new Vector3(0f, 0.1f, 0f), Quaternion.identity);
        }

        void Update(){
            if (Input.GetMouseButtonDown(0)){
                Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit)){
                    EventBus<ClickEvent>.Raise(new ClickEvent{
                        worldPosition = hit.point
                    });
                }
            }
        }
    }
}
