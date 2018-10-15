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

		if (Input.GetKey(KeyCode.UpArrow)) {
			character.ShootUp();
		} else if (Input.GetKey(KeyCode.DownArrow)) {
			character.ShootDown();
		} else if (Input.GetKey(KeyCode.LeftArrow)) {
			character.ShootLeft();
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			character.ShootRight();
		}
	}

}
