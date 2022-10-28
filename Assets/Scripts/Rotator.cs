using UnityEngine;

public class Rotator : MonoBehaviour
{
	public float rotationSpeed;

	// Update is called once per frame
	private void Update()
	{
		if (GameManager.isGameRunning)
		{
			bool didTouchOnDesktop = Input.GetMouseButton(0),
				didTouchOnMobile = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved;

			if (didTouchOnMobile)
			{
				float deltaX = Input.GetTouch(0).deltaPosition.x;
				transform.Rotate(0.0f, -deltaX * rotationSpeed * Time.deltaTime, 0.0f);
			}
			else if (didTouchOnDesktop)
			{
				float mouseX = Input.GetAxisRaw("Mouse X");
				transform.Rotate(0.0f, -mouseX * rotationSpeed * Time.deltaTime, 0.0f);
			}
		}
	}
}
