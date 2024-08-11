using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    [SerializeField]
    GameObject imagemUI; //para ligar a ui que mostra a imagem do item

    [SerializeField]
    Sprite imagemDoItem;//imagem do item em si

    public Dialogo dialogo;

    private IInteractableEvents interactableEvents;

    private void Awake()
    {
        interactableEvents = GetComponent<IInteractableEvents>();
    }

    // Start is called before the first frame update
    void Start()
    {
        interactableEvents.OnClickDialogue += InvocarDialogo; //invoca o dialogo
        interactableEvents.OnClickItemImage += ImagemDoItem; //invoca a imagem
    }
    private void OnDisable()
    {
        interactableEvents.OnClickDialogue -= InvocarDialogo; //para o dialogo
        interactableEvents.OnClickItemImage -= ImagemDoItem; //tira o item
    }
    private void InvocarDialogo()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogo); //comeca o dialogo pelo dialoguemanager
    }
    private void ImagemDoItem()
    {
        imagemUI.SetActive(true); //liga a ui do item
        imagemUI.GetComponent<Image>().sprite = imagemDoItem; //coloca o sprite do obj na imagem
    }
}
