using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public GameObject gameObject { get; }
    public bool CanActive { get; }
    public InteractionData InteractionData { get; }
    public void Init();
    public void OnInteraction();
}
