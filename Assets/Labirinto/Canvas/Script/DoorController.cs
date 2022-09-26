using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DoorController : MonoBehaviour
{

    private Animator anim;

    private bool IsAtDoor = false;

    [SerializeField] private TextMeshProUGUI CodeText;
    string CodeTextValue = "";
    public string safeCode;
    public GameObject CodePanel;

     [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip correctSound;



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

    if(CodeTextValue.Length >= 4)
    {
        CodeTextValue = "";
    }

    if(Input.GetKey(KeyCode.Space) && IsAtDoor == true)
    {
        CodePanel.SetActive(true);

    }}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            IsAtDoor = true;
        }
    }
    private void OnTriggerExist(Collider other)
    {
        IsAtDoor = false;
        CodePanel.SetActive(false);
    }

    public void addDigit(string digit)
    {
        CodeTextValue += digit;
    }

}
