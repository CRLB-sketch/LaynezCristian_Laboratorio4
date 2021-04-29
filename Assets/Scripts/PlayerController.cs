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
/// <class> Player </class>
/// <summary>
/// Script para tener el control de las acciones del jugador, también pasaran
/// Una sería de cosas
/// </summary>
///#########################################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{    
    // Para el punteo
    [SerializeField] private Text scoreText;
    private int score;

    // Objetos que se verán afectados cuando estemos en acción
    [SerializeField] private GameObject door;

    // Tener estado actual del personaje
    [SerializeField] private bool isDead = false;
    [SerializeField] private bool isComplete = false;

    // Propiedades
    public bool IsDead
    {
        get{ return isDead; }
    }

    public bool IsComplete
    {
        get{ return isComplete; }
    }
        
    // Update is called once per frame
    void Update()
    {
        // RayCast Para llevar a cabo el disparo
        Ray camRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;

        // Para dar sonido al disparo
        if (Input.GetMouseButtonDown(0))
            AudioManeger.Play(AudioClipName.fire01);
        
        if(Physics.Raycast(camRay, out hitInfo) && Input.GetMouseButtonDown(0))
        {                        
            if(hitInfo.collider.CompareTag("Target"))
            {
                score++;
                Destroy(hitInfo.collider.gameObject);
            }
        }

        // Para actualizar el punteo
        scoreText.text = "Score: " + score;

        DoorOut(); // Para quitar la puerta
        CheckState();
    }

    private void DoorOut()
    {
        if(score == 15)        
            Destroy(door);        
    }

    private void CheckState()
    {
        if(score == 20)
            isComplete = true;
    }
    
    void OnTriggerEnter(Collider other)
    {        
        if(other.gameObject.CompareTag("Limit"))
        {
            print("Xd");
            isDead = true;
        }
    }

    // private void OnTriggerExit(Collider other) 
    // {
    //     if(other.gameObject.CompareTag("Limit"))
    //     {
    //         print("Xd");
    //         isDead = true;
    //     }        
    // }

}
