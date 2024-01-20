using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Int")]
public class IntVariable : ScriptableObject, ISerializationCallbackReceiver
{
    public int initialValue;

    [NonSerialized] //hides from inspector
    public int value;

    [OnDeserialized]
    public void OnBeforeSerialize()
    {
    }

    public void OnAfterDeserialize()
    {
    }
}
