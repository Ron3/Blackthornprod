using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsController {

	private static ActionsController instance;
	public static ActionsController Instance {
		get {
			if(instance == null) {
				instance = new ActionsController();
			}
			return instance;
		}
	}
	private ActionsController() { }

	public Action<Vector3> onChangeCameraPosition;
	public Action<RoomTemplate> onChangeRoom;

	public void SendOnChangeRoom(RoomTemplate room) {
		if(onChangeRoom != null) {
			onChangeRoom(room);
		}
	}

	public void SendOnChangeCameraPosition(Vector3 roomPos) {
		if(onChangeCameraPosition != null) {
			onChangeCameraPosition(roomPos);
		}
	}

}
