using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	[SerializeField] private float shootRate;
	[SerializeField] private float shootSpeed;
	[SerializeField] private Bullet bulletPrefab;
	private Rigidbody2D rb;
	private float currentTime;

	private bool CanShoot {
		get {
			return currentTime >= shootRate;
		}
	}

	private void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update() {
		currentTime += Time.deltaTime;
	}

	public void MoveLeft() {
		transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
	}

	public void MoveRight() {
		transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
	}

	public void MoveUp() {
		transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
	}

	public void MoveDown() {
		transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
	}

	public void ShootUp() {
		if (CanShoot) {
			ShootBullet(transform.position, Vector3.up);
		}
	}

	public void ShootDown() {
		if (CanShoot) {
			ShootBullet(transform.position, Vector3.down);
		}
	}

	public void ShootLeft() {
		if (CanShoot) {
			ShootBullet(transform.position, Vector3.left);
		}
	}

	public void ShootRight() {
		if (CanShoot) {
			ShootBullet(transform.position, Vector3.right);
		}
	}

	private void ShootBullet(Vector2 position, Vector3 direction) {
		Bullet b = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(direction));
		b.Shoot(direction, shootSpeed);
		currentTime = 0f;
	}

}
