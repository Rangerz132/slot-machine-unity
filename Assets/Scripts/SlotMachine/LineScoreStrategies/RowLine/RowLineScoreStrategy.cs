using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RowLineStrategy", menuName = "LineScores/RowLineStrategy", order = 0)]
public class RowLineScoreStrategy : LineScoreStrategy
{
    public int row;
    public override List<ReelSymbol> GetReelSymbols(SlotMachine slotMachine)
    {
        List<ReelSymbol> reelSymbols = new List<ReelSymbol>();

        for (var column = 0; column < slotMachine.Columns; column++)
        {
            reelSymbols.Add(slotMachine.ReelSymbolResult[column, row]);
        }

        return reelSymbols;
    }
}
