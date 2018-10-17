using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[SerializeField] private Rigidbody2D rb;
	private float damage;

	public void Shoot(Vector2 dir, float force, float d = 10f) {
		damage = d;
		rb.AddForce(dir * force, ForceMode2D.Impulse);
		StartCoroutine(DieCoroutine());
	}

	private IEnumerator DieCoroutine() {
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		Debug.Log(collision.tag);
		if (collision.CompareTag("Enemy")) {
			collision.gameObject.GetComponent<IDamageble>().TakeDamage(damage);
		}
		StopCoroutine("DieCoroutine");
		Destroy(gameObject);
	}

}
