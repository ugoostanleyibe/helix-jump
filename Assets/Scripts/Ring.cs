using UnityEngine;

public class Ring : MonoBehaviour
{
	private Transform player;

	// Start is called before the first frame update
	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Update is called once per frame
	private void Update()
	{
		if (transform.position.y > player.position.y)
		{
			AudioManager.instance.Play("Whoosh");
			GameManager.numberOfPassedRings++;
			GameManager.score++;
			Destroy(gameObject);
		}
	}
}
