using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletController : MonoBehaviour
{
    public GameObject prefabPellet;
    Vector2 screenHalfSizeWorldUnits;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject CurrentPlayer = GameObject.FindGameObjectWithTag("Player");
            Instantiate(prefabPellet, CurrentPlayer.transform.position, Quaternion.Euler(CurrentPlayer.transform.position));
            //newPellet.transform.localScale = Vector2.one * spawnSize;
        }
    }
}
