using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Lose / Win screens")]
    [SerializeField] GameObject winLabel = default;
    [SerializeField] GameObject loseLabel = default;
    [SerializeField] int wrongCollisionsLeft = 3;
    [SerializeField] float timeToWaitAfterGame = 3f;

    [SerializeField] TheoremConfig[] theorems = default;

    private SymbolSpawner symbolSpawner = default;
    private Hilbert hilbert = default;
    private LevelController levelController = default;

    private GameObject[] theoremSymbols = default;
    private int currentMatchingIdx = 0;
    private bool isGameOver = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);

        TheoremConfig theorem = theorems[Random.Range(0, theorems.Length)];
        theoremSymbols = theorem.GetTheoremSymbols();

        hilbert = FindObjectOfType<Hilbert>();
        levelController = FindObjectOfType<LevelController>();

        symbolSpawner = FindObjectOfType<SymbolSpawner>();
        symbolSpawner.SetTheoremImage(theorem);
        StartCoroutine(symbolSpawner.SpawnSymbols(theorem));
    }

    public bool AreAllSymbolsMatched()
    {
        return currentMatchingIdx == theoremSymbols.Length;
    }

    public void OnSymbolCollided(GameObject symbol)
    {
        if( isGameOver ){ return; }

        if( symbol.CompareTag(theoremSymbols[currentMatchingIdx].name) )
        {
            currentMatchingIdx++;
        }
        else
        {
            wrongCollisionsLeft--;
        }

        if( wrongCollisionsLeft == 0 )
        {
            StartCoroutine(OnGameLost());
        }
        else if( AreAllSymbolsMatched() )
        {
            StartCoroutine(OnGameWin());
        }
    }

    private IEnumerator OnGameLost()
    {
        isGameOver = true;
        loseLabel.SetActive(true);
        hilbert.TriggerLoseAnimation();
        yield return new WaitForSeconds(timeToWaitAfterGame);
        levelController.LoadGameOverScene();
    }

    private IEnumerator OnGameWin()
    {
        isGameOver = true;
        winLabel.SetActive(true);
        hilbert.TriggerWinAnimation();
        yield return new WaitForSeconds(timeToWaitAfterGame);
        levelController.LoadGameOverScene();
    }
}
