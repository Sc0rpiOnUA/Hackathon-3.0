using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [HideInInspector]public Transform player;
    public AudioClip[] audioClips;
    public float bombLife = 3;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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

        PlayExplosionSound();

        Destroy(gameObject, 1);
    }

    private void PlayExplosionSound()
    {
        int length = audioClips.Length;
        if (length > 0)
        {
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.PlayOneShot(audioClips[Random.Range(0, length)]);
        }
    }
}
