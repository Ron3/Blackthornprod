using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	private Transform roomTransform;

	public Vector3 RoomPosition {
		get {
			return roomTransform.position;
		}
	}

	public void InitDoorWithRoom(Transform room) {
		roomTransform = room;
	}

}
