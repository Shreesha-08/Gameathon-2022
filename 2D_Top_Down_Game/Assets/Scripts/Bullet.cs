using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    void OnCollisionEnter2D(Collision2D collision){
        var enemy = collision.collider.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeHit(1);
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 1f);
    }
    
}
