using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : EnemyState {

	[SerializeField] private float animTime;
	[SerializeField] private float waitTime;
	[SerializeField] private AnimationCurve animCurve;

	private float startTime;
	private Vector2 startPos;
	private Vector2 endPos;
	private bool isMoving;
	private float currentWaitTime;

	public override void OnEnter(EnemyBase enemyBase, Transform characterTransform, RoomTemplate room) {
		base.OnEnter(enemyBase, characterTransform, room);
		currentWaitTime = Random.Range(0f, waitTime);
		StopCoroutine("WaitCoroutine");
		StartCoroutine("WaitCoroutine");
	}

	public override void OnExit() {
		base.OnExit();
		isMoving = false;
		enemyRef.transform.position = initPos;
		StopCoroutine("WaitCoroutine");
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
		endPos = target.position;
		isMoving = true;
	}
	private void UpdateMove() {
		float timeSinceStart = Time.time - startTime;
		float percentage = timeSinceStart / animTime;
		enemyRef.gameObject.transform.position = Vector3.Lerp(startPos, endPos, animCurve.Evaluate(percentage));
		if (percentage >= 1.0f) {
			isMoving = false;
			StopCoroutine("WaitCoroutine");
			StartCoroutine("WaitCoroutine");
		}
	}

	IEnumerator WaitCoroutine() {
		yield return new WaitForSeconds(currentWaitTime);
		OnStartAnim();
	}
}
