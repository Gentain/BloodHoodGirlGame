using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public AudioClip damageVoice;
    public AudioSource audioSource;

     void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (PauseSystem.paused == false)
        {
            if (col.gameObject.tag == "Enemy" && Invincible_Hit.invincibled_Hit == false)
            {
                audioSource.PlayOneShot(damageVoice);
                Debug.Log("Damage!!");
                PlayerBehavior.life--;
                Invincible_Hit.beInvincible();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (PauseSystem.paused == false)
        {
            if (col.gameObject.tag == "Enemy" && Invincible_Hit.invincibled_Hit == false)
            {
                audioSource.PlayOneShot(damageVoice);
                Debug.Log("Damage!!");
                PlayerBehavior.life--;
                Invincible_Hit.beInvincible();
            }
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (PauseSystem.paused == false)
        {
            if (col.gameObject.tag == "Enemy" && Invincible_Hit.invincibled_Hit == false)
            {
                audioSource.PlayOneShot(damageVoice);
                Debug.Log("Damage!!");
                PlayerBehavior.life--;
                Invincible_Hit.beInvincible();
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (PauseSystem.paused == false)
        {
            if (col.gameObject.tag == "Enemy" && Invincible_Hit.invincibled_Hit == false)
            {
                audioSource.PlayOneShot(damageVoice);
                Debug.Log("Damage!!");
                PlayerBehavior.life--;
                Invincible_Hit.beInvincible();
            }
        }
    }
}
