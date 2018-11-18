using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Scenario : MonoBehaviour
{

    public Act[] acts;

    public enum EventType
    {
        Wait, Invoke, KeyStroke, MoveAgent
    }

    public IEnumerator Playback()
    {
        foreach (var e in acts)
        {
            yield return e.Invoke();
        }
    }

    private void Start()
    {
        StartCoroutine(Playback());
    }

    [Serializable]
    public class Act
    {
        public EventType type;

        [ShowIf("type", EventType.Wait)]
        public float waittime;

        [ShowIf("type", EventType.Invoke)]
        public UnityEvent onInvoke;

        [ShowIf("type", EventType.KeyStroke)]
        public KeyCode key;
        
        [ShowIf("type", EventType.MoveAgent)]
        public NavMeshAgent agent;
        [ShowIf("type", EventType.MoveAgent)]
        public Transform target;
        
        
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
                case EventType.KeyStroke:
                {
                    yield return new WaitUntil(()=> Input.GetKey(key));
                    break;
                }
                case EventType.MoveAgent:
                {
                    agent.SetDestination(target.position);
                    break;
                }
            }
        }
    }
}
