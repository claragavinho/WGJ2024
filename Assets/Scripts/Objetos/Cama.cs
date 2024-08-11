using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cama : MonoBehaviour
{
    public Dialogo dialogo;
    // Start is called before the first frame update
    void Start()
    {
        ICama.OnClickDialogue += InvocarDialogo;
    }
    private void OnDisable()
    {
        ICama.OnClickDialogue -= InvocarDialogo;
    }
    private void InvocarDialogo()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogo);
    }
}
