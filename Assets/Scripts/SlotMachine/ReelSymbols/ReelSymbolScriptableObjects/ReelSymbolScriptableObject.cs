using UnityEngine;

[CreateAssetMenu(fileName = "ReelSymbol", menuName = "ReelSymbols/ReelSymbol", order = 0)]
public class ReelSymbolScriptableObject : ScriptableObject
{
    public string displayName;
    public string id;
    public Sprite sprite;
    public int value;
    public bool wild;
}
