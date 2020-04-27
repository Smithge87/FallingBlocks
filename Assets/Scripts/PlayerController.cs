using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 7;
    float screenHalfWidthInWorldUnits;
    public event System.Action OnPlayerDeath;
    // Start is called before the first frame update
    void Start()
    {
        //-- calculating half of the screen using the main camera
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize  - halfPlayerWidth;
    }

    // Update is called once per frame
    void Update()
    {
        //-- player movement left and right
        float inputx = Input.GetAxisRaw("Horizontal");
        float velocity = inputx * playerSpeed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        //-- makes the player hit the side walls and stop. reversing the valuse of screenHalfWidthInWorldUnits makes the screen appear to wrap.
        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
    }
    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "fallingBlock")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            //--this was the easier way to call end of game w/o needing the event
            //FindObjectOfType<GameOver>().OnGameOver();

            Destroy(gameObject);
            print("hit");
        }
    }
}
