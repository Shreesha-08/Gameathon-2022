using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public static AudioClip firing, enemyDeath, playerDeath;
    static AudioSource audioSrc;
    void Start()
    {
        firing = Resources.Load<AudioClip>("player_shoot");
        enemyDeath = Resources.Load<AudioClip>("enemy_death");
        playerDeath = Resources.Load<AudioClip>("player_death");

        audioSrc = GetComponent<AudioSource>();
    }


    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "firing":
                audioSrc.PlayOneShot(firing);
                break;
            case "enemyDeath":
                audioSrc.PlayOneShot(enemyDeath);
                break;
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeath);
                break;
        }
    }
}
