using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    public Transform target; // On d�fini une variable publique pour la cible de la cam�ra
    public float smoothing = 5f; // On d�fini une variable publique avec un d�faut pour le smoothing que l'on veut appliquer � la cam�a
    Vector3 offset; // Propri�t� qui va contenir la diff�rence � maintenir entre la position du personnage ainsi que la position de la cam�ra
                    // Use this for initialization
    void Start()
    {
        offset = transform.position - target.position;
    }
    void FixedUpdate()
    {
        Vector3 targetCamPosition = target.position + offset; 
        transform.position = Vector3.Lerp(transform.position, targetCamPosition, smoothing * Time.deltaTime);
    }
}
