using UnityEngine;

namespace StdNounou.Core
{
    public abstract class MonoBehaviourEventsHandler : MonoBehaviour
    {
        protected virtual void Awake()
        {
            EventsSubscriber();
        }

        protected virtual void OnDestroy()
        {
            EventsUnSubscriber();
        }

        protected abstract void EventsSubscriber();
        protected abstract void EventsUnSubscriber();
    }

}