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

}
