using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDestroyer : MonoBehaviour {

	private void Start() {
		Invoke("ClearDestroyer", 2f);
	}

	private void ClearDestroyer() {
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("SpawnPoint")) {
			Destroy(collision.gameObject);
		}
	}
}
