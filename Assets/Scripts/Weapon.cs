using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	int ammo = 0;
	public GameObject bomb;
	//string type;
	// Use this for initialization
	void Start () {

	}

	public void shoot(Vector3 direction) {
		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;
		GameObject bombPrefab = Instantiate (bomb, new Vector3(x,y,z), Quaternion.identity) as GameObject;
		bombPrefab.GetComponent<Rigidbody2D> ().velocity = direction;
		decreaseAmmo ();
		//if ((Mathf.Abs(transform.position.x - x)) > 3 || Mathf.Abs(transform.position.y - y) > 3 || Mathf.Abs(transform.position.z - z) > 3) {
		//	bombPrefab.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
		//}
	}

	public void resetAmmo() {
		ammo = 5;
	}

	public void setAmmo(int a) {
		ammo = a;
	}

	public void decreaseAmmo() {
		ammo--;
	}

	public int getAmmo() {
		return ammo;
	}




	// Update is called once per frame
	void Update () {
	}
}