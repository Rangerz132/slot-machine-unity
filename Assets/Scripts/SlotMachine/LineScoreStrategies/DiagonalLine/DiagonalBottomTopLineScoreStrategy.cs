using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DiagonalLineStrategy", menuName = "LineScores/DiagonalBottomTopLineStrategy", order = 0)]
public class DiagonalBottomTopLineScoreStrategy : LineScoreStrategy
{
    public override List<ReelSymbol> GetReelSymbols(SlotMachine slotMachine)
    {
        List<ReelSymbol> reelSymbols = new List<ReelSymbol>();

        int dimension = Mathf.Min(slotMachine.Columns, slotMachine.Rows);

        for (var i = dimension - 1; i >= 0; i--)
        {
            if (slotMachine.ReelSymbolResult[i, i] != null)
            {
                reelSymbols.Add(slotMachine.ReelSymbolResult[i, i]);
            }
        }

        return reelSymbols;
    }
}
