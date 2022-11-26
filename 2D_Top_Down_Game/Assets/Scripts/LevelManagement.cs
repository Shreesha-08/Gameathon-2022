using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagement : MonoBehaviour
{
    public Sprite[] sprites;
    private int i = 0;
    [SerializeField]
    private int interval;
    int prevScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ScoreCounter.instance.score);
        StartCoroutine("changeBackground");  
    }

    IEnumerator changeBackground()
    {
        yield return new WaitForSeconds(interval);
        if (ScoreCounter.instance.score % 4 == 0 && ScoreCounter.instance.score > 0 && ScoreCounter.instance.score != prevScore)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[++i % 3];
            prevScore = ScoreCounter.instance.score;
            PlayerStats.playerHealth=PlayerStats.playerMaxHealth;
        }
        StartCoroutine("changeBackground");
    }
}
