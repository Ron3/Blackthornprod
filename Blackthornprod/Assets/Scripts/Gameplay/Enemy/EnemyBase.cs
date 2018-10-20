using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IActivable, IDamageble {

	[SerializeField] private RoomTemplate debugRoom;

	public float maxHealth;
	[SerializeField] public float health;
	[SerializeField] protected List<EnemyState> enemyStates;
	
	private EnemyState currentState;
	private int currentStateIndex;

	public void Activate(RoomTemplate roomRef) {
		health = maxHealth;
		currentStateIndex = 0;
		currentState = enemyStates[currentStateIndex];
		currentState.OnEnter(this, PlayerController.Instance.CharacterTransform, roomRef);
	}

	public void Deactivate() {
		currentStateIndex = 0;
		currentState.OnExit();
	}

	public void TakeDamage(float damage) {
		health -= damage;
		if(health <= 0f) {
			Kill();
		}
	}

	public void ChangeState() {
		currentStateIndex++;
		if(currentStateIndex == enemyStates.Count) {
			currentStateIndex = 0;
		}
		currentState.OnExit();
		currentState = enemyStates[currentStateIndex];
		currentState.OnEnter(this, PlayerController.Instance.CharacterTransform, WorldManager.Instance.currentRoom);
	}

	protected virtual void Update() {
		if(currentState != null) {
			currentState.OnUpdate();
		}
	}

	protected virtual void Kill() {
		int rand = Random.Range(0, 4);
		if(rand == 1) {
			Instantiate(GameManager.Instance.heartPrefab, transform.position, Quaternion.identity, WorldManager.Instance.currentRoom.transform);
		}
		Destroy(gameObject);
	}

}
