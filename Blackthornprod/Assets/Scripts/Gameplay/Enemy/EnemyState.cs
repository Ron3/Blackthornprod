using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour {

	protected EnemyBase enemyRef;
	protected Transform target;
	protected RoomTemplate roomRef;

	public virtual void OnEnter( EnemyBase enemyBase, Transform characterTransform, RoomTemplate room ) {
		enemyRef = enemyBase;
		target = characterTransform;
		roomRef = room;
	}
	public virtual void OnExit() { }
	public virtual void OnUpdate() { }

}
