using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float goBackDistance;

    public float Hitpoints;
    public float MaxHitpoints = 3;
    public HealthBarEnemy healthBar;

    private float timedShots;
    public float startShot;
    public GameObject projectile;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timedShots = startShot;
        Hitpoints = MaxHitpoints;
        healthBar.SetHealth(Hitpoints, MaxHitpoints);
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        healthBar.SetHealth(Hitpoints, MaxHitpoints);
        if (Hitpoints <= 0)
        {
            ScoreCounter.instance.AddPoint();
            SFX.PlaySound("enemyDeath");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > goBackDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position) < goBackDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timedShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timedShots = startShot;
        }
        else
        {
            timedShots -= Time.deltaTime;
        }
    }
}
