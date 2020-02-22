using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public int oldSceneIndex = 1;
	public int newSceneIndex = 2;
	
	public int sceneIndex = 2;
	public static GameManager Instance { private set; get; }

	private void Awake() {
		if(Instance == null) {
			Instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	public GameObject heartPrefab;
	public GameObject gamePrefab;
 	[SerializeField] private GameObject mainSceneCamera;
	[SerializeField] private List<LevelInfo> levelInfo;



	private int currentLevel;

	public LevelInfo CurrentLevelInfo {
		get {
			return levelInfo[currentLevel];
		}
	}

	private void Start() {
		ActionsController.Instance.onStartGame += LoadWorld;
		ActionsController.Instance.onEndGame += OnPlayerDeath;
		currentLevel = 0;
		UIManager.Instance.ChangePage(MenuPages.MainPage);
	}

	private void OnPlayerDeath() {
		currentLevel = 0;
		// SceneManager.UnloadSceneAsync(1);
		SceneManager.UnloadSceneAsync(sceneIndex);
		mainSceneCamera.gameObject.SetActive(true);
	}

	private void LoadWorld() {
		mainSceneCamera.gameObject.SetActive(false);
		// SceneManager.LoadScene(1, LoadSceneMode.Additive);
		SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
	}
}

[Serializable]
public struct LevelInfo
{
	public int maxNbOfRooms;
	public int maxNbOfEnemiesPerRoom;
	public int enemySpawnChance;
	public Boss levelBoss;
	public List<EnemyBase> enemiesPrefabs;
}