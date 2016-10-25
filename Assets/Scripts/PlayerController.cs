using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public float fireRate;
	public GameObject bomb;
	public Transform bombObject;

	private float nextFire;
	private Rigidbody2D rb2d;
	private int count;

	void Start() {
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate (){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.AddForce (movement * speed);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
			count += 1;
			SetCountText ();
		}
	}

	void SetCountText() {
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Win";
		}
	}

	void Update() {
		if (Input.GetButton("Jump") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			//GameObject clone = 
			Instantiate (bomb, bombObject.position, bombObject.rotation);// as GameObject;
		}
	}

}