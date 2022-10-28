using UnityEngine;
using TMPro;

public class ClickManager : MonoBehaviour
{
	public TextMeshProUGUI slashText;

	private void Start()
	{
		slashText.text = $"{(GameManager.isOnMute ? "/" : "")}";
	}

	public void OnMuteButtonPressed()
	{
		if (GameManager.isOnMute)
		{
			GameManager.isOnMute = false;
			slashText.text = "";
		}
		else
		{
			GameManager.isOnMute = true;
			slashText.text = "/";
		}
	}

	public void OnQuitButtonPressed()
	{
		Application.Quit();
	}
}
