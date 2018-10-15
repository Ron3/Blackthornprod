using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[SerializeField] private Rigidbody2D rb;

	public void Shoot(Vector2 dir, float force) {
		rb.AddForce(dir * force, ForceMode2D.Impulse);
		StartCoroutine(DieCoroutine());
	}

	private IEnumerator DieCoroutine() {
		yield return new WaitForSeconds(0.6f);
		Destroy(gameObject);
	}



}
