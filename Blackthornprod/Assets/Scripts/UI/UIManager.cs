using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	public static UIManager Instance { private set; get; }

	private void Awake() {
		if(Instance == null) {
			Instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	[SerializeField] List<MenuPage> menuPages;
	// [SerializeField] List<GameObject> testPages;

	private MenuPage currentPage;

	public void ChangePage(MenuPages page) {
		if(currentPage != null) {
			currentPage.OnHide();
			currentPage.gameObject.SetActive(false);
		}
		currentPage = menuPages[(int)page];
		currentPage.gameObject.SetActive(true);
		currentPage.OnShow();
	}
}

public enum MenuPages
{
	MainPage,
	InGamePage,
	EndStoryPage
}
