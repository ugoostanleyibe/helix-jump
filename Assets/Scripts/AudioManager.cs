using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;

	public Sound[] sounds;

	private void Start()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
		
		foreach (var sound in sounds)
		{
			sound.source = gameObject.AddComponent<AudioSource>();
			sound.source.volume = sound.volume;
			sound.source.pitch = sound.pitch;
			sound.source.clip = sound.clip;
			sound.source.loop = sound.loop;
		}
	}

	public void Play(string soundName)
	{
		if (!GameManager.isOnMute)
		{
			Array.Find(sounds, item => item.name == soundName).source.Play(); 
		}
	}
}
