using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // when the BACK key is pressed
        if(ReadBackspace())
		{
            SceneManager.LoadScene(0);      // load the MENU scene at index 0
        }
    }

    bool ReadBackspace()
    {
#if ENABLE_INPUT_SYSTEM
        return Keyboard.current.backspaceKey.isPressed;
#else
		return Input.GetKeyDown(KeyCode.Backspace)
#endif
	}
}
