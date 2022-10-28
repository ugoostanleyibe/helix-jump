using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	public GameObject levelCompletedPanel, gameProgressPanel, startMenuPanel, gameOverPanel;
	public TextMeshProUGUI currentLevelText, nextLevelText, highScoreText, scoreText;
	public Slider gameProgressSlider;

	public static bool isLevelCompleted, isGameRunning, isGameOver, isOnMute;
	public static int numberOfPassedRings, currentLevel, score;

	private void Awake()
	{
		currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
	}

	// Start is called before the first frame update
	private void Start()
	{
		highScoreText.text = $"Best Score\n{PlayerPrefs.GetInt("HighScore", 0)}";
		isLevelCompleted = isGameRunning = isGameOver = false;
		numberOfPassedRings = 0;
		Time.timeScale = 1;
	}

	// Update is called once per frame
	private void Update()
	{
		int progress = numberOfPassedRings * 100 / FindObjectOfType<HelixManager>().startingNumberOfRings;
		gameProgressSlider.value = progress;

		nextLevelText.text = $"{currentLevel + 1}";
		currentLevelText.text = $"{currentLevel}";
		scoreText.text = $"{score}";

		//bool didTouchOnDesktop = Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject();
		bool didTouchOnMobile = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began
			&& !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);

		if (!isGameRunning && didTouchOnMobile)
		{
			gameProgressPanel.SetActive(true);
			startMenuPanel.SetActive(false);
			isGameRunning = true;
		}

		if (isLevelCompleted)
		{
			levelCompletedPanel.SetActive(true);

			if (Input.GetButtonDown("Fire1"))
			{
				PlayerPrefs.SetInt("CurrentLevel", currentLevel + 1);
				SceneManager.LoadScene("Level");
			}
		}

		if (isGameOver)
		{
			Time.timeScale = 0;
			gameOverPanel.SetActive(true);

			if (Input.GetButtonDown("Fire1"))
			{
				if (score > PlayerPrefs.GetInt("HighScore", 0))
				{
					PlayerPrefs.SetInt("HighScore", score);
				}

				SceneManager.LoadScene("Level");
				score = 0;
			}
		}
	}
}
