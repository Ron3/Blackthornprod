using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	[SerializeField] private Rigidbody2D rb;

	private float damage;

	public void Shoot(Vector3 dir, float power, float d) {
		damage = d;
		rb.AddTorque(10f, ForceMode2D.Impulse);
		rb.AddForce(dir.normalized * power, ForceMode2D.Impulse);
	}

	public void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Player")) {
			collision.gameObject.GetComponent<IDamageble>().TakeDamage(damage);
		}
		Destroy(gameObject);
	}

}
