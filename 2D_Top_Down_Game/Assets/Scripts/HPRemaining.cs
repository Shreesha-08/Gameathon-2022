using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HPRemaining : MonoBehaviour
{
    public TMP_Text livesText;
    public static int lives;
    public static int max_lives;

    private void Start()
    {
        lives = PlayerStats.playerMaxHealth;
        livesText.text = "x" + lives;
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "x" + PlayerStats.playerHealth;
    }
}
