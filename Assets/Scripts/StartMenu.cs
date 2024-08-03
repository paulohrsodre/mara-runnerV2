using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    void Update()
    {
        // Verifica se o usuário clicou em qualquer lugar da tela
        if (Input.GetMouseButtonDown(0))
        {
            // Carrega a cena do jogo principal
            SceneManager.LoadScene("Game");
        }
    }
}
