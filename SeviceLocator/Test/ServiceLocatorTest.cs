using UnityEngine;
using Utilities.Extensions;

namespace Utilities.UnityServiceLocator.Tests
{
    public class ServiceLocatorTest : MonoBehaviour
    {
        [SerializeField] GameObject prefab;
        [SerializeField] int prefabHeight = 1;

        ILocalization localization;
        ISerializer serializer;
        IGameService gameService;

        void Awake(){
            ServiceLocator.Global.Register<ILocalization>(localization = new MockServiceLocator());
            ServiceLocator.ForSceneOf(this).Register<IGameService>(gameService = new MockGameService());
            ServiceLocator.For(this).Register<ISerializer>(serializer = new MockSerializer());

            
        }

        void Start(){
            GameObject go = Instantiate(prefab, transform.position.With(y: prefabHeight), Quaternion.identity);
            go.transform.SetParent(transform);

            Debug.Log("** Hero Start **");
            ServiceLocator.For(this)
                .Get(out serializer)
                .Get(out localization)
                .Get(out gameService);

            Debug.Log("Localization: " + localization.GetLocalizedWord("Hello"));
            serializer.Serialize();
            gameService.Start();
        }
    }
}
