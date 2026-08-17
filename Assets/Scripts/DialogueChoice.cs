using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueChoice : MonoBehaviour
{
    public GameObject dialoguePanel;
    public PlayerHealth playerHealth;
    public bool answered = false;
    public bool choseYes= false;
    public GameObject ogText;
    public TextTrigger textTrigger;

    public void Yes()
    {
        playerHealth.AddHealth(20); // adds 20 health
        answered = true;
        choseYes = true;
        ogText.SetActive(false);
        textTrigger.ShowFinalDialogue(true);
        if (CompareTag("End Game"))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void No()
    {
        playerHealth.TakeDamage(20);
        answered = true;
        choseYes = false;
        ogText.SetActive(false);
        textTrigger.ShowFinalDialogue(false);
    }
}
