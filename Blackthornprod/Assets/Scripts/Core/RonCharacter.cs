using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RonCharacter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) 
    {

		// Debug.Log($"RonCharacter ==> {this.gameObject.name}, ==> {collision.gameObject.name}");

		if (collision.CompareTag("Door")) {
			Door door = collision.gameObject.GetComponent<Door>();
			ActionsController.Instance.SendOnChangeCameraPosition(door.RoomPosition);
			ActionsController.Instance.SendOnChangeRoom(door.roomRef);
		}
        else if (collision.CompareTag("Heart")) 
        {
			// TakeDamage(-20f);
			Destroy(collision.gameObject);
		}
        else if (collision.CompareTag("Game")) 
        {
			Destroy(collision.gameObject);
			UIManager.Instance.ChangePage(MenuPages.EndStoryPage);
		}
	}
}