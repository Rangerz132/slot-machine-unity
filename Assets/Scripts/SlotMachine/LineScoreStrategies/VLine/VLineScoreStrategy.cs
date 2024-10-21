using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VLineStrategy", menuName = "LineScores/VLineStrategy", order = 0)]
public class VLineScoreStrategy : LineScoreStrategy
{
    public override List<ReelSymbol> GetReelSymbols(SlotMachine slotMachine)
    {
        List<ReelSymbol> reelSymbols = new List<ReelSymbol>();

        for (var column = 0; column < slotMachine.Columns; column++)
        {
            int row;

            if (column < slotMachine.Rows)
            {
                row = column;
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
