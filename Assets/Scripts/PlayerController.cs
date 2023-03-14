using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed = 5.0f;
    private  GameObject focalPoint;
    public bool hasPowerup;
    private float powerupStrength = 15.0f;
    public GameObject powerupIndicator;
    
    
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
        playerRB.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position;

    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Powerup")) 
        {
          hasPowerup = true;
          powerupIndicator.gameObject.SetActive(true);
          Destroy(other.gameObject);
          StartCoroutine(PowerupCountdownRoutine());
        }

    }

    IEnumerator PowerupCountdownRoutine()
    {
      yield return new WaitForSeconds(7);
      hasPowerup = false;
      powerupIndicator.gameObject.SetActive(false);
    } 



    private void OnCollisionEnter(Collision collision )
    { 
          if (collision.gameObject.CompareTag("Enemy") && hasPowerup) 
          {
           Debug.Log("Collided with" + collision.gameObject.name + "with powerup set to" + hasPowerup);

           Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
           Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

           enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);


          }

    }

        





}
