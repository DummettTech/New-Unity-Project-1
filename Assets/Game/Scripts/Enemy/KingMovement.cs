using UnityEngine;
using System.Collections;

public class KingMovement : MonoBehaviour
{

	Transform player;
	PlayerHealth playerHealth;
	KingHealth kingHealth;
	NavMeshAgent nav;
	
	
	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerHealth = player.GetComponent <PlayerHealth> ();
		kingHealth = GetComponent <KingHealth> ();
		nav = GetComponent <NavMeshAgent> ();
	}
	
	
	void Update ()
	{
		if(kingHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
		{
			nav.SetDestination (player.position);

		}
		else
		{
			nav.enabled = false;
		}
	}
}
