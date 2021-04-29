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
/// <class> Set Force </class>
/// <summary>
/// Script para darle una fuerza a los objetos al ser clickeados en cima
/// </summary>
///#########################################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetForce : MonoBehaviour
{
    [SerializeField] private float force;

    private Color startColor;
    private Rigidbody rb;
    
    // Start es llamado antes del primer frame
    private void Start()
    {
        startColor = GetComponent<MeshRenderer>().material.color;
        rb = GetComponent<Rigidbody>();
    }
    
    private void OnMouseEnter()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material.color = startColor;
    }
    
    private void OnMouseDown()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        Physics.Raycast(camRay, out hitInfo);

        if(rb)
            rb.AddForceAtPosition(-hitInfo.normal * force, hitInfo.point, ForceMode.Impulse);
    }
}
