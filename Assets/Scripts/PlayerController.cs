using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed = 5.0f;
      private  GameObject focalPoint;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal point");
    }

    // Update is called once per frame
    void Update()
    {
       float forwardInput = Input.GetAxis("Vertical");
       playerRB.AddForce(focalPoint.transform.forward
       * speed * forwardInput);

    }
}
