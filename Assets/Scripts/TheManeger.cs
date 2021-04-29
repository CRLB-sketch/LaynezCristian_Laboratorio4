using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheManeger : MonoBehaviour
{
    // Para tener el control del personaje
    [SerializeField] PlayerController player;
       
    // Para el menu de GAME Over
    [SerializeField] GameObject gameOverMenu; 
    bool isOver = false;

    /// Update is called every frame, if the MonoBehaviour is enabled.
    void Update()
    {
        if(player.IsDead == true || player.IsComplete == true)
            GameOverMenu();
    }
    
    /// <summary>
    /// Restar Game es para reiniciar el nivel  
    /// </summary>
    public void SelectScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// Game Over Menu es para cuando el jugador a "muerto"
    /// </summary>
    public void GameOverMenu()
    {
        isOver = true;
        gameOverMenu.SetActive(isOver);
        Time.timeScale = isOver ? 0.0f : 1.0f;

        // Para deshabilitar el control del juegador
        if(isOver)
        {
            player.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }    
}
