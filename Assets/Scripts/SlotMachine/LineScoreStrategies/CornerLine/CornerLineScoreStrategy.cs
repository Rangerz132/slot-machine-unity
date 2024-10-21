using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CornerLineStrategy", menuName = "LineScores/CornerLineStrategy", order = 0)]
public class CornerLineScoreStrategy : LineScoreStrategy
{
    public override List<ReelSymbol> GetReelSymbols(SlotMachine slotMachine)
    {
        List<ReelSymbol> reelSymbols = new List<ReelSymbol>();

        reelSymbols.Add(slotMachine.ReelSymbolResult[0, 0]);
        reelSymbols.Add(slotMachine.ReelSymbolResult[0, slotMachine.Rows - 1]);
        reelSymbols.Add(slotMachine.ReelSymbolResult[slotMachine.Columns - 1, 0]);
        reelSymbols.Add(slotMachine.ReelSymbolResult[slotMachine.Columns - 1, slotMachine.Rows - 1]);

        return reelSymbols;
    }
}
