using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Menucontroller : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
     [SerializeField] private GameObject painelNivel;
    [SerializeField] private GameObject painelOpecoes;
   
   public void jogo()
   {
    SceneManager.LoadScene(nomeDoLevelDeJogo);
   }

   public void abriropcoes()
   {
    painelMenuInicial.SetActive(false);
    painelOpecoes.SetActive(true);
    painelNivel.SetActive(false);
   }

    public void abrirjogo()
   {
    painelMenuInicial.SetActive(false);
    painelOpecoes.SetActive(false);
    painelNivel.SetActive(true);
   }

   public void fecharopcoes()
   {
     painelMenuInicial.SetActive(true);
    painelOpecoes.SetActive(false);
    painelNivel.SetActive(false);
   }

    public void fecharjogo()
   {
     painelMenuInicial.SetActive(true);
    painelOpecoes.SetActive(false);
    painelNivel.SetActive(false);
   }

    public void fecharnivel()
   {
     painelMenuInicial.SetActive(true);
    painelOpecoes.SetActive(false);
    painelNivel.SetActive(false);
   }
    
    public void sairjogo()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }
}
