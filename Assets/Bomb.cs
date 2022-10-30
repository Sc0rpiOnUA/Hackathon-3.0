using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [HideInInspector]public Transform player;
    public float bombLife = 3;

    void Awake()
    {        
        Destroy(gameObject, bombLife);
    }
    private void Update()
    {
        player = GameObject.FindWithTag("Player").transform;
        transform.LookAt(player);
    }

    public void Explode()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Destroy(gameObject, 1);
    }
}
