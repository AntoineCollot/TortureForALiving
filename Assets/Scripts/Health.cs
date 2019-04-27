using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Image bar;
    public float Progress
    {
        get
        {
            return health / maxHealth;
        }
    }

    public float maxHealth;
    [HideInInspector]
    public float health;

    public static Health Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = Progress;
    }

    public void Damages(float amount)
    {
        health -= amount;
        Score.AddScoreByDamages(amount);
        MoneyBurst.Instance.SetParticleByDamages(amount);

        if(health<=0)
        {
            AnimationManager.Death();

            //Bonus on kill
            Score.AddScoreByDamages(amount);

            GameManager.Instance.GameOver(true);
        }
        health = Mathf.Clamp(health,0, maxHealth);
    }
}
