using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGamePage : MenuPage {

	[SerializeField] private GameObject playerHealth;
	[SerializeField] private GameObject bossHealth;
	[SerializeField] private Image playerBar;
	[SerializeField] private Image bossBar;

	private bool isOnBoss;

	public override void OnShow() {
		isOnBoss = false;
		bossHealth.SetActive(false);
		ActionsController.Instance.onEscPressed += OnAction;
		ActionsController.Instance.onBossActivate += BossActivate;
		ActionsController.Instance.SendOnStartGame();
	}

	public override void OnHide() {
		ActionsController.Instance.SendOnEndGame();
		ActionsController.Instance.onEscPressed -= OnAction;
		ActionsController.Instance.onBossActivate -= BossActivate;
	}

	private void BossActivate() {
		isOnBoss = true;
		bossHealth.SetActive(true);
	}

	private void OnAction() {
		UIManager.Instance.ChangePage(MenuPages.MainPage);
	}

	private void Update() {
		playerBar.fillAmount = PlayerController.Instance.CharacterHealth / PlayerController.Instance.CharacterMaxHealth;
		if (isOnBoss) {
			bossBar.fillAmount = WorldManager.Instance.boosRoom.boss.health / WorldManager.Instance.boosRoom.boss.maxHealth;
		}
	}

}
