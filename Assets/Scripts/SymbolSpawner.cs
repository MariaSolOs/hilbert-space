using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymbolSpawner : MonoBehaviour
{
    [Header("Symbols Settings")]
    [SerializeField] GameObject[] symbols = default;
    [SerializeField] float symbolGravityScale = 0.3f;
    [SerializeField][Range(0f, 10f)] float minTimeBetweenSymbols = 1f;
    [SerializeField][Range(0f, 10f)] float maxTimeBetweenSymbols = 4f;

    // Bounds for initializing symbol game objects
    private const float leftSpawningBound = -11f;
    private const float rightSpawningBound = 11f;
    private const float topSpawningBound = 8f;

    private GameController gameController = default;

    public void SetTheoremImage(TheoremConfig theorem)
    {
        gameController = FindObjectOfType<GameController>();

        Image theoremImage = theorem.GetTheoremImage();
        // Set image sprite
        GameObject childCanvas = this.transform.Find("Canvas").gameObject;
        GameObject canvasImage = childCanvas.transform.Find("Theorem Image").gameObject;
        canvasImage.GetComponent<Image>().sprite = theoremImage.sprite;
        // Set image width and height
        RectTransform canvasRectTransform = canvasImage.GetComponent<RectTransform>();
        RectTransform theoremImageRectTransform = theoremImage.GetComponent<RectTransform>();
        canvasRectTransform.sizeDelta = theoremImageRectTransform.sizeDelta;
    }

    public IEnumerator SpawnSymbols(TheoremConfig theorem)
    {
        while( !gameController.AreAllSymbolsMatched() )
        {
            GameObject symbol = symbols[Random.Range(0, symbols.Length)];
            symbol.GetComponent<Rigidbody2D>().gravityScale = symbolGravityScale;
            Vector3 startPos = 
                new Vector3(Random.Range(leftSpawningBound, rightSpawningBound), 
                            topSpawningBound, 
                            0);
            Instantiate(symbol, startPos, Quaternion.identity);

            float timeToWait = Random.Range(minTimeBetweenSymbols, maxTimeBetweenSymbols);
            yield return new WaitForSeconds(timeToWait);
        }
    }
}
