using UnityEngine;

namespace StdNounou.Core
{
    public abstract class MonoBehaviourEventsHandler : MonoBehaviour
    {
        protected virtual void OnEnable()
        {
            EventsSubscriber();
        }

        protected virtual void OnDisable()
        {
            EventsUnSubscriber();
        }

        protected abstract void EventsSubscriber();
        protected abstract void EventsUnSubscriber();
    }

}