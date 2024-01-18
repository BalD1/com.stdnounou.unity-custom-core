using StdNounou.Core.ComponentsHolder;
using StdNounou.Core;
using UnityEngine;

namespace StdNounou.Samples.HolderComponent
{
    public class KeysHolder : Singleton<KeysHolder>
    {

        [field: SerializeField] public SO_KeyContainer RigidBody { get; private set; }
        public static SO_KeyContainer GetRigidBody {
            get => Instance.RigidBody;
        }

        protected override void EventsSubscriber()
        {
        }

        protected override void EventsUnSubscriber()
        {
        }

        protected override void Awake()
        {
            base.Awake();
            CheckContainers();
        }

        private void CheckContainers()
        {
            if (RigidBody == null) RigidBody.Load("RIGIDBODY");
        }
    }
}