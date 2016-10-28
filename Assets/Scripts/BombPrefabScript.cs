using UnityEngine;
using System.Collections;

public class BombPrefabScript : MonoBehaviour {

	private float timeCounter;
	private float timeStopper = 1;



	// Use this for initialization
	void Start () {
	}



	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime;
		if (timeCounter >= timeStopper) {
			GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
//			GetComponent<Explosion>().Explode ();
			Destroy (gameObject, .3f);
		}
	}
}
