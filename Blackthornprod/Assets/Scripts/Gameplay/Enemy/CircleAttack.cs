using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAttack : EnemyState {

	[SerializeField] private int direction;
	[SerializeField] private float rotation;
	[SerializeField] private GameObject spawnPointGo;
	[SerializeField] private Transform spawnPoint;
	[SerializeField] private float attackRate;
	[SerializeField] private float attackForce;
	[SerializeField] private float attackTime;
	[SerializeField] private float attackDamage;
	[SerializeField] private AnimationCurve attackCurve;
	[SerializeField] private EnemyBullet bulletPrefab;

	private float startTime;
	private Vector3 startRot;
	private Vector3 endRot;
	private bool isAttacking;
	private float currentShootTime;

	public override void OnEnter(EnemyBase enemyBase, Transform characterTransform, RoomTemplate room) {
		base.OnEnter(enemyBase, characterTransform, room);
		StartAttack();
		Debug.Log("startAttack");
	}

	public override void OnUpdate() {
		base.OnUpdate();
		if (isAttacking) {
			OnAttacking();
		}
	}

	public override void OnExit() {
		base.OnExit();
		isAttacking = false;
	}

	private void StartAttack() {
		startTime = Time.time;
		startRot = direction == 1 ? Vector3.zero : new Vector3(0f,0f,rotation);
		endRot = direction == 1 ? new Vector3(0f, 0f, rotation) : Vector3.zero;
		isAttacking = true;
		currentShootTime = 0;
	}

	private void OnAttacking() {
		float timeSinceStarted = Time.time - startTime;
		float percentage = timeSinceStarted / attackTime;
		currentShootTime += Time.deltaTime;
		spawnPointGo.transform.rotation = Quaternion.Euler(Vector3.Lerp(startRot, endRot, attackCurve.Evaluate(percentage)));
		if(currentShootTime > attackRate) {
			Shoot();
		}
		if (percentage >= 1.0f) {
			spawnPoint.transform.rotation = Quaternion.Euler(endRot);
			enemyRef.ChangeState();
		}
	}

	private void Shoot() {
		currentShootTime = 0f;
		Vector2 dir = spawnPoint.position - spawnPointGo.transform.position;
		EnemyBullet bullet = Instantiate(bulletPrefab, spawnPointGo.transform.position, Quaternion.identity, WorldManager.Instance.currentRoom.transform);
		bullet.Shoot(dir, attackForce, attackDamage);
	}
}
