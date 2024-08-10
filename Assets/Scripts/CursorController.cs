using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CursorController : MonoBehaviour
{
    private CursorControls controls;

    [SerializeField]
    private InteractablesManager interactablesManager;

    [SerializeField]
    private Texture2D interactiveCursorTexture; //mouse pode mudar quando estiver perto de algo clicavel

    private Cursor interactiveCursor;

    [SerializeField]
    private Transform newSelectionTransform;
    private Transform currentSelectionTransform;

    public static Action MakeCursorDefault;
    public static Action MakeCursorInteractive; //eventos do cursor
    public bool cursorIsInteractive = false;

    public float DistanceThreshold; //o quao perto o cursor precisa estar pra ser ativado
    private void Awake()
    {
        controls = new CursorControls(); //instance do controle do cursor
        controls.Mouse.Click.started += _ => StartedClick(); //subscribe ao evento do click ao comecar
        controls.Mouse.Click.performed += _ => EndedClick();//subscribe ao evento do click ao ser performado
        MakeCursorDefault += DefaultCursorTexture;
        MakeCursorInteractive += InteractiveCursorTexture;
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        FindInteractableWithinDistanceThreshold(); //analisar se o mouse esta perto de algo q possa interagir
    }
    private void FindInteractableWithinDistanceThreshold()
    {
        newSelectionTransform = null;

        for (int itemIndex = 0; itemIndex < interactablesManager.Interactables.Count; itemIndex++) //passa por todos os objetos com interacao da lista
        {
            Vector3 fromMouseToInteractableOffset = interactablesManager.Interactables[itemIndex].position - new Vector3(controls.Mouse.Position.ReadValue<Vector2>().x, controls.Mouse.Position.ReadValue<Vector2>().y, 0f);
            float sqrMag = fromMouseToInteractableOffset.sqrMagnitude; //usa a magnitude para checar se o mouse esta numa posicao para interagir

            if (sqrMag < DistanceThreshold) 
            {
                newSelectionTransform = interactablesManager.Interactables[itemIndex].transform; //salva o transform no index

                if (cursorIsInteractive == false) 
                {
                    InteractiveCursorTexture(); //troca a textura do cursor
                }
                break; //acaba com o loop
            }
        }

        if (currentSelectionTransform != newSelectionTransform) 
        { 
            currentSelectionTransform = newSelectionTransform; //salva a selecao atual pra saber se a selecao nova eh realmente algo novo
            DefaultCursorTexture(); //cursor volta ao normal
        }
    }
    private void InteractiveCursorTexture()
    {
        cursorIsInteractive = true;
        Vector2 hotspot = new Vector2(interactiveCursorTexture.width / 2, 0);
        Cursor.SetCursor(interactiveCursorTexture, hotspot, CursorMode.Auto); //escutam os eventos relacionados a troca de cursor
    }
    private void DefaultCursorTexture()
    {
        cursorIsInteractive = false;
        Cursor.SetCursor(default, default, default);
    }
    private void StartedClick()
    {

    }
    private void EndedClick()
    {
        OnClickInteractable();
        //cutscene entraria aqui
    }
    private void OnClickInteractable()
    {
        if (newSelectionTransform != null) //se o jogador clicar em algo que tenha interacao
        {
            IInteractable interactable = newSelectionTransform.gameObject.GetComponent<IInteractable>();
            if (interactable != null ) { interactable.OnClickAction(); }
            newSelectionTransform = null; //jogador nao pode clicar no que ja foi clicado, isso pode ser mudado caso necessario; cursor volta ao normal
        }
    }
}
