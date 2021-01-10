using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObject : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private GameController gameController;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if( collider.name == "Hilbert" )
        {
            gameController.OnSymbolCollided(gameObject);
            Destroy(gameObject);
        }
    }
}
