using UnityEngine;

public class Player : MonoBehaviour
{
	public float bounceForce;

	public Rigidbody rb;

	private void OnCollisionEnter(Collision collision)
	{
		AudioManager.instance.Play("Bounce");
		rb.velocity = new(rb.velocity.x, bounceForce, rb.velocity.z);

		switch (collision.transform.GetComponent<MeshRenderer>().material.name)
		{
			case "Unsafe (Instance)":
				AudioManager.instance.Play("GameOver");
				GameManager.isGameOver = true;
				break;

			case "Base (Instance)":
				if (!GameManager.isLevelCompleted)
				{
					AudioManager.instance.Play("LevelCompleted");
					GameManager.isLevelCompleted = true;
				}
				break;
		}
	}
}
