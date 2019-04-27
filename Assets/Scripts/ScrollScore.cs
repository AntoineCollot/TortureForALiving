using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollScore : MonoBehaviour
{
    public float scrollTime;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(Anim());
    }

    IEnumerator Anim()
    {
        Text text = GetComponent<Text>();

        float t = 0;

        while(t<1)
        {
            t += Time.deltaTime / scrollTime;

            text.text = Mathf.RoundToInt(Mathf.Lerp(0, Score.score, t)).ToString();

            yield return null;
        }
    }
}
