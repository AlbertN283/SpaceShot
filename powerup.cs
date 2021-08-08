using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{


    [SerializeField]
    private float _speed = 3.0f;

    //ID for powerups 
    //0 = Triple Shot 
    //1 = Speed 
    //2 = Shields
    [SerializeField]
    private int powerupID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down at the speed of 3 (adjust in the inspector)
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        //When we leave the screen, destroy this object
        if (transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }
    }

    //onTriggerCollision
    //Only be collectable by the Player (HINT: Use Tags)
    //on collected, destroy 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //Communicate with the player script
            //handle to the component i want 
            //assign the handle to the component
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                //if powerup is 0
                player.TripleShotActive();
                //else if powerup is 1
                //play speed powerup
                //else if powerup is 2 
                //shields powerup
            }

            Destroy(this.gameObject);
        }
    }
}
