using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyBase {

	protected override void Kill() {
		Instantiate(GameManager.Instance.gamePrefab, transform.position, Quaternion.identity, WorldManager.Instance.currentRoom.transform);
		Destroy(gameObject);
	}

}
