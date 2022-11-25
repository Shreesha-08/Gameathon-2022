using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	public int fireRate = 0;
    public Transform firePoint;
	public int damage = 3;
	public int critChance = 1;
	public int clipSize = 6;
	public static int shotsFired = 0;
	float timeToFire = 0;
	public float reloadTime = 1f;
	
	private bool reloading = false;
    public GameObject bluebulletPrefab;

	public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {

		if (Input.GetKeyDown (KeyCode.R)) {
			StartCoroutine ("Reload");
			reloading = true;
		}

		if (reloading)
			return;

		if (shotsFired >= clipSize) {
			StartCoroutine ("Reload");
			reloading = true;
			return;
		}

		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				Shoot();
				shotsFired++;
			}
		}
		else {
			if (Input.GetButton ("Fire1")) {
				if (Time.time > timeToFire) {
					timeToFire = Time.time + 1/(float)fireRate;
					Shoot();
					shotsFired++;
				}
			}
		}
    }

    void Shoot () 
    {
        GameObject bullet = Instantiate(bluebulletPrefab, firePoint.position, firePoint.rotation);
        
		float dmg = damage;
	
		if (Random.Range (0, 101) <= critChance)
			dmg *= Random.Range(2f, 3f);
        bullet.GetComponent<Bullet>().damage = (int)dmg;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
	}
    
	IEnumerator Reload () {
		yield return new WaitForSeconds (reloadTime);
		shotsFired = 0;
		reloading = false;
	}
}
