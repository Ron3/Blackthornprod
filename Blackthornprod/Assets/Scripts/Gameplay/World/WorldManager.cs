using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

	public static WorldManager Instance { private set; get; }

	private void Awake() {
		if(Instance == null) {
			Instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	public Transform roomsContainer;

	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	[SerializeField] private RoomsTemplates[] roomsTemplates;

	public GameObject GetRoomTemplate(DoorOpenings firstDir, DoorOpenings secondDir) {
		RoomsTypes neededType = GetRoomType(firstDir, secondDir);
		for(int  i = 0; i < roomsTemplates.Length; i++) {
			if(roomsTemplates[i].roomType == neededType) {
				return roomsTemplates[i].roomPrefab;
			}
		}
		Debug.LogError("Get Room Prefab error for firstDir " + firstDir + " secondDir " + secondDir);
		return null;
	}

	private RoomsTypes GetRoomType(DoorOpenings firstDir, DoorOpenings secondDir) {
		if((firstDir == DoorOpenings.Bottom && secondDir == DoorOpenings.Top) || (firstDir == DoorOpenings.Top && secondDir == DoorOpenings.Bottom)) {
			return RoomsTypes.TB;
		} else if ((firstDir == DoorOpenings.Left && secondDir == DoorOpenings.Right) || (firstDir == DoorOpenings.Right && secondDir == DoorOpenings.Left)) {
			return RoomsTypes.LR;
		} else if ((firstDir == DoorOpenings.Bottom && secondDir == DoorOpenings.Left) || (firstDir == DoorOpenings.Left && secondDir == DoorOpenings.Bottom)) {
			return RoomsTypes.BL;
		} else if ((firstDir == DoorOpenings.Bottom && secondDir == DoorOpenings.Right) || (firstDir == DoorOpenings.Right && secondDir == DoorOpenings.Bottom)) {
			return RoomsTypes.BR;
		} else if ((firstDir == DoorOpenings.Left && secondDir == DoorOpenings.Top) || (firstDir == DoorOpenings.Top && secondDir == DoorOpenings.Left)) {
			return RoomsTypes.TL;
		} else if ((firstDir == DoorOpenings.Right && secondDir == DoorOpenings.Top) || (firstDir == DoorOpenings.Top && secondDir == DoorOpenings.Right)) {
			return RoomsTypes.TR;
		}
		Debug.LogError("Get Room Type error for firstDir " + firstDir + " secondDir " + secondDir);
		return RoomsTypes.L;
	}

}

[Serializable] public struct RoomsTemplates
{
	public RoomsTypes roomType;
	public GameObject roomPrefab;
}

public enum RoomsTypes
{
	L,
	LR,
	R,
	T,
	TL,
	TR,
	B,
	BL,
	BR,
	TB
}

public enum DoorOpenings
{
	Top,
	Bottom,
	Right,
	Left
}