using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

// Copyright © 2026 Randy Angle
// Permission is granted to use this script in your student, private, or commercial game projects, provided this notice remains intact
// Commerical release means putting "Additional code by Rangle Angle" in the game credits.

// Pause Mode
// attach to empty object or Main Camera
// handles pressing ESCAPE to display simple Pause Menu with instructions
// can add GUI.DrawTexture(...) to display images with text and buttons
public class ExtraButtons : MonoBehaviour
{
	public string HowToPlayText;
	bool bPaused;            //Boolean to check if the game is paused or not

	[HideInInspector]
	public GUIStyle PauseStyle;       // set the text style of the frame counter
	[HideInInspector]
	public GUIStyle HowToStyle;

	public AudioClip ButtonSFX;
	public int indexSFX;


	void Start()
	{
		bPaused = false;

		HowToStyle.alignment = TextAnchor.UpperCenter;      // sets text flow left to right from top
		HowToStyle.fontSize = 40;                         // font size to 40 (for HD display
		HowToStyle.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);  // text color white White
		HowToStyle.wordWrap = true;

		// process string and display
		string temp;
		temp = HowToPlayText.Replace("\\n", "\n");
		temp = temp.Replace("\\t", "\t");
		HowToPlayText = temp;

		indexSFX = SoundBoard.Instance.AddSoundEffect(ButtonSFX);
	}

	// Update is called once per frame
	void Update()
	{
		// detects PC or Mac keyboard End = pause mode
		if (Keyboard.current.endKey.isPressed)
		{
			if (bPaused)
			{
				UnPause();                              // stop pausing
				SoundBoard.Instance.PlaySFX(indexSFX);  // confirm audio
			}
			else
			{
				// no audio, because pausing
				DoPause();                              // begin pausing
			}
		}

		// when the BACK key is pressed return to menu
		if (Keyboard.current.backspaceKey.isPressed)
		{
			if (bPaused)
			{
				UnPause();                              // stop pausing
			}

			SceneManager.LoadScene(0);      // load the MENU scene at index 0
		}

		// reload the scene if the F10 key is pressed
		if (Keyboard.current.f10Key.isPressed)
		{
			if (bPaused)
			{
				UnPause();                              // stop pausing
			}

			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	// detects tap or mouse click events on the pause button graphic
	void OnMouseDown()
	{
		if (bPaused)
		{
			UnPause();                              // stop pausing
			SoundBoard.Instance.PlaySFX(indexSFX);  // confirm audio
		}
		else
		{
			// no audio, because pausing
			DoPause();                              // begin pausing
		}
	}

	void DoPause()
	{
		//Set bPaused to true
		bPaused = true;
		//Set time.timescale to 0, this will cause animations and physics to stop updating
		Time.timeScale = 0;
		SoundBoard.Instance.DoPause();
	}

	void UnPause()
	{
		//Set bPaused to false
		bPaused = false;
		//Set time.timescale to 1, this will cause animations and physics to continue updating at regular speed
		Time.timeScale = 1;
		SoundBoard.Instance.UnPause();
	}

	void OnGUI()
	{
		if (bPaused)
		{
			//Calculate change aspects
			float resX = (float)(Screen.width) / 1920f;
			float resY = (float)(Screen.height) / 1080f;

			//Set matrix
			GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(resX, resY, 1));

			GUI.Box(new Rect(0, 0, 1920f, 1080f), "");                   // displays default GUI box without header

			GUI.Label(new Rect(10, 10, 1920f - 20f, 1080f * 0.75f), HowToPlayText, HowToStyle);
		}
	}
}
