using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator red;
    public Animator brown;

    public static AnimationManager Instance;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public static void PlayAnimation(MoveType move)
    {
        switch (move)
        {
            case MoveType.Gun:
                Instance.Gun();
                break;
            case MoveType.Headbutt:
                Instance.Head();
                break;
            case MoveType.Knee:
                Instance.Knee();
                break;
            case MoveType.Kiss:
                Instance.Kiss();
                break;
            case MoveType.ThumbsUp:
                Instance.ThumbsUp();
                break;
            case MoveType.Water:
                Instance.Water();
                break;
            case MoveType.Tired:
                Instance.Tired();
                break;
            case MoveType.Stab:
                Instance.Knife();
                break;
            default:
                break;
        }
    }

    public void Knee()
    {
        red.SetTrigger("Knee");
        brown.SetTrigger("LowHit");
    }
    public void Gun()
    {
        red.SetTrigger("Gun");
        brown.SetTrigger("Gun");
    }
    public void Head()
    {
        red.SetTrigger("Head");
        brown.SetTrigger("HightHit");
    }
    public void Kiss()
    {
        red.SetTrigger("Kiss");
        brown.SetTrigger("Kiss");
    }
    public void ThumbsUp()
    {
        red.SetTrigger("ThumbsUp");
    }
    public void Water()
    {
        red.SetTrigger("Water");
        brown.SetTrigger("Kiss");
    }
    public void Tired()
    {
        red.SetTrigger("Tired");
    }
    public void Knife()
    {
        red.SetTrigger("Knife");
        brown.SetTrigger("Stab");
    }
    public static void Death()
    {
        Instance.brown.SetTrigger("Die");
    }
}
