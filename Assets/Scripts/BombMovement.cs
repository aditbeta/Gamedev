﻿using UnityEngine;
using System.Collections;

public class BombMovement : MonoBehaviour {

	public float speed;

	void Start () {
		GetComponent<Rigidbody2D>().velocity = transform.forward * speed;
	}

}
