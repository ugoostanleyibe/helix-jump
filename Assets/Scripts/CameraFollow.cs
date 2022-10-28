using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public float smoothSpeed;

	public Transform target;

	private Vector3 offset;

	// Start is called before the first frame update
	private void Start()
	{
		offset = transform.position - target.position;
	}

	// Update is called once per frame
	private void LateUpdate()
	{
		Vector3 newPosition = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);
		transform.position = newPosition;
	}
}
