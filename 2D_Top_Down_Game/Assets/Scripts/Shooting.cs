using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	public int fireRate = 0;
	public int damage = 3;
	public int critChance = 1;
	public int clipSize = 6;
	public static int shotsFired = 0;
	public float bulletForce = 20f;
	private float timeToFire = 0;

    // Reloading
	public float reloadTime = 1f;
	private bool reloading = false;
    // Power Up cooldown
    public float powerUpCooldownTime = 1f;
    private bool powerUpUnavailable = false;
    private float powerActiveTime = 3f;
    private bool powerUpActive = false;

    public GameObject bluebulletPrefab;
    [SerializeField]
    private GameObject activatePowerUp;
    public Transform firePoint;

	void Start () {
		damage = PlayerStats.playerDamage;
		fireRate = PlayerStats.playerFireRate;
		critChance = PlayerStats.playerCritChance;
		clipSize = PlayerStats.playerClipSize;
		reloadTime = PlayerStats.playerReloadTime;
		powerUpCooldownTime = PlayerStats.playerPowerUpCooldown;
		shotsFired = 0;
	}

    void Update()
    {

		if (Input.GetKeyDown (KeyCode.R)) {
			StartCoroutine ("Reload");
			reloading = true;
		}

        if (Input.GetButtonDown("Fire2") && (!powerUpUnavailable)){
            GameObject effect = Instantiate(activatePowerUp, transform.position, Quaternion.identity, firePoint.parent);
            effect.GetComponent<ParticleSystem>().Play();
            Destroy(effect, powerActiveTime);
            powerUpActive = true;
            powerUpUnavailable=true;
            PlayerStats.playerHealth-=1;
			StartCoroutine ("PowerUpActive");
			StartCoroutine ("PowerUpCooldown");
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
        if (powerUpActive){
            dmg=damage*3f;
            shotsFired=0;
        }
	
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
    
	IEnumerator PowerUpCooldown () {
		yield return new WaitForSeconds (powerUpCooldownTime);
		powerUpUnavailable = false;
	}
	IEnumerator PowerUpActive () {
		yield return new WaitForSeconds (powerActiveTime);
		powerUpActive = false;
	}
}
