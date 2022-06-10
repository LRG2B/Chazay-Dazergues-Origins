using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{
    private Transform playerSpawn;
    public int Dommage;

    private void Awake()
    {
        //Quand le jeu se lance, récupération de la position du joueur
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        //Quand le personne tombe on va faire un fondu au noir 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //StartCoroutine(ReplacePlayer(collision));
            collision.transform.position = playerSpawn.position;
            Health.instance.TakeDamage(Dommage);
        }
    }

    /*private IEnumerator ReplacePlayer(Collider2D collision)
    {
        //On active le Trigger pour lancer l'animation !!!!
        yield return new WaitForSeconds(0.1f);
        collision.transform.position = playerSpawn.position;
    }*/

}
