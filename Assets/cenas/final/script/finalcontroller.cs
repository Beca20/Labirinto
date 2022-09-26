using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class finalcontroller : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    
   public void jogo()
   {
    SceneManager.LoadScene(nomeDoLevelDeJogo);
   }

  
}
