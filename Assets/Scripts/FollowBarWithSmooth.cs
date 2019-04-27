using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowBarWithSmooth : MonoBehaviour
{
    public Image target;
    Image bar;
    float refFill;
    public float smooth;

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (bar.fillAmount < target.fillAmount)
            bar.fillAmount = target.fillAmount;
        bar.fillAmount = Mathf.SmoothDamp(bar.fillAmount,target.fillAmount,ref refFill, smooth);
    }
}
