using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	public static int PlayerScore = 0;
	public static Vector3 PlayerPosition;
	public static GameObject PlayerInstance;

	public static void setPlayerScore (int score) {
		PlayerScore += score;
	}
	
	void Awake () {
		playerHealth = 10;
		playerMaxHealth = 10;
		// Consider Accuracy, Movement Speed
		playerDamage = 1;
		playerFireRate = 0;
		playerCritChance = 1;
		playerClipSize = 6;
		playerReloadTime = 1f;
		playerPowerUpCooldown = 1f;
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
	
	
	public static int playerMaxHealth {
		get {
			return ( PlayerMaxHealth ); 
		}
		set {
			PlayerMaxHealth = value;
		}
	}
	
	
	public static int playerDamage {
		get {
			return ( playerDamage ); 
		}
		set {
			playerDamage = value;
		}
	}
	
	public static int playerFireRate {
		get {
			return ( playerFireRate ); 
		}
		set {
			playerFireRate = value;
		}
	}
	
	public static int playerCritChance {
		get {
			return ( playerCritChance ); 
		}
		set {
			playerCritChance = Mathf.Clamp (value, 0, 100);
		}
	}
	
	public static int playerClipSize {
		get {
			return ( playerClipSize ); 
		}
		set {
			playerClipSize = value;
		}
	}
	
	public static float playerReloadTime {
		get {
			return ( playerReloadTime ); 
		}
		set {
			playerReloadTime = value;
		}
	}
}
