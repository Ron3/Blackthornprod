using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

	[SerializeField] public DoorOpenings openingDirection;

	private bool spawnedRoom = false;

	private void Start() {
		SpawnRoom();
	}

	public void SpawnRoom() {
		if (!spawnedRoom) {
			switch (openingDirection) {
				case DoorOpenings.Bottom:
					CreateRoom(WorldManager.Instance.bottomRooms);
					break;
				case DoorOpenings.Top:
					CreateRoom(WorldManager.Instance.topRooms);
					break;
				case DoorOpenings.Left:
					CreateRoom(WorldManager.Instance.leftRooms);
					break;
				case DoorOpenings.Right:
					CreateRoom(WorldManager.Instance.rightRooms);
					break;
			}
			spawnedRoom = true;
		} 
	}

	private void CreateRoom(GameObject[] templateRooms) {
		if (WorldManager.Instance.CanCreateRoom) {
			int rand = Random.Range(0, templateRooms.Length);
			CreateSingleRoom(templateRooms[rand]);
		} else {
			CreateSingleRoom(WorldManager.Instance.closedRoom);
		}
	}

	private void CreateClosedRoom() {
	
	}

	private void CreateSingleRoom(GameObject roomTemplate) {
		if (!WorldManager.Instance.IsRoomCreatedOnPos(transform.position)) {
			RoomTemplate room = Instantiate(roomTemplate, transform.position, roomTemplate.transform.rotation, WorldManager.Instance.roomsContainer).GetComponent<RoomTemplate>();
			WorldManager.Instance.AddRoom(room);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("SpawnPoint")) {
			if (collision.GetComponent<RoomSpawner>().spawnedRoom == false && spawnedRoom == false) {
				CreateSingleRoom(WorldManager.Instance.closedRoom);
				Destroy(gameObject);
			}
			spawnedRoom = true;
		}
	}

}
