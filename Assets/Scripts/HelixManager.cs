using UnityEngine;

public class HelixManager : MonoBehaviour
{
	public GameObject[] helixRings;
	public GameObject baseRing;

	public float ringsDistance = 5.0f;
    public float spawnY = 0.0f;

	public int numberOfRings = 7;

	// Start is called before the first frame update
	private void Start()
    {
		for (int i = 0; i < numberOfRings; i++)
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

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void SpawnRing(int ringIndex)
    {
		var obj = Instantiate(helixRings[ringIndex], transform.up * spawnY, Quaternion.identity);
		obj.transform.parent = transform;
        spawnY -= ringsDistance;
	}
}