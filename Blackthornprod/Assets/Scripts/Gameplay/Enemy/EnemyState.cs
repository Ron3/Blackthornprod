using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour {

	protected EnemyBase enemyRef;
	protected Transform target;
	protected RoomTemplate roomRef;
	protected Vector2 initPos;

	public virtual void OnEnter( EnemyBase enemyBase, Transform characterTransform, RoomTemplate room ) {
		enemyRef = enemyBase;
		target = characterTransform;
		roomRef = room;
	}
	public virtual void OnExit() {
		initPos = roomRef.GetRandomPosition();
		target = null;
		roomRef = null;
	}
	public virtual void OnUpdate() { }

}
