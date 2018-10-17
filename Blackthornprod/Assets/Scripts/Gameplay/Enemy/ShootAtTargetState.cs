using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtTargetState : EnemyState {

	[SerializeField] private int roundsPerShot;
	[SerializeField] private float waitTime;
	[SerializeField] private float attackSpeed;
	[SerializeField] private float attackForce;
	[SerializeField] private float bulletDamage;
	[SerializeField] private EnemyBullet bulletPref;

	private int currentRound;
	private float currentWaitTime;

	public override void OnEnter(EnemyBase enemyBase, Transform characterTransform, RoomTemplate room) {
		base.OnEnter(enemyBase, characterTransform, room);
		currentRound = 0;
		currentWaitTime = Random.Range(0.5f, waitTime);
		EndShoot();
	}

	public override void OnUpdate() {
		base.OnUpdate();
	}

	public override void OnExit() {
		base.OnExit();
		StopAllCoroutines();
	}
	
	private void StartShoot() {
		StopAllCoroutines();
		StartCoroutine("ShootCoroutine");
	}

	private void EndShoot() {
		StopAllCoroutines();
		StartCoroutine("WaitCoroutine");
	}

	IEnumerator WaitCoroutine() {
		yield return new WaitForSeconds(currentWaitTime);
		StartShoot();
	}

	IEnumerator ShootCoroutine() {
		while(currentRound < roundsPerShot) { 
			Shoot();
			currentRound++;
			yield return new WaitForSeconds(attackSpeed);
		}
		currentRound = 0;
		EndShoot();
	}

	private void Shoot() {
		Vector2 dir = target.position - transform.position;
		EnemyBullet bullet = Instantiate(bulletPref, transform.position, Quaternion.identity, WorldManager.Instance.currentRoom.transform);
		bullet.Shoot(dir, attackForce, bulletDamage);
	}

	private void OnDestroy() {
		StopAllCoroutines();
	}

}
