using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : EnemyState {

	[SerializeField] private float waitTime;

	public override void OnEnter(EnemyBase enemyBase, Transform characterTransform, RoomTemplate room) {
		base.OnEnter(enemyBase, characterTransform, room);
		Invoke("OnWaitFinished", waitTime);
	}

	public override void OnExit() {
		base.OnExit();
		CancelInvoke();
	}

	private void OnWaitFinished() {
		enemyRef.ChangeState();
	}

}
