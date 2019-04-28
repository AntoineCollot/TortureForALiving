using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Card", order = 1)]
public class Card : ScriptableObject
{
    public MoveType move;
    public float damages;
    public float executionTime = 0.2f;
    public Sprite image;
}

public enum MoveType
{
    Gun,
    Headbutt,
    Knee,
    Kiss,
    ThumbsUp,
    Water,
    Tired,
    Stab,
    RepeatLast
}