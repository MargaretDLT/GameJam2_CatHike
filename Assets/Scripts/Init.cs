using UnityEngine;

// Copyright © 2024 Randy Angle
// Permission is granted to use this script in your student, private, or commercial game projects, provided this notice remains intact
// Commerical release means putting "Additional code by Rangle Angle" in the game credits.

// Initialize PlayerPrefs
// Create an empty object & attach this script in your opening scene (usually MENU on unique game scene)
// modify as needed for your own PlayerPrefs needs
// to reset PlayerPrefs in the Unity Editor you can use Edit > Clear All PlayerPrefs

public class Init : MonoBehaviour
{
	public AudioClip gameMusic;

	// Start is called before the first frame update
	void Start()
	{
        Debug.Log(SoundBoard.Instance);
        // start the music
        SoundBoard.Instance.PlayMusic(gameMusic);

		if (!PlayerPrefs.HasKey("PrefsApp") || (PlayerPrefs.GetString("PrefsApp") == ""))
		{
			DeletePrefs();
		}
		else
		{
			// always zero starting score
			PlayerPrefs.SetInt("PrefsScore", 0);
			PlayerPrefs.Save();
		}

		// upgrade (or decide to delete) stored player prefs for new version
		string PrefsVersion = PlayerPrefs.GetString("PrefsVersion");
		if (PrefsVersion != Application.version)
		{
			Debug.Log("Convert PlayerPrefs from old version " + PrefsVersion);
			// convert old version to new version of PlayerPrefs settings
		}
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	void DeletePrefs()
	{
		Debug.Log("Reseting/Initializing PlayerPrefs");
		PlayerPrefs.DeleteAll(); // be very careful, this resets your saves
		PlayerPrefs.SetString("PrefsApp", Application.productName);     // set to Player Setting
		PlayerPrefs.SetString("PrefsVersion", Application.version);     // set to Player Setting
		PlayerPrefs.GetInt("PrefsScore", 0);							// up to game
		// add and initialize any additional presistent data for your game below using SetInt, SetFloat, or SetString
		// since there can be multiple games in the course - preface the pref key with 'gameName' so it is unique
		// to adjust score in game object:
		//	int Score = PlayerPrefs.GetInt("PrefsScore") + 10;
		//	PlayerPrefs.SetInt("PrefsScore", Score);
		//	PlayerPrefs.Save();

		// finish by immediately saving current PlayerPrefs
		PlayerPrefs.Save();
	}
}
