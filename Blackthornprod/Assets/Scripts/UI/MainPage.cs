using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPage : MenuPage {

	public override void OnShow() {
		ActionsController.Instance.onEnterPressed += OnAction;
	}

	public override void OnHide() {
		ActionsController.Instance.onEnterPressed -= OnAction;
	}

	private void OnAction() {
		UIManager.Instance.ChangePage(MenuPages.StoryPage);
	}

}
