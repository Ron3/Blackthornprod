using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { private set; get; }

	private void Awake() {
		if(Instance == null) {
			Instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	[SerializeField] private GameObject mainSceneCamera;
	[SerializeField] private List<LevelInfo> levelInfo;

	private int currentLevel;

	public LevelInfo CurrentLevelInfo {
		get {
			return levelInfo[currentLevel];
		}
	}

	private void Start() {
		currentLevel = 0;
		LoadWorld();
	}

	private void LoadWorld() {
		Destroy(mainSceneCamera);
		SceneManager.LoadScene(1, LoadSceneMode.Additive);
	}
}

[Serializable]
public struct LevelInfo
{
	public int maxNbOfRooms;
	public int maxNbOfEnemiesPerRoom;
	public int enemySpawnChance;
	public EnemyBase levelBoss;
	public List<EnemyBase> enemiesPrefabs;
}