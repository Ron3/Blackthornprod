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

	private void Start() {
		Destroy(mainSceneCamera);
		SceneManager.LoadScene(1, LoadSceneMode.Additive);
	}
}
