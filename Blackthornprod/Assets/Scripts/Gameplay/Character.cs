using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamageble {

	[SerializeField] private float moveSpeed;
	[SerializeField] private float shootRate;
	[SerializeField] private float shootSpeed;
	[SerializeField] private Bullet bulletPrefab;
	[SerializeField] private Animator animator;
	[SerializeField] private SpriteRenderer spriteRend;
	[SerializeField] private Sprite frontChSprite;
	[SerializeField] private Sprite backChSprite;
	[SerializeField] private GameObject spawnPoint;

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

	public void StartWalk() {
		bool isWalking = animator.GetBool("IsWalking");
		if (!isWalking) {
			animator.SetBool("IsWalking", true);
		}
	}

	public void StartIdle() {
		bool isWalking = animator.GetBool("IsWalking");
		if (isWalking) {
			animator.SetBool("IsWalking", false);
		}
	}

	public void TakeDamage(float damage) {

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

	public void Shoot(Vector3 direction) {
		ChangeCharacterDirection(direction);
		if (CanShoot) {
			ShootBullet(transform.position, direction);
		}
	}

	private void ShootBullet(Vector2 position, Vector3 direction) {
		Bullet b = Instantiate(bulletPrefab, spawnPoint.transform.position, Quaternion.Euler(direction));
		b.Shoot(direction, shootSpeed);
		currentTime = 0f;
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Door")) {
			Door door = collision.gameObject.GetComponent<Door>();
			ActionsController.Instance.SendOnChangeCameraPosition(door.RoomPosition);
			ActionsController.Instance.SendOnChangeRoom(door.roomRef);
		}
	}

	private void ChangeCharacterDirection(Vector2 direction) {
		if(direction.x == 1 && spriteRend.flipX == false) {
			spriteRend.flipX = true;
			spawnPoint.transform.localPosition = new Vector2(0.113f, spawnPoint.transform.localPosition.y);
		} else if (direction.x == -1 && spriteRend.flipX == true) {
			spawnPoint.transform.localPosition = new Vector2(-0.113f, spawnPoint.transform.localPosition.y);
			spriteRend.flipX = false;
		}

		if (direction.y == 1) {
			spriteRend.sprite = backChSprite;
			spawnPoint.gameObject.SetActive(false);
		} else {
			spriteRend.sprite = frontChSprite;
			spawnPoint.gameObject.SetActive(true);
		}
	}

}
