using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionType
{
    Item,
    Door,
    OnOff
}

[CreateAssetMenu(menuName = "SO/Interaction")]
public class InteractionData : ScriptableObject
{
    public InteractionType interactionType;

    public float interactionTime;

    public string interactionMessage;
}
