using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolSpawner : MonoBehaviour
{
    [Header("Symbols Settings")]
    [SerializeField] float symbolGravityScale = 0.2f;

    [Header("Spawner Settings")]
    [SerializeField] List<GameObject> symbols = default;
    [SerializeField] int numberOfSymbols = 10;
    [SerializeField] float timeBetweenSymbols = 2f;

    private const float START_X_MIN = -11f;
    private const float START_X_MAX = 11f;
    private const float START_Y = 8f;

    IEnumerator Start()
    {
        yield return StartCoroutine(SpawnSymbols());
    }

    private IEnumerator SpawnSymbols()
    {
        for( int i = 0; i < numberOfSymbols; i++ )
        {
            GameObject symbol = symbols[Random.Range(0, symbols.Count)];
            symbol.GetComponent<Rigidbody2D>().gravityScale = symbolGravityScale;
            Vector3 startPos = new Vector3(Random.Range(START_X_MIN, START_X_MAX), START_Y, 0);
            Instantiate(symbol, startPos, Quaternion.identity);

            yield return new WaitForSeconds(timeBetweenSymbols);
        }
    }
}
