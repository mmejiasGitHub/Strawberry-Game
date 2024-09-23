using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StrawberryStart : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] private AudioClip sound1;
    [SerializeField] float restartDelay = 1f;
    public GameObject goHTP; //How to Play GameObject

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        audioSource.PlayOneShot(sound1);
        Invoke("TutorialHTP", restartDelay);

    }

    public void TutorialHTP()
    {
        goHTP.gameObject.SetActive(false);
        restartDelay = 5f;
        Invoke("StartGameNow", restartDelay);
    }

    public void StartGameNow()
    {
        restartDelay = 1f;
        SceneManager.LoadScene("Strawberry_Level");
    }


    public void ExitGame()
    {
        audioSource.PlayOneShot(sound1);
        Invoke("ExitGameNow", restartDelay);
    }

    public void ExitGameNow()
    {
        Debug.Log("Return to main menu");
    }

}
