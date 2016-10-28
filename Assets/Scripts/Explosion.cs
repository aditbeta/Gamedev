using UnityEngine;
using System.Collections;


//buat nampilin sprite ledakan
public class Explosion : MonoBehaviour {

	public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
	
	}

	public void Explode() {
		Instantiate(explosionPrefab, transform.position, Quaternion.identity);
		//		GetComponent<MeshRenderer>().enabled = false;
		//		transform.FindChild("Collider").gameObject.SetActive(false);
		Destroy(gameObject, .3f);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
