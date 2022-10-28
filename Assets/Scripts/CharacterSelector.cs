using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
	public GameObject[] characters;

	private int selectedCharacterIndex = 0;

	// Start is called before the first frame update
	private void Start()
	{
		foreach (var character in characters)
		{
			character.SetActive(false);
		}

		characters[selectedCharacterIndex].SetActive(true);
	}

	public void ChangeCharacter(int characterIndex)
	{
		characters[selectedCharacterIndex].SetActive(false);
		characters[characterIndex].SetActive(true);
		selectedCharacterIndex = characterIndex;
	}
}
