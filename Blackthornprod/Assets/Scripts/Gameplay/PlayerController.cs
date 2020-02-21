using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Action wInputAction;
	public Action aInputAction;
	public Action sInputAction;
	public Action dInputAction;

	public Action UpArrowAction;
	public Action DownArrowAction;
	public Action LeftArrowAction;
	public Action RightArrowAction;

	public Action UpdateAction;


	public static PlayerController Instance { private set; get; }
	private void Awake() {
		if(Instance == null) {
			Instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	[SerializeField] private Character character;

	private void Start() {
		ActionsController.Instance.onStartGame += OnStartGame;
	}

	public float CharacterMaxHealth {
		get {
			return character.maxHealth;
		}
	}

	public Transform CharacterTransform {
		get {
			return character.transform;
		}
	}

	public float CharacterHealth {
		get {
			return character.health;
		}
	}

	private void OnStartGame() {
		character.transform.position = Vector2.zero;
		character.StartGame();
	}

	private void Update() {

		if (Input.GetKeyDown(KeyCode.Return)) {
			ActionsController.Instance.SendOnEnterPressed();
		} else if (Input.GetKeyDown(KeyCode.Space)) {
			ActionsController.Instance.SendOnSpacePressed();
		} else if (Input.GetKeyDown(KeyCode.Escape)) {
			ActionsController.Instance.SendOnEscPressed();
		}

		bool inIdle = true;
		if (Input.GetKey(KeyCode.W)) {
			character.MoveUp();
			character.StartWalk();
			inIdle = false;

			if(this.wInputAction != null)
			{
				this.wInputAction();
			}
		}
		if (Input.GetKey(KeyCode.S)) {
			character.MoveDown();
			character.StartWalk();
			inIdle = false;

			if(this.sInputAction != null)
			{
				this.sInputAction();
			}
		}
		if (Input.GetKey(KeyCode.A)) {
			character.MoveLeft();
			character.StartWalk();
			inIdle = false;

			if(this.aInputAction != null)
			{
				this.aInputAction();
			}	
		}
		if (Input.GetKey(KeyCode.D)) {
			character.MoveRight();
			character.StartWalk();
			inIdle = false;

			if(this.dInputAction != null)
			{
				this.dInputAction();
			}
		}

		if (inIdle) {
			character.StartIdle();
		}

		// if (Input.GetKey(KeyCode.UpArrow)) {
		// 	character.Shoot(Vector3.up);
		// } else if (Input.GetKey(KeyCode.DownArrow)) {
		// 	character.Shoot(Vector3.down);
		// } else if (Input.GetKey(KeyCode.LeftArrow)) {
		// 	character.Shoot(Vector3.left);
		// } else if (Input.GetKey(KeyCode.RightArrow)) {
		// 	character.Shoot(Vector3.right);
		// }

		// TODO Ron
		if (Input.GetKey(KeyCode.UpArrow) && this.UpArrowAction != null) 
		{
			this.UpArrowAction();
		} 
		else if (Input.GetKey(KeyCode.DownArrow) && this.DownArrowAction != null) 
		{
			this.DownArrowAction();
		}
		else if (Input.GetKey(KeyCode.LeftArrow) && this.LeftArrowAction != null) 
		{
			this.LeftArrowAction();
		}
		else if (Input.GetKey(KeyCode.RightArrow) && this.RightArrowAction != null) 
		{
			this.RightArrowAction();
		}

		if(this.UpdateAction != null)
		{
			this.UpdateAction();
		}
	}

}
