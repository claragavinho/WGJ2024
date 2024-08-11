using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IInteractableEvents : MonoBehaviour, IInteractable
{
    public Action OnClickDialogue;
    public Action OnClickItemImage;
    public void OnClickAction()
    {
        OnClickDialogue.Invoke();
        OnClickItemImage.Invoke();
    }
    void Start()
    {
        InteractablesManager.AddToInteractablesEvent(transform);
    }
    void OnDisable()
    {
        InteractablesManager.RemoveFromInteractablesEvent(transform);
    }
}
