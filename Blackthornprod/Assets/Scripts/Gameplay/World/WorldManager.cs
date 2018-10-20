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

	[SerializeField] private float addBossWaitTime;
	public Transform roomsContainer;
	public GameObject closedRoom;

	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	[SerializeField] private RoomsTemplates[] roomsTemplates;
	private List<RoomTemplate> roomList;

	private RoomTemplate startRoom;
	private RoomTemplate endRoom;

	public RoomTemplate boosRoom;

	public bool CanCreateRoom {
		get {
			return roomList.Count < GameManager.Instance.CurrentLevelInfo.maxNbOfRooms;
		}
	}

	public RoomTemplate currentRoom { private set; get; }

	public bool IsRoomCreatedOnPos(Vector3 position) {
		for(int i = 0; i < roomList.Count; i++) {
			if(roomList[i].transform.position == position) {
				return true;
			}
		}
		return false;
	}

	private void Start() {
		ActionsController.Instance.onChangeRoom += OnChangeRoom;
		CreateRooms();
		Invoke("AddBoss", addBossWaitTime);
	}

	private void OnDestroy() {
		ActionsController.Instance.onChangeRoom -= OnChangeRoom;
	}

	private void CreateRooms() {
		roomList = new List<RoomTemplate>();
		RoomTemplate roomPrefab = GetRoomTemplate(RoomsTypes.C).GetComponent<RoomTemplate>();
		RoomTemplate room = Instantiate(roomPrefab, transform.position, roomPrefab.transform.rotation, roomsContainer);
		startRoom = room;
		currentRoom = startRoom;
		currentRoom.ActivateRoom();
		AddRoom(room);
	}

	private void AddBoss() {
		for(int i = roomList.Count - 1; i >= 0; i--) {
			if(roomList[i].gameObject.name != "ClosedRoom") {
				roomList[i].AddBoss();
				boosRoom = roomList[i];
				return;
			}
		}
	}

	public GameObject GetRoomTemplate(DoorOpenings firstDir, DoorOpenings secondDir) {
		RoomsTypes neededType = GetRoomType(firstDir, secondDir);
		GetRoomTemplate(neededType);
		Debug.LogError("Get Room Prefab error for firstDir " + firstDir + " secondDir " + secondDir);
		return null;
	}

	private GameObject GetRoomTemplate(RoomsTypes roomType) {
		for (int i = 0; i < roomsTemplates.Length; i++) {
			if (roomsTemplates[i].roomType == roomType) {
				return roomsTemplates[i].roomPrefab;
			}
		}
		Debug.LogError("Get Room Prefab error for type " + roomType);
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

	public void AddRoom(RoomTemplate template) {
		roomList.Add(template);
	}

	public void OnChangeRoom(RoomTemplate template) {
		if(currentRoom.gameObject.transform.GetSiblingIndex() != template.gameObject.transform.GetSiblingIndex()) {
			currentRoom.DeactivateRoom();
			currentRoom = template;
			currentRoom.ActivateRoom();
		}
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
	TB,
	C
}

public enum DoorOpenings
{
	Top,
	Bottom,
	Right,
	Left
}