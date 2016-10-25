using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject pickup;
	public Vector3 spawnValues;

	private float lifetime = 5.0f;
	
	void Start() {
		InvokeRepeating("Spawn", 0.0f, 6.0f);
	}

	void Spawn() {
		for (int i = 0; i < 12; i++)
			SpawnPickup();
	}

	void SpawnPickup() {
		Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x,spawnValues.x),Random.Range(-spawnValues.y,spawnValues.y),spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Destroy (Instantiate (pickup, spawnPosition, spawnRotation), lifetime);
	}

}