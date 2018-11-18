using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class Scenario : MonoBehaviour
{

    public Event[] steps;

    public enum EventType
    {
        Wait, Invoke    
    }

    public IEnumerator Playback()
    {
        foreach (var e in steps)
        {
            yield return e.Invoke();
        }
    }

    private void Start()
    {
        StartCoroutine(Playback());
    }

    [Serializable]
    public class Event
    {
        public EventType type;

        [ShowIf("type", EventType.Wait)]
        public float waittime;

        [ShowIf("type", EventType.Invoke)]
        public UnityEvent onInvoke;

        public IEnumerator Invoke()
        {
            switch (type)
            {
                case EventType.Wait:
                {
                    yield return new WaitForSeconds(waittime);
                    break;
                }
                case EventType.Invoke:
                {
                    onInvoke.Invoke();
                    break;
                }
            }
        }
    }
}
