using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColumnLineStrategy", menuName = "LineScores/ColumnLineStrategy", order = 0)]
public class ColumnLineScoreStrategy : LineScoreStrategy
{
    public int column;
    public override List<ReelSymbol> GetReelSymbols(SlotMachine slotMachine)
    {
        List<ReelSymbol> reelSymbols = new List<ReelSymbol>();

        for (var row = 0; row < slotMachine.Rows; row++)
        {
            reelSymbols.Add(slotMachine.ReelSymbolResult[column, row]);
        }

        return reelSymbols;
    }
}
