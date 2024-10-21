using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    [field: SerializeField] public int Columns { get; private set; }
    [field: SerializeField] public int Rows { get; private set; }

    [SerializeField] private List<ReelSymbol> reelSymbols = new List<ReelSymbol>();

    [SerializeField] private List<LineScoreStrategy> lineScoreStrategies = new List<LineScoreStrategy>();

    private List<List<ReelSymbol>> reels = new List<List<ReelSymbol>>();

    private bool spinAvailable = true;

    public ReelSymbol[,] ReelSymbolResult { get; private set; }

    private void Start()
    {
        InitializeReels();
    }

    private void Update()
    {
        // Desktop
        if (Input.GetKeyDown(KeyCode.Space) && spinAvailable)
        {
            spinAvailable = false;
            AssignRandomReelSymbols();
        }

        // Mobile
        if (Input.touchCount > 0 && spinAvailable)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                spinAvailable = false;
                AssignRandomReelSymbols();
            }
        }
    }

    /// <summary>
    /// Initialize the reels with random symbols
    /// </summary>
    private void InitializeReels()
    {
        
        for (var column = 0; column < Columns; column++)
        {
            List<ReelSymbol> reel = new List<ReelSymbol>();

            for (var i = 0; i < reelSymbols.Count; i++)
            {
                reel.Add(reelSymbols[i]);
            }
            reels.Add(reel);
        }
    }

    /// <summary>
    /// Assign Random Reel Sysmbols to each Reel
    /// </summary>
    private void AssignRandomReelSymbols()
    {
        ReelSymbolResult = new ReelSymbol[Columns, Rows];

        for (var column = 0; column < Columns; column++)
        {
            for (var row = 0; row < Rows; row++)
            {
                int randomIndex = Random.Range(0, reelSymbols.Count);

                ReelSymbolResult[column, row] = reelSymbols[randomIndex];
            }
        }

        LogResult();
        Debug.Log(CalculateScore());
        spinAvailable = true;
    }

    
    /// <summary>
    /// Calculate the total score of each possible lineScoreStrategies
    /// </summary>
    /// <returns>Total score of the grid</returns>
    public int CalculateScore()
    {
        int score = 0;

        for (var i = 0; i < lineScoreStrategies.Count; i++)
        {
            score += GetScoreInLine(lineScoreStrategies[i].GetReelSymbols(this));
        }

        return score;
    }

    /// <summary>
    /// Get the score according to a list of symbols
    /// </summary>
    /// <param name="reelSymbols"></param>
    /// <returns></returns>
    public int GetScoreInLine(List<ReelSymbol> reelSymbols)
    {
        int score;

        for (var i = 1; i < reelSymbols.Count; i++)
        {
            if (reelSymbols[i].ReelSymbolData.id != reelSymbols[0].ReelSymbolData.id)
            {
                return 0;
            }
        }

        score = reelSymbols[0].ReelSymbolData.value * reelSymbols.Count;

        return score;
    }

    /// <summary>
    /// Log the reels result
    /// </summary>
    private void LogResult()
    {
        StringBuilder logBuilder = new StringBuilder();

        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                logBuilder.Append("| " + ReelSymbolResult[column, row].ReelSymbolData.value + " ");
            }
            logBuilder.AppendLine("|"); // End of the row
        }

        Debug.Log(logBuilder.ToString());
    }
}
