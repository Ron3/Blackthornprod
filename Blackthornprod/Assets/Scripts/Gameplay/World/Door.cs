using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	private RoomTemplate roomRef;

	public Vector3 RoomPosition {
		get {
			return roomRef.transform.position;
		}
	}

	public void InitDoorWithRoom(RoomTemplate room) {
		roomRef = room;
	}

}
