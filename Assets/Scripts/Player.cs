using UnityEngine;

public class Player : MonoBehaviour
{
	public float bounceForce = 6.0f;

	public Rigidbody rb;

	private void OnCollisionEnter(Collision collision)
	{
		rb.velocity = new(rb.velocity.x, bounceForce, rb.velocity.z);
	}
}
