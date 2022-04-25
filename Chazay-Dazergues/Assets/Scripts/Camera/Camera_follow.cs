using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    public Transform target; // On défini une variable publique pour la cible de la caméra
    public float smoothing = 5f; // On défini une variable publique avec un défaut pour le smoothing que l'on veut appliquer à la caméa
    Vector3 offset; // Propriété qui va contenir la différence à maintenir entre la position du personnage ainsi que la position de la caméra
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
