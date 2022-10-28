using UnityEngine;

public class HelixManager : MonoBehaviour
{
	public GameObject[] helixRings;
	public GameObject baseRing;

	public float distanceBetweenRings, spawnY;
	public int startingNumberOfRings;

	// Start is called before the first frame update
	private void Start()
	{
		for (int i = 0; i < GameManager.currentLevel + startingNumberOfRings - 1; i++)
		{
			if (i > 0)
			{
				SpawnRing(Random.Range(1, helixRings.Length - 1));
			}
			else
			{
				SpawnRing(0);
			}
		}

		SpawnRing(helixRings.Length - 1);
	}

	public void SpawnRing(int ringIndex)
	{
		var obj = Instantiate(helixRings[ringIndex], transform.up * spawnY, Quaternion.identity);
		obj.transform.parent = transform;
		spawnY -= distanceBetweenRings;
	}
}
