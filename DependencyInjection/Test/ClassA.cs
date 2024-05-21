using UnityEngine;

namespace Utilities.DependencyInjection.Test
{
    public class ClassA: MonoBehaviour{
        ServiceA serviceA;

        [Inject]
        public void Init(ServiceA serviceA){
            this.serviceA = serviceA;
        }

        void Start(){
            serviceA.Initialize("ClassA");
        }
    }
}
