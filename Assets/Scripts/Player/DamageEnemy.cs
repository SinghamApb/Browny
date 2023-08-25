using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public GameObject killEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log(other.name);
        if (other.tag == "Enemy")
        {

            other.transform.parent.gameObject.SetActive(false);
           // Instantiate(killEffect, other.transform.position, other.transform.rotation);

        }
    }
}
