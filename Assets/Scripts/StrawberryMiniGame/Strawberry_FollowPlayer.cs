using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

   [SerializeField] Transform playerTransform;
    
    
    // Update is called once per frame
    void Update()
    {
       transform.position = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z); //camera will follow the player all the time

    }
}
