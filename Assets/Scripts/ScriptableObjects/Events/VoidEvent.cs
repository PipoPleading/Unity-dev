using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Event")]
public class VoidEvent : ScriptableObjectBase
{
    // Start is called before the first frame update
    public UnityAction onEventRaised;

    public void RaiseEvent()
    {
        //might want to review later 
        onEventRaised?.Invoke(); // ? -> if null, dont do proceeding event
    }

    public void Subscribe(UnityAction function)
    {
        onEventRaised += function;
    }

    public void Unsubscribe(UnityAction function)
    {
        onEventRaised -= function;
    }

}
