using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject pickup;
	//public GameObject player;
	public Vector3 spawnValues;
	private float lifetime = 10.0f;
	
	void Start() {
		InvokeRepeating("Spawn", 0.0f, 11.0f);
	}

	void Spawn() {
		for (int i = 0; i < 5; i++)
			SpawnPickup();
	}

	void SpawnPickup() {
		Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x,spawnValues.x),Random.Range(-spawnValues.y,spawnValues.y),spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Destroy (Instantiate (pickup, spawnPosition, spawnRotation), lifetime);
	}

/*	public void SpawnAtPosition() {
		Vector3 spawnPosition = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
		Quaternion spawnRotation = Quaternion.identity;
		Destroy (Instantiate (pickup, spawnPosition, spawnRotation), lifetime);
	}
*/
}