using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Image cardIcon;
    public Text cardText;
    public Button button;

    public Sprite damageBackground;
    public Sprite healBackground;

    public void SetCard(Card card)
    {
        cardText.text = card.move.ToString();
        cardIcon.sprite = card.image;
        SpriteState state = button.spriteState;
        if (card.damages > 0)
            state.pressedSprite = damageBackground;
        else
            state.pressedSprite = healBackground;
        button.spriteState = state;
    }
}
