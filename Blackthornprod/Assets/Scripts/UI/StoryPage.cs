using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryPage : MenuPage {

	[SerializeField] private bool isEndStory;
	[SerializeField] List<Image> storyImages;

	private Image currentImage;
	private int currentIndex;

	public override void OnShow() {
		ActionsController.Instance.onEnterPressed += OnAction;
		if(currentImage != null) {
			currentImage.gameObject.SetActive(false);
		}
		currentIndex = 0;
		ShowCurrentImage();
	}

	public override void OnHide() {
		ActionsController.Instance.onEnterPressed -= OnAction;
	}

	private void OnAction() {
		currentIndex++;
		if(currentIndex < storyImages.Count) {
			currentImage.gameObject.SetActive(false);
			ShowCurrentImage();
		} else {
			if (!isEndStory) {
				UIManager.Instance.ChangePage(MenuPages.InGamePage);
			} else {
				UIManager.Instance.ChangePage(MenuPages.MainPage);
			}
		}
	}

	private void ShowCurrentImage() {
		currentImage = storyImages[currentIndex];
		currentImage.gameObject.SetActive(true);
	}


}
