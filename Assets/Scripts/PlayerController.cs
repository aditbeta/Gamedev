using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float bombSpeed;
	public Text countText;
	public Text winText;
	public float fireRate;
	public GameObject bomb;
	public Transform bombObject;
	public Vector3 direction;

	private float nextFire;
	private Rigidbody2D rb2d;
	private int count;
	private float magicNumber = (float)1.41421333333;

	void Start() {
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate (){
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D)) {
			direction = (transform.up * 1 + transform.right * 1) * (bombSpeed / magicNumber);
		} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A)) {
			direction = (transform.up * 1 + transform.right * -1) * (bombSpeed / magicNumber);
		} else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D)) {
			direction = (transform.up * -1 + transform.right * 1) * (bombSpeed / magicNumber);
		} else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A)) {
			direction = (transform.up * -1 + transform.right * -1) * (bombSpeed / magicNumber);
		} else if (Input.GetKey (KeyCode.W)) {
			direction = transform.up * 1 * bombSpeed;
			} else if (Input.GetKey (KeyCode.S)) {
			direction = transform.up * -1 * bombSpeed;
			} else if (Input.GetKey (KeyCode.D)) {
			direction = transform.right * 1 * bombSpeed;
			} else if (Input.GetKey (KeyCode.A)) {
			direction = transform.right * -1 * bombSpeed;
		}
			
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (GetComponent<Weapon> ().getAmmo () > 0) {
				GetComponent<Weapon> ().shoot (direction);
				SetCountText ();
			}
		}
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.GetComponent<Rigidbody2D> ().velocity = movement * speed;

	}

	void OnTriggerStay2D(Collider2D other) {
		if (Input.GetKeyDown (KeyCode.Backspace)) {
			if (other.gameObject.CompareTag ("PickUp")) {
				Debug.Log ("pick");
				GetComponent<Weapon> ().resetAmmo ();
				other.gameObject.SetActive (false);
				SetCountText ();
			}
		}
	}

	void SetCountText() {
		countText.text = "Ammo: " + GetComponent<Weapon>().getAmmo().ToString ();

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

/*		if (Input.GetKeyDown (KeyCode.Backspace)) {
			if (GetComponent<Weapon> ().getAmmo () > 0) {
				GetComponent<GameController> ().SpawnAtPosition ();
			}
		}*/
	}

}