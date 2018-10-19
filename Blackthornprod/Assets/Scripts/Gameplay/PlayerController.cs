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

	public Transform CharacterTransform {
		get {
			return character.transform;
		}
	}

	private void Update() {
		bool inIdle = true;
		if (Input.GetKey(KeyCode.W)) {
			character.MoveUp();
			character.StartWalk();
			inIdle = false;
		}
		if (Input.GetKey(KeyCode.S)) {
			character.MoveDown();
			character.StartWalk();
			inIdle = false;
		}
		if (Input.GetKey(KeyCode.A)) {
			character.MoveLeft();
			character.StartWalk();
			inIdle = false;
		}
		if (Input.GetKey(KeyCode.D)) {
			character.MoveRight();
			character.StartWalk();
			inIdle = false;
		}

		if (inIdle) {
			character.StartIdle();
		}

		if (Input.GetKey(KeyCode.UpArrow)) {
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
