using UnityEngine;

namespace Utilities.DependencyInjection.Test
{

    public class Provider : MonoBehaviour, IDependencyProvider{
        // Anything marked with a [Prov]
        [Provide]
        public ServiceA ProvideServiceA(){
            return new ServiceA();
        }

        [Provide]
        public ServiceB ProvideServiceB(){
            return new ServiceB();
        }

        [Provide]
        public FactoryA ProvideFactoryA(){
            return new FactoryA();
        }
    }

    public class ServiceA{
        public void Initialize(string message){
            Debug.Log($"ServiceA.Initialize({message})");
        }
    }

    public class ServiceB{
        public void Initialize(string message){
            Debug.Log($"ServiceB.Initialize({message})");
        }
    }

    public class FactoryA{
        ServiceA cachedServiceA;
        public ServiceA GetServiceA(){
            if(cachedServiceA == null){
                cachedServiceA = new ServiceA();
            }
            return cachedServiceA;
        }
    }
}
