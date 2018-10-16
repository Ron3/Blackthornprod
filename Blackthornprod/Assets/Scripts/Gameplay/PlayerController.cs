using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public static PlayerController Instance { private set; get; }
	private void Awake() {
		if(Instance == null) {
			Instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	[SerializeField] private Character character;

	private void Update() {
		if (Input.GetKey(KeyCode.W)) {
			character.MoveUp();
		}
		if (Input.GetKey(KeyCode.S)) {
			character.MoveDown();
		}
		if (Input.GetKey(KeyCode.A)) {
			character.MoveLeft();
		}
		if (Input.GetKey(KeyCode.D)) {
			character.MoveRight();
		}

		if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)) {
			character.Shoot(Vector3.up + Vector3.left);
		} else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)) {
			character.Shoot(Vector3.up + Vector3.right);
		} else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)) {
			character.Shoot(Vector3.down + Vector3.left);
		} else if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)) {
			character.Shoot(Vector3.down + Vector3.right);
		} else if (Input.GetKey(KeyCode.UpArrow)) {
			character.Shoot(Vector3.up);
		} else if (Input.GetKey(KeyCode.DownArrow)) {
			character.Shoot(Vector3.down);
		} else if (Input.GetKey(KeyCode.LeftArrow)) {
			character.Shoot(Vector3.left);
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			character.Shoot(Vector3.right);
		}
	}

}
