using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class CatFood : MonoBehaviour
{
    private bool collected = false;
    public AudioClip foodSFX;
    private int foodIndex;

    void Start()
    {
        foodIndex = SoundBoard.Instance.AddSoundEffect(foodSFX);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (collected) return;

        if (!other.CompareTag("Player")) return;
        //SoundBoard.Instance.PlaySFX(foodIndex);
        collected = true;

        ScoreManager.instance.AddPoint();
        SoundBoard.Instance.PlaySFX(foodIndex);

        // Remove the whole food object and children
        transform.parent.gameObject.SetActive(false);
    }
}
