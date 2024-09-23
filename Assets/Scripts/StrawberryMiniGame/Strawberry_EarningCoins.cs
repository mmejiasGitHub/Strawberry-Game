using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Strawberry_EarningCoins : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int coinAmount;

    // Start is called before the first frame update
    void Start()
    {
        coinAmount = 0;
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = coinAmount.ToString(); //update the text message everytime the player gets coins
    }
}
