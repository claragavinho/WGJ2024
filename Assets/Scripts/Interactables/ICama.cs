using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICama : MonoBehaviour, IInteractable
{
    public void OnClickAction()
    {
        Debug.Log("Teste");
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
