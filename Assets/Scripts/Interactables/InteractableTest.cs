using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTest : MonoBehaviour, IInteractable
{
    public void OnClickAction()
    {
        Debug.Log("O que o objeto vai fazer quando for clicado");
    }
    void OnEnable()
    {
        InteractablesManager.AddToInteractablesEvent.Invoke(transform);
    }
    void OnDisable()
    {
        InteractablesManager.RemoveFromInteractablesEvent.Invoke(transform);
    }
}
