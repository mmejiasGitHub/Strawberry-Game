using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] private AudioClip gOver;

    [SerializeField] float restartDelay = 1f;
    public TextMeshProUGUI gameOver;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime = 60f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= +Time.deltaTime;
        timerText.text = "" + remainingTime.ToString("00");
        if (remainingTime <= 0)
        {
            remainingTime = 0;
            audioSource.PlayOneShot(gOver);
            gameOver.gameObject.SetActive(true);
            Invoke("RestartScene", restartDelay);
        }
        else if (remainingTime <= 020)
        {
            timerText.color = Color.red;
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
