using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FallingBlocks : MonoBehaviour
{
    public Vector2 speedMinMax;
    public float speed;
    public float visibleHeightThreshold;


    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        //makes the blocks fall
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        
        //-- this doesnt work yet and im not sure why but it deletes the block
        if(transform.position.y < visibleHeightThreshold)
        {
            Destroy(gameObject);
        }
        
    }
    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "pellet")
        {
            Destroy(gameObject);
            print("hit block");
        }
    }
}
