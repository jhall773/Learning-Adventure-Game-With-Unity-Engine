using UnityEngine;

[CreateAssetMenu(menuName = "Game/DialogState")]
public class DialogState : ScriptableObject
{
    public int[] directions = new int[4] { 2, 2, 2, 2 };
    public int direction_spot = 0;


    public bool gotShrooms = false;
    public bool gotCabbage = false;
    public bool gotApples = false;
    public bool gotSeeds = false;

    private const int even = 0;
    private const int odd = 1;

    public void ResetDirections()
    {
        for (int i = 0; i < directions.Length; i++) directions[i] = 2;
        direction_spot = 0;
    }

    public void ResetShrooms() { gotShrooms = false; }
    public void ResetCabbage() { gotCabbage = false; }
    public void ResetApples() { gotApples = false; }
    public void ResetSeeds() { gotSeeds = false; }

    // Direction helper so the asset can be mutated directly
    public void EnterDirection(int direction)
    {
        if (direction_spot < 0) direction_spot = 0;
        if (directions == null || directions.Length < 4) directions = new int[4] { 2, 2, 2, 2 };
        if (direction_spot >= directions.Length)
        {
            Debug.LogWarning("DialogState.EnterDirection: direction_spot out of range. Resetting to 0.");
            direction_spot = 0;
        }

        directions[direction_spot] = direction;
        direction_spot += 1;
    }

    public bool GetToShopShrooms()
    {
        return directions.Length >= 4 &&
               directions[0] == even &&
               directions[1] == odd &&
               directions[2] == even &&
               directions[3] == odd;
    }

    public bool GetToShopCabbage()
    {
        return directions.Length >= 4 &&
               directions[0] == odd &&
               directions[1] == odd &&
               directions[2] == even &&
               directions[3] == odd;
    }

    public bool GetToShopApples()
    {
        return directions.Length >= 4 &&
               directions[0] == even &&
               directions[1] == even &&
               directions[2] == odd &&
               directions[3] == even;
    }

    public bool GetToShopSeeds()
    {
        return directions.Length >= 4 &&
               directions[0] == odd &&
               directions[1] == even &&
               directions[2] == odd &&
               directions[3] == even;
    }
}