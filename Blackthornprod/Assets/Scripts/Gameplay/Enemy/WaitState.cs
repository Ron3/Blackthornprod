using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : EnemyState {

	[SerializeField] private Animator anim;
	[SerializeField] private float waitTime;
	[SerializeField] private float beforeAttackTime;

	public override void OnEnter(EnemyBase enemyBase, Transform characterTransform, RoomTemplate room) {
		base.OnEnter(enemyBase, characterTransform, room);
		anim.SetBool("BeforeAttack", false);
		anim.SetBool("Attacking", false);
		Invoke("OnWaitFinished", waitTime);
	}

	public override void OnExit() {
		base.OnExit();
		CancelInvoke();
	}

	private void OnWaitFinished() {
		anim.SetBool("BeforeAttack", true);
		Invoke("OnBeforeAttack", beforeAttackTime);
	}

	private void OnBeforeAttack() {
		anim.SetBool("Attacking", true);
		enemyRef.ChangeState();
	}

}
