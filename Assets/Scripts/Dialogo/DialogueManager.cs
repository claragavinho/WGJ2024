using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    GameObject UI;

    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Sprite spritePersonagem;

    public UnityEvent OnDialogueEnd;

    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogo dialogo)
    {
        Debug.Log("Teste");
        UI.SetActive(true);
        nameText.text = dialogo.name;
        spritePersonagem = dialogo.sprite;

        sentences.Clear();

        foreach (string sentence in dialogo.sentences) 
        { 
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0) 
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }
    public void EndDialogue()
    {
        UI.SetActive(false);
        OnDialogueEnd.Invoke();
    }
}
