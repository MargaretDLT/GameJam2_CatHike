using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextTrigger : MonoBehaviour
{
    public TMP_Text messageText;
    public TMP_Text yesFinalText;
    public TMP_Text noFinalText;

    public DialogueChoice dialogueChoice;

    public GameObject dialoguePanel;
    public TMP_Text dialogueText;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Check if this trigger is the End Game trigger
        if (gameObject.CompareTag("End Game"))
        {
            StartDialogue();
            return;
        }

        if (!dialogueChoice.answered)
        {
            messageText.gameObject.SetActive(true);
            yesFinalText.gameObject.SetActive(false);
            noFinalText.gameObject.SetActive(false);
        }
        else if (dialogueChoice.choseYes)
        {
            messageText.gameObject.SetActive(false);
            yesFinalText.gameObject.SetActive(true);
            noFinalText.gameObject.SetActive(false);
        }
        else
        {
            messageText.gameObject.SetActive(false);
            yesFinalText.gameObject.SetActive(false);
            noFinalText.gameObject.SetActive(true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        messageText.gameObject.SetActive(false);
        yesFinalText.gameObject.SetActive(false);
        noFinalText.gameObject.SetActive(false);

        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    public void StartDialogue()
    {
        dialoguePanel.SetActive(true);
    }

    public void ShowFinalDialogue(bool yes)
    {
        messageText.gameObject.SetActive(false);

        if (yes)
        {
            yesFinalText.gameObject.SetActive(true);
            noFinalText.gameObject.SetActive(false);

            // Only End Game objects reload the menu
            if (gameObject.CompareTag("End Game"))
            {
                StartCoroutine(LoadMainMenuAfterDelay());
            }
        }
        else
        {
            yesFinalText.gameObject.SetActive(false);
            noFinalText.gameObject.SetActive(true);
        }
    }


    private System.Collections.IEnumerator LoadMainMenuAfterDelay()
    {
        yield return new WaitForSeconds(3f); // Shows text for 3 seconds

        SceneManager.LoadScene(0);
    }
}
