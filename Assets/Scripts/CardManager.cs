using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public CardInDeck[] cards;

    public CardDisplay leftDisplay;
    public CardDisplay rightDisplay;

    Card leftCard;
    Card rightCard;

    public Animator cardsAnimations;

    //Repeat
    Card lastCardUsed;

    // Start is called before the first frame update
    void Start()
    {
        DrawCards();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            UseCard(leftCard,true);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            UseCard(rightCard,false);
        }
    }

    public void UseLeftCard()
    {
        UseCard(leftCard,true);
    }
    public void UseRightCard()
    {
        UseCard(rightCard,false);
    }

    public void UseCard(Card card,bool left)
    {
        if (GameManager.gameIsOver)
            return;

        MoveType move = card.move;
        float damages = card.damages;

        //If it's a repeat card, use last card used values except time
        if (card.move == MoveType.RepeatLast && lastCardUsed!=null)
        {
            move = lastCardUsed.move;
            damages = lastCardUsed.damages;
        }
        else
        {
            lastCardUsed = card;
        }

        Debug.Log("Used card " + card.move.ToString());
        Health.Instance.Damages(damages);
        AnimationManager.PlayAnimation(move);
        AudioManager.Instance.PlaySound(move);

        cardsAnimations.SetBool("Show", false);
        cardsAnimations.SetBool("Left", left);
        Invoke("DrawCards",card.executionTime);
    }

    public void DrawCards()
    {
        if (GameManager.gameIsOver)
            return;
        cardsAnimations.SetBool("Show", true);

        leftCard = DrawRandomCard();
        do
        {
            rightCard = DrawRandomCard();
        } while (rightCard == leftCard);

        leftDisplay.SetCard(leftCard);
        rightDisplay.SetCard(rightCard);
    }

    public Card DrawRandomCard()
    {
        int totalCardCount = 0;
        foreach(CardInDeck c in cards)
        {
            totalCardCount += c.count;
        }

        int cardToDraw = Random.Range(0, totalCardCount);
        foreach (CardInDeck c in cards)
        {
            if(cardToDraw<c.count)
            {
                return c.card;
            }
            else
            {
                cardToDraw -= c.count;
            }
        }

        return null;
    }

    [System.Serializable]
    public struct CardInDeck
    {
        public Card card;
        public int count;
    }
}
