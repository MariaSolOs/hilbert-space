using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private LevelController levelController = default;
    private void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if( collider.gameObject.name == "Hilbert" )
        {
            levelController.LoadGameScene();
        }
    }
}
