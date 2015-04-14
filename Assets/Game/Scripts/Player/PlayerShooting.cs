using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{

    public static int damagePerShot;
    public float timeBetweenBullets = 0.3f;
    public float range = 100f;
	public float ammo = 10;
	public Slider ammoslider;

	

	public AudioClip drawback;

	

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;


    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
    }


		void Update ()
    {
        timer += Time.deltaTime;

		if (ScoreManager.curlevel == 1) 
		
		{
			damagePerShot = 60;
		}	


		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
			if(ammo > 0)
			{
            Shoot ();
			ammo = ammo - 1;
			ammoslider.value = ammo;
			}
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }

		if (Input.GetButton ("Fire2") || Input.GetKey(KeyCode.R)) 
		{

			audio.PlayOneShot(drawback);
			
			if(!audio.isPlaying)
			{
				int i = 1;
				if (i == 1)
				{
					ammo = 10;
					ammoslider.value = ammo;
					i = 0;
				}
			}

		}
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {
        timer = 0f;

        gunAudio.Play ();

        gunLight.enabled = true;

        gunParticles.Stop ();
        gunParticles.Play ();

        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            }
			KingHealth kingHealth = shootHit.collider.GetComponent<KingHealth> ();
			if(kingHealth != null)
			{
				kingHealth.TakeDamage (damagePerShot, shootHit.point);
			}


            gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }
}
