using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] float verticalForce = 400f; //player verticalForce
    [SerializeField] float restartDelay = 1f; 
    [SerializeField] ParticleSystem playerParticles; 
    [SerializeField] ParticleSystem jumpParticles;

    [SerializeField] Color redColor; 
    [SerializeField] Color blueColor;
    [SerializeField] Color greenColor;
    [SerializeField] Color darkblueColor;

    public TextMeshProUGUI pause; //image showing pause text on screen
    public TextMeshProUGUI lvComplete; //display level complete text
    public TextMeshProUGUI gPoint; //image showing +1 on the screen
    public TextMeshProUGUI gPoint2; //image showing +2 on the screen
    public TextMeshProUGUI gPoint3; //image showing +3 on the screen
    public TextMeshProUGUI gPoint4; //image showing +4 on the screen

    public GameObject startingGame; //a message is displayed when starting the game
    public GameObject vRewards; //Calls an object that shows the rewards earned during the game
    public TextMeshProUGUI txtRewards; //text that shows the number of strawberries picked
    public TextMeshProUGUI txtTotal; //text that will show the total amount of the rewards
    public int cTotal;//Text message showing you the amount of coins you get when you complete the level
    public GameObject fMenu; //Shows the final menu with the options "play again" or "return to the main menu"

    string currentColor; //compares the player tag with object tag

    Rigidbody2D playerRb;
    SpriteRenderer playerSR;


    AudioSource audioSource;
    [SerializeField] private AudioClip sound1;
    [SerializeField] private AudioClip sound2;

    public GameObject timerC; //Timer GameObject
    Strawberry_FinishLineSound fls; //calls the class "StrawberryFinishLineSound"



    //Start is called before the first frame update
    void Start()
    {
        restartDelay = 1f; 
        audioSource = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody2D>();
        playerSR = GetComponent<SpriteRenderer>();
        currentColor = "Red";
        startingGame.gameObject.SetActive(true);
        fls = FindObjectOfType(typeof(Strawberry_FinishLineSound)) as Strawberry_FinishLineSound;
    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))//What is in the conditional will happen if the player uses the assigned button
        {
            startingGame.gameObject.SetActive(false); //turn off Starting game messages when player make its first move
            pause.gameObject.SetActive(false); //turn off pause image
            Time.timeScale = 1; //resume game scene
            audioSource.PlayOneShot(sound1); //The sound will be heard every time the player moves
            jumpParticles.Play(); //Particles are displayed every time the player uses the assigned button
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(new Vector2(0, verticalForce));
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Time.timeScale = 0;//pause game scene
            pause.gameObject.SetActive(true); //turn on pause image
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag(currentColor)) //The player is changing his color every time it makes contact with an object that has the same Tag color
        {
            audioSource.PlayOneShot(sound2);
           
            if (currentColor == "Red")
            {
                gPoint.gameObject.SetActive(true);
                Invoke("getPoint", restartDelay);
                Strawberry_EarningCoins.coinAmount += 1;
            }
            if (currentColor == "Green")
            {
                gPoint2.gameObject.SetActive(true);
                Invoke("getPoint", restartDelay);
                Strawberry_EarningCoins.coinAmount += 2;
            }
            if (currentColor == "Blue")
            {
                gPoint3.gameObject.SetActive(true);
                Invoke("getPoint", restartDelay);
                Strawberry_EarningCoins.coinAmount += 3;
            }
            if (currentColor == "DarkBlue")
            {
                gPoint4.gameObject.SetActive(true);
                Invoke("getPoint", restartDelay);
                Strawberry_EarningCoins.coinAmount += 4;
            }
            ChangeColor();
            Destroy(collision.gameObject);
            return; 
        }

        if (collision.gameObject.CompareTag("FinishLine")) //If the player makes contact with an object with a tag name "finish line" then the game is completed (only happens once)
            {
            fls.reachFinishLine();//Calls the function reachFinishLine from the class Strawberry_FinishLineSound
            gameObject.SetActive(false);
            lvComplete.gameObject.SetActive(true);
            timerC.gameObject.SetActive(false);
            Invoke("StrawberryRewards", restartDelay);//the rewards UI(user interface) is showing when the level is completed
            return;
        }

        if (!collision.gameObject.CompareTag(currentColor))//If the player makes contact with an object that has a different tag or is different than the finish line tag, then the player's object will be destroyed.
        {
            gameObject.SetActive(false); 
            Instantiate(playerParticles, transform.position, Quaternion.identity);
            Invoke("RestartScene", restartDelay);
        }

    }

    void getPoint()
    {
        //turn off every gPoint gameObject
        gPoint.gameObject.SetActive(false);
        gPoint2.gameObject.SetActive(false);
        gPoint3.gameObject.SetActive(false);
        gPoint4.gameObject.SetActive(false);
    }

    public void MuteAllSound()
    {
        AudioListener.volume = 0;
    }

    void StrawberryRewards() 
    {
        MuteAllSound();
        vRewards.gameObject.SetActive(true);
        txtRewards.text = Strawberry_EarningCoins.coinAmount.ToString();
        cTotal += Strawberry_EarningCoins.coinAmount +100; //The amount for completing the level is added + the amount of extra coins obtained during the game
        txtTotal.text = cTotal.ToString();
       // GlobalCoin.Instance.addCoin(cTotal);  
        restartDelay = 4f;
        Invoke("FinalStrawberry", restartDelay); //the UI(user interface) final menu is showing with the options "play again" or "return to the main menu"
    }

    void FinalStrawberry()
    {
        vRewards.gameObject.SetActive(false);
        AudioListener.volume = 1;
        fMenu.gameObject.SetActive(true);
    }


    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    void ChangeColor()
    {
        int randomNumber = Random.Range(0, 3);

        if (currentColor == "Red")
        {
            if (randomNumber == 0)
            {
                playerSR.color = blueColor;
                currentColor = "Blue";
            }
            else if (randomNumber == 1)
            {
                playerSR.color = greenColor;
                currentColor = "Green";
            }
            else if (randomNumber == 2)
            {
                playerSR.color = darkblueColor;
                currentColor = "DarkBlue";
            }
            return;
        }
        if (currentColor == "Blue")
        {
        

            if (randomNumber == 0)
            {
                playerSR.color = redColor;
                currentColor = "Red";
            }
            else if (randomNumber == 1)
            {
                playerSR.color = greenColor;
                currentColor = "Green";
            }
            else if (randomNumber == 2)
            {
                playerSR.color = darkblueColor;
                currentColor = "DarkBlue";
            }
            return;
        }

        if (currentColor == "Green")
        {
            

            if (randomNumber == 0)
            {
                playerSR.color = blueColor;
                currentColor = "Blue";
            }
            else if (randomNumber == 1)
            {
                playerSR.color = redColor;
                currentColor = "Red";
            }
            else if (randomNumber == 2)
            {
                playerSR.color = darkblueColor;
                currentColor = "DarkBlue";
            }
            return;
        }

        if (currentColor == "DarkBlue")
        {
            

            if (randomNumber == 0)
            {
                playerSR.color = blueColor;
                currentColor = "Blue";
            }
            else if (randomNumber == 1)
            {
                playerSR.color = greenColor;
                currentColor = "Green";
            }
            else if (randomNumber == 2)
            {
                playerSR.color = redColor;
                currentColor = "Red";
            }
            return;
        }

    }
}

    

