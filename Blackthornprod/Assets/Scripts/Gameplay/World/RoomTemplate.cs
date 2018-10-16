using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour {

	[SerializeField] private List<Door> doors;

	private void Start() {
		foreach(Door d in doors) {
			d.InitDoorWithRoom(gameObject.transform);
		}
	}
}
