using System;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    private static int deathCount;

    public int DeathCount
    {
        get { return deathCount; }
    }

    public event Action<int, int> OnPlayerDied;

    public void AddDeath()
    {
        int previousDeathCount = deathCount;
        deathCount++;

        PlayerJump.ResetJumps();

        OnPlayerDied?.Invoke(previousDeathCount, deathCount);
    }

    public void ResetDeaths()
    {
        deathCount = 0;
    }
}