using UnityEngine;
using System.Collections;

public class upgrades : MonoBehaviour {

	// Use this for initialization
	void Start () {
	

	}

	void Awake () {

		PlayerShooting.damagePerShot = 20;
		PlayerMovement.speed = 6f;

	}
	
	// Update is called once per frame
	void Update () {

		ren.mesh.enabled = true;
		if (ScoreManager.curlevel == 1) {

			ren.mesh.enabled = true;


			Debug.Log("Level 1");
			PlayerMovement.speed = 10f;
			PlayerShooting.damagePerShot = 20000;
		}
	
	}
}
