using UnityEngine;

[CreateAssetMenu(menuName = "Game/SavePlaceValueState")]
public class SavePlaceValueState : ScriptableObject
{
    public int whatKind = 1; //"whatKind" of power the machine needs changes as you progress. Thus, "whatKind" measures what machine you are on (up to machine #8).
    public int targetVal = 1; ////"targetVal" of power the current machine needs.

    public void setCurrentMachineInt(int current_Machine)
    {
        whatKind = current_Machine;
    }
}