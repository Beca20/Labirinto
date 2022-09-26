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
    
    }}
   
   

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

