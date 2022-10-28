using UnityEngine;

public class Rotator : MonoBehaviour
{
	public float rotationSpeed = 150.0f;

	// Update is called once per frame
	private void Update()
	{
		if (GameManager.isGameRunning)
		{
			// For Desktop
			if (Input.GetMouseButton(0))
			{
				float mouseX = Input.GetAxisRaw("Mouse X");
				transform.Rotate(0.0f, -mouseX * rotationSpeed * Time.deltaTime, 0.0f);
			}

			// For Mobile
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				float deltaX = Input.GetTouch(0).deltaPosition.x;
				transform.Rotate(0.0f, -deltaX * rotationSpeed * Time.deltaTime, 0.0f);
			}
		}
	}
}
