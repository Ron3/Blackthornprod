using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RonBullet : MonoBehaviour 
{
    [SerializeField] private SpriteRenderer rend;
	[SerializeField] private Rigidbody2D rb;
	private float damage;

	public void Shoot(Vector2 dir, float force, float d = 10f) {
		if(dir.y == 1) {
			rend.sortingOrder = 0;
		} else {
			rend.sortingOrder = 4;
		}
		damage = d;
		rb.AddForce(dir * force, ForceMode2D.Impulse);
		rb.AddTorque(10f, ForceMode2D.Impulse);
		StartCoroutine(DieCoroutine());
	}

	private IEnumerator DieCoroutine() {
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		Debug.Log(collision.name);
		if (collision.CompareTag("Enemy")) {
			collision.gameObject.GetComponent<IDamageble>().TakeDamage(damage);
		}
		StopCoroutine("DieCoroutine");
		Destroy(gameObject);
	}
}
