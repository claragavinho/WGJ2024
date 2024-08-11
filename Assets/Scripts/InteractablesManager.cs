using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractablesManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> interactables; //lista de todos os interagiveis 

    public List<Transform> Interactables
    {
        get => interactables;
    }

    private Camera mainCamera;

    public static Action<Transform> AddToInteractablesEvent;
    public static Action<Transform> RemoveFromInteractablesEvent; //eventos que vao adicionar ou remover os interagiveis
    private void Awake()
    {
        AddToInteractablesEvent += AddToListOfInteractables;
        RemoveFromInteractablesEvent += RemoveFromListOfInteractables; //subscribing os metodos aos eventos
    }
    private void AddToListOfInteractables(Transform transformToAddToList)
    {
        interactables.Add(transformToAddToList); //adiciona a lista
    }
    private void RemoveFromListOfInteractables(Transform transformToRemoveFromList)
    {
        interactables.Remove(transformToRemoveFromList); //remove da lista
    }
    void Start()
    {
        mainCamera = Camera.main; //encontrando a camera principal
        AllChildrenToScreenPoint(); //chamando a funcao para pegar todas as children do manager
    }
    private void AllChildrenToScreenPoint()
    {
        for(int i = 0; i < this.transform.childCount; i++) 
        { 
            transform.GetChild(i).position = mainCamera.WorldToScreenPoint(transform.GetChild(i).position); //world to screen point em todas as criancas, ve o que esta na range

            transform.GetChild(i).localScale = Vector3.one * 100; //aumenta a escala
        }
    }
}
