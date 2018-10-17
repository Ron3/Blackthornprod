using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCamera : MonoBehaviour {

	[SerializeField] private float timeToChange;
	[SerializeField] private AnimationCurve moveCurve;

	private float changeStartTime;
	private Vector3 startPos;
	private Vector3 endPos;

	private bool isLerping;

	private void Start() {
		ActionsController.Instance.onChangeCameraPosition += OnChangeRoom;
	}

	private void OnDestroy() {
		ActionsController.Instance.onChangeCameraPosition -= OnChangeRoom;
	}

	private void OnChangeRoom(Vector3 roomPos) {
		if (!IsTheSameRoom(roomPos)) {
			changeStartTime = Time.time;
			startPos = transform.position;
			endPos = new Vector3(roomPos.x, roomPos.y, transform.position.z);
			isLerping = true;
		}
	}

	private void Update() {
		if (isLerping) {
			UpdateChange();
		}
	}

	private void UpdateChange() {
		float timeSinceStarted = Time.time - changeStartTime;
		float percentage = timeSinceStarted / timeToChange;
		transform.position = Vector3.Lerp(startPos, endPos, moveCurve.Evaluate(percentage));
		if(percentage >= 1.0f) {
			transform.position = endPos;
			isLerping = false;
		}
	}

	private bool IsTheSameRoom(Vector3 roomPos) {
		if(roomPos.x == transform.position.x && roomPos.y == transform.position.y) {
			return true;
		}
		return false;
	}

}
