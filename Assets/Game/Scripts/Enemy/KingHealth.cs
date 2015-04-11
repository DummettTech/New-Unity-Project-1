using UnityEngine;

public class KingHealth : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;
	public float sinkSpeed = 2.5f;
	public int scoreValue = 10;
	public AudioClip deathClip;
	
	
	Animator anim;
	AudioSource enemyAudio;
	ParticleSystem hitParticles;
	CapsuleCollider capsuleCollider;
	bool isDead;
	bool isSinking;
	Light deathLight;
	
	void Awake ()
	{
		anim = GetComponent <Animator> ();
		enemyAudio = GetComponent <AudioSource> ();
		hitParticles = GetComponentInChildren <ParticleSystem> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();
		deathLight = GetComponent<Light> ();
		
		currentHealth = startingHealth;
	}
	
	
	void Update ()
	{
		if(isSinking)
		{
			transform.Translate (Vector3.up * sinkSpeed * Time.deltaTime);
		}
	}
	
	
	public void TakeDamage (int amount, Vector3 hitPoint)
	{
		if(isDead)
			return;
		
		enemyAudio.Play ();
		
		currentHealth -= amount;
		
		hitParticles.transform.position = hitPoint;
		hitParticles.Play();
		
		if(currentHealth <= 0)
		{
			Death ();
		}
	}
	
	
	void Death ()
	{
		isDead = true;
		
		capsuleCollider.isTrigger = true;
		
		anim.SetTrigger ("Dead");
		StartSinking ();
		deathLight.enabled = true;
		enemyAudio.clip = deathClip;
		enemyAudio.Play ();

	}
	
	
	public void StartSinking ()
	{
		GetComponent <NavMeshAgent> ().enabled = false;
		GetComponent <Rigidbody> ().isKinematic = true;
		isSinking = true;
		ScoreManager.score += scoreValue;
		Time.timeScale = 0; //pauses game, add a win scinerio here
		Destroy (gameObject, 4f);
	}
}
