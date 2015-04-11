using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
	public KingHealth kingHealth;


    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
				//if(playerHealth.currentHealth <= 0f || kingHealth.currentHealth <= 0f)
				if (playerHealth.currentHealth <= 0f) {
						return;
				} else {
						int spawnPointIndex = Random.Range (0, spawnPoints.Length);

						Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
				}
		}
}
