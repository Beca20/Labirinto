using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MatController : MonoBehaviour
{

    private Animator anim;

    private bool Door = false;

    [SerializeField] private TextMeshProUGUI CodeText;
    string CodeTextValue = "";
    public string safeCode;
    public GameObject CodePanel;
    

     [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip correctSound;

    public string[] dialogoNpc;
    public int dialogoIndex;

     public Text nameNpc;
     public Text dialogoText;
     public bool startDialogo;
   

   void Start()
   {
    anim = GetComponent<Animator>();
   }

   void Update()
   {
    CodeText.text = CodeTextValue;

    if(CodeTextValue == safeCode)
    {
        anim.SetTrigger("Door");
        CodePanel.SetActive(false);
        
        if (audioSource != null)
            audioSource.PlayOneShot(correctSound);
    }

    if(CodeTextValue.Length >= 1)
    {
        CodeTextValue = "";
    }

    if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow) && Door == true)
    {
        
            CodePanel.SetActive(true);
    
         if(!startDialogo)
            {
                StartDialogo();
            }
            else if(dialogoText.text == dialogoNpc[dialogoIndex])
            {
                NextDialogo();
            }
        }
    }
   
   void NextDialogo()
    {
        dialogoIndex++;
        if(dialogoIndex < dialogoNpc.Length)
        {
            StartCoroutine(ShowDialogo());
        }
        else
        {
            CodePanel.SetActive(false);
            startDialogo = false;
            dialogoIndex = 0;
        }
    }

    void StartDialogo()
    {
        nameNpc.text = "Voz do limbo";
        startDialogo = true;
        dialogoIndex = 0;
        CodePanel.SetActive(true);
        StartCoroutine(ShowDialogo());
    }

    IEnumerator ShowDialogo()
    {
        dialogoText.text = "";
        foreach (char letter in dialogoNpc [dialogoIndex])
        {
            dialogoText.text += letter;
            yield return new WaitForSeconds(0.089f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Door = true;
        }
    }
    private void OnTriggerExist(Collider other)
    {
        Door = false;
        CodePanel.SetActive(false);
    }

    public void addDigit(string digit)
    {
        CodeTextValue += digit;
    }

}

