using UnityEngine;

// Copyright © 2024 Randy Angle
// Permission is granted to use this script in your student, private, or commercial game projects, provided this notice remains intact
// Commerical release means putting "Additional code by Rangle Angle" in the game credits.

public class Food : MonoBehaviour
{
	public GameObject shockwavePrefab;

	AudioSource MyAudioSource;

	private void Start()
	{
		MyAudioSource = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			// if audio clip is designated, play it
			if (MyAudioSource != null)
			{
				MyAudioSource.Play();
			}

			//other.gameObject.GetComponent<ControllerActionRPG>().HealPlayer();
			Instantiate(shockwavePrefab, transform.position, Quaternion.identity);
			Destroy(gameObject, 1.1f);
		}
	}
}

