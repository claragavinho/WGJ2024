using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D_Pagina : MonoBehaviour
{
    [SerializeField]
    GameObject imagemUI; //para ligar a ui que mostra a imagem do item

    [SerializeField]
    Sprite imagemDoItem;//imagem do item em si

    public Dialogo dialogo;

    // Start is called before the first frame update
    void Start()
    {
        IInteractableEvents.OnClickDialogue += InvocarDialogo; //invoca o dialogo
        IInteractableEvents.OnClickItemImage += ImagemDoItem; //invoca a imagem
    }
    private void OnDisable()
    {
        IInteractableEvents.OnClickDialogue -= InvocarDialogo; //para o dialogo
        IInteractableEvents.OnClickItemImage -= ImagemDoItem; //tira o item
    }
    private void InvocarDialogo()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogo); //comeca o dialogo pelo dialoguemanager
    }
    private void ImagemDoItem()
    {
        imagemUI.SetActive(true); //liga a ui do item
        imagemDoItem = Resources.Load<Sprite>(""); //sprite do obj da cama
        imagemUI.GetComponent<Image>().sprite = imagemDoItem; //coloca o sprite do obj na imagem
    }
}
