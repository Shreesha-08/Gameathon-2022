using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour

{
    public static int MAX_HITS = 1;
    public static int health = 5, hits_count = MAX_HITS;
    public Image[] hearts;
    public Sprite fullHeart, emptyHeart;

    // Update is called once per frame
    void Update()
    {
        foreach(Image img in hearts) 
            img.sprite = emptyHeart;

        for (int i = 0; i < health; i++)
            hearts[i].sprite = fullHeart;
    }
}
