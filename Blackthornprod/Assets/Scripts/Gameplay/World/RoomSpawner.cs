using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

	[SerializeField] public DoorOpenings openingDirection;

	private bool spawnedRoom = false;

	private void Start() {
		Invoke("SpawnRoom", 0.3f);
	}

	private void SpawnRoom() {
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
		int rand = Random.Range(0, templateRooms.Length);
		Instantiate(templateRooms[rand], transform.position, templateRooms[rand].transform.rotation, WorldManager.Instance.roomsContainer);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("SpawnPoint")) {
			RoomSpawner otherRS = other.GetComponent<RoomSpawner>();
			if (otherRS.spawnedRoom == false && spawnedRoom == false) {
				GameObject roomPrefab = WorldManager.Instance.GetRoomTemplate(openingDirection, otherRS.openingDirection);
				Instantiate(roomPrefab, transform.position, roomPrefab.transform.rotation, WorldManager.Instance.roomsContainer);
			}
			Destroy(gameObject);
		}
	}

}
