using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    public GameController gameController;

    private void Start()
    {
        //gameController = FindObjectOfType<GameController>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        int randomId = Random.Range(0, 7);
        gameObject.GetComponent<SpriteRenderer>().color = gameController.colors[randomId];
    }
}
