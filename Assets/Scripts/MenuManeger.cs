///#########################################################################################
/// <author> Cristian Fernando Laynez Bachez </author>
/// <copyright> Copyright 2020, © Cristian Laynez Productions </copyright>
/// <maintainer> Cristian Laynez Productions </maintainer>
/// <email> lay201281@uvg.edu.gt </email>
/// <status> Student of Computer Science </status>
/// 
/// <proyect> Laboratorio #4 </proyect>
/// <p>  Laboratorio para familiarizarce con el uso de los RayCast</p>
/// 
/// <class> Menu Maneger </class>
/// <summary>
/// Script para cambiar de escenas.
/// </summary>
///#########################################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManeger : MonoBehaviour
{        
    /// <summary>
    /// Start Game es llamado para ejecutar la escena del juego para jugar
    /// </summary>
    /// <param name="sceneName">Nombre de la escena que se cargará</param>
    public void StartGame(string sceneName)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneName);
    }
    
    /// <summary>
    /// Quit Game es llamado cuando se quiera salir del juego
    /// </summary>
    public void QuitGame()
    {
        // Por si estamos dentro del editor de Unity
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;

        // Por si estamos en el juego como tal
        #else
            Application.Quit();

        #endif
    }
    
}
