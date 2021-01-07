using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameController gameController = default;
    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if( collider.gameObject.name == "Hilbert" )
        {
            gameController.LoadGame();
        }
    }
}
