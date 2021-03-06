﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogText;

    public GameObject dialogUI;
    public Animator animator;

    private Queue<string> sentences;

    public static DialogManager instance;

    private bool isReadyToPrintNextSentence = false;
    private bool rushSentence = false;

    private float waitTime = 0.04f;

    private DialogTrigger dialogTrigger;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DialogManager dans la scène");
            return;
        }

        instance = this;

        sentences = new Queue<string>();

        if (!dialogUI.activeSelf)
        {
            dialogUI.SetActive(true);
        }

        dialogText.text = "";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && dialogTrigger && dialogTrigger.GetIsDialogOpen() && isReadyToPrintNextSentence)
        {
            Debug.Log("update dialogManager");
            DisplayNextSentence();
            isReadyToPrintNextSentence = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rushSentence = true;
        }
    }

    public void StartDialog(NPC npc, int numberOfInteractions, DialogTrigger dialogTrigger)
    {
        this.dialogTrigger = dialogTrigger;

        dialogText.text = "";

        animator.SetBool("IsOpen", true);

        nameText.text = npc.name;

        sentences.Clear();

        foreach (string sentence in npc.dialogs[numberOfInteractions].sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        StartCoroutine(WaitForEndOfAnimation());
    }

    IEnumerator WaitForEndOfAnimation()
    {
        yield return new WaitForSeconds(0.3f);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        Debug.Log("bool animator display : " + animator.GetBool("IsOpen"));
        Debug.Log("sentences.count : " + sentences.Count);
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            if (rushSentence)
            {
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(waitTime);
            }
        }
        rushSentence = false;
        isReadyToPrintNextSentence = true;
    }

    void EndDialog()
    {
        dialogText.text = "";
        animator.SetBool("IsOpen", false);
        dialogTrigger.SetIsDialogOpen(false);
        //dialogTrigger = null;
        Debug.Log("bool animator end : " + animator.GetBool("IsOpen"));
    }
}
