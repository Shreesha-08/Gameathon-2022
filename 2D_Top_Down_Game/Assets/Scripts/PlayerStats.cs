using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	public static Vector3 PlayerPosition;
	public static GameObject PlayerInstance;

	
	public static int playerMaxHealth=3;
	public static int playerDamage=1;
	public static int playerFireRate=2;
	public static int playerCritChance=5;
	public static int playerClipSize=6;
	public static float playerReloadTime=1f;
	public static float playerPowerUpCooldown=1f;
	public static void reset()
    {
		playerMaxHealth = 3;
		playerHealth=3;
		playerDamage = 1;
		playerFireRate = 2;
		playerCritChance = 5;
		playerClipSize = 6;
		playerReloadTime = 1f;
		playerPowerUpCooldown = 3f;
}

	
	private static int _health = playerMaxHealth;
	public static int playerHealth {
		get {
			return ( _health ); 
		}
		set {
			_health = Mathf.Clamp (value, 0, playerMaxHealth);
		}
	}
	

}