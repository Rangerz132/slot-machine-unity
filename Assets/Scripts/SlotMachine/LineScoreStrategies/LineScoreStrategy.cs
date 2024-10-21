using UnityEngine;
using System.Collections.Generic;

public abstract class LineScoreStrategy : ScriptableObject {

    public abstract List<ReelSymbol> GetReelSymbols(SlotMachine slotMachine);
}
