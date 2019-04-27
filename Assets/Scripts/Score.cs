using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{
    public static float score;

    public static void AddScoreByDamages(float amount)
    {
        if(amount>0)
            score += amount * 10;
    }
}
