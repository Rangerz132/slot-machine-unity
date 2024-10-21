using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VInverseLineStrategy", menuName = "LineScores/VInverseLineStrategy", order = 0)]
public class VInverseLineScoreStrategy : LineScoreStrategy
{
    public override List<ReelSymbol> GetReelSymbols(SlotMachine slotMachine)
    {
        List<ReelSymbol> reelSymbols = new List<ReelSymbol>();

        for (var column = 0; column < slotMachine.Columns; column++)
        {
            int row;

            if (column < slotMachine.Rows)
            {
                row = slotMachine.Rows - 1 - column; 
            }
            else
            {
                row = column - slotMachine.Rows + 1; 
            }

            if (row >= 0 && row < slotMachine.Rows)
            {
                reelSymbols.Add(slotMachine.ReelSymbolResult[column, row]);
            }
        }

        return reelSymbols;
    }
}
