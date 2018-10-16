using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMoveState : EnemyState {

	[SerializeField] private float animTime;
	[SerializeField] private float waitTime;
	[SerializeField] private AnimationCurve animCurve;

	private float startTime;
	private Vector2 startPos;
	private Vector2 endPos;
	private bool isMoving;

	public override void OnEnter(EnemyBase enemyBase, Transform characterTransform, RoomTemplate room) {
		base.OnEnter(enemyBase, characterTransform, room);
		StopCoroutine("WaitCoroutine");
		StartCoroutine("WaitCoroutine");
	}

	public override void OnExit() {
		base.OnExit();
	}

	public override void OnUpdate() {
		base.OnUpdate();
		if (isMoving) {
			UpdateMove();
		}
	}

	private void OnStartAnim() {
		startTime = Time.time;
		startPos = enemyRef.gameObject.transform.position;
		endPos = roomRef.GetRandomPosition();
		isMoving = true;
	}
	private void UpdateMove() {
		float timeSinceStart = Time.time - startTime;
		float percentage = timeSinceStart / animTime;
		enemyRef.gameObject.transform.position = Vector3.Lerp(startPos, endPos, animCurve.Evaluate(percentage));
		if(percentage >= 1.0f) {
			isMoving = false;
			StopCoroutine("WaitCoroutine");
			StartCoroutine("WaitCoroutine");
		}
	}

	IEnumerator WaitCoroutine() {
		yield return new WaitForSeconds(waitTime);
		OnStartAnim();
	}

}
