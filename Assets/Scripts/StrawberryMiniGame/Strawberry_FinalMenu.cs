using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Strawberry_FinalMenu : MonoBehaviour
{
    public GameObject randomR;

    public void RestartScene()
    {
        randomR.gameObject.SetActive(false);
        SceneManager.LoadScene("Strawberry_Level"); //restart the scene
    }

    public void ExitScene()
    {
        SceneManager.LoadScene("StrawberryMainMenu"); //go to main menu
    }
}
