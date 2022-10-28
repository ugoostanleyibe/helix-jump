using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	public TextMeshProUGUI currentLevelText, nextLevelText;
	public GameObject levelCompletedPanel, gameOverPanel;
	public Slider gameProgressSlider;

	public static int numberOfPassedRings;
	public static int currentLevelIndex;

	public static bool isLevelCompleted;
	public static bool isGameOver;

	private void Awake()
	{
		currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
	}

	// Start is called before the first frame update
	private void Start()
	{
		isLevelCompleted = isGameOver = false;
		numberOfPassedRings = 0;
		Time.timeScale = 1;
	}

	// Update is called once per frame
	private void Update()
	{
		int progress = numberOfPassedRings * 100 / FindObjectOfType<HelixManager>().numberOfRings;

		nextLevelText.text = $"{currentLevelIndex + 1}";
		currentLevelText.text = $"{currentLevelIndex}";

		gameProgressSlider.value = progress;

		if (isGameOver)
		{
			Time.timeScale = 0;
			gameOverPanel.SetActive(true);

			if (Input.GetButtonDown("Fire1"))
			{
				SceneManager.LoadScene("Level");
			}
		}

		if (isLevelCompleted)
		{
			levelCompletedPanel.SetActive(true);

			if (Input.GetButtonDown("Fire1"))
			{
				PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);
				SceneManager.LoadScene("Level");
			}
		}
	}
}
