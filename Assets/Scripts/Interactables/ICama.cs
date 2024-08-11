using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ICama : MonoBehaviour, IInteractable
{
    public static Action OnClickDialogue;
    public static Action OnClickItemImage;
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
