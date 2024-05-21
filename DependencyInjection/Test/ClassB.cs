

using UnityEngine;

namespace Utilities.DependencyInjection.Test
{
    public class ClassB : MonoBehaviour
    {
        [Inject]
        ServiceA serviceA;

        // direct injection
        [Inject]
        ServiceB serviceB;

        // method injection
        FactoryA factoryA;

        [Inject]
        public void Init(FactoryA factoryA)
        {
            this.factoryA = factoryA;
        }
    }
}
