using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour {
	
	[SerializeField] private List<Door> doors;

	private float maxX = 7.5f;
	private float maxY = 3.5f;

	public Boss boss;
	private List<EnemyBase> spawnedEnemies = new List<EnemyBase>();

	private void Start() {
		foreach(Door d in doors) {
			d.InitDoorWithRoom(this);
		}
		if (!gameObject.name.Contains("CRoom") && !gameObject.name.Contains("ClosedRoom")) {
			CreateEnemies();
		}
	}

	public void DeactivateRoom() {
		for(int i =0; i< spawnedEnemies.Count; i++) {
			if(spawnedEnemies[i] != null) {
				spawnedEnemies[i].Deactivate();
			}
		}
	}

	public void ActivateRoom() {

		if(boss != null) {
			boss.Activate(this);
			ActionsController.Instance.SendOnBossActivate();
			return;
		}

		for(int i = 0; i < spawnedEnemies.Count; i++) {
			if (spawnedEnemies[i] != null) {
				spawnedEnemies[i].Activate(this);
			}
		}
	}

	public void AddBoss() {
		ClearEnemies();
		boss = Instantiate(GameManager.Instance.CurrentLevelInfo.levelBoss, transform.position, Quaternion.identity, transform);
	}

	public Vector2 ClampedPos {
		get {
			return transform.position + new Vector3(maxX, maxY, 0f);
		}
	}

	public Vector3 GetRandomPosition() {
		float randX = Random.Range(-maxX, maxX);
		float randY = Random.Range(-maxY, maxY);
		return transform.position + new Vector3(randX, randY, 0f);
	}

	private void CreateEnemies() {
		LevelInfo ll = GameManager.Instance.CurrentLevelInfo;
		int spawnChance = Random.Range(0, ll.enemySpawnChance);
		if(spawnChance == 0 || spawnChance == 1) {
			int enemyNb = Random.Range(1, ll.maxNbOfEnemiesPerRoom);
			int enemyType = Random.Range(0, ll.enemiesPrefabs.Count);
			for(int i = 0; i < enemyNb; i++) {
				EnemyBase tmpEnemy = Instantiate(ll.enemiesPrefabs[enemyType], GetRandomPosition(), Quaternion.identity, transform);
				spawnedEnemies.Add(tmpEnemy);
			}
		}
	}

	private void ClearEnemies() {
		for(int i = 0; i < spawnedEnemies.Count; i++) {
			Destroy(spawnedEnemies[i].gameObject);
		}
		spawnedEnemies.Clear();
	}

}
