using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeArrows : MonoBehaviour
{
    [SerializeField]
    private GameObject r_Arrow;
    [SerializeField]
    private GameObject l_Arrow;

    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator FadeCanvasGroup(CanvasGroup canvasG,float Start,float End)
    {
        canvasG.alpha = Start;
        if (Start < End)
        {
            while (canvasG.alpha < End)
            {
                canvasG.alpha += Time.deltaTime*3;
                yield return new WaitForSeconds(0.1f);
            }
        }
        else
        {
            while (canvasG.alpha > End)
            {
                canvasG.alpha -= Time.deltaTime*3;
                yield return new WaitForSeconds(0.1f);
            }
        }
        
        
    }

    public void DoHideRightArrow()
    {
        //Debug.Log("Fade Out Called on Right Arrow");
        CanvasGroup cG = r_Arrow.GetComponent<CanvasGroup>();
        StartCoroutine(FadeCanvasGroup(cG, 1, 0));
         //r_Arrow.GetComponent<CanvasGroup>().DOFade(0, 1f);
        // Debug.Log(r_Arrow.GetComponent<SpriteRenderer>().color.a);
    }
    public void DoRevealRightArrow()
    {
        CanvasGroup cG = r_Arrow.GetComponent<CanvasGroup>();
        StartCoroutine(FadeCanvasGroup(cG, 0, 1));
        //Debug.Log("Fade In Called on Right Arrow");
        //r_Arrow.GetComponent<CanvasGroup>().DOFade(1, 1f);
    }

    public void DoHideLeftArrow()
    {
        CanvasGroup cG = l_Arrow.GetComponent<CanvasGroup>();
        StartCoroutine(FadeCanvasGroup(cG, 1, 0));
        //Debug.Log("Fade Out Called on Left Arrow");
        //l_Arrow.GetComponent<CanvasGroup>().DOFade(0, 1f);
    }
    public void DoRevealLefttArrow()
    {
        CanvasGroup cG = l_Arrow.GetComponent<CanvasGroup>();
        StartCoroutine(FadeCanvasGroup(cG, 0, 1));
        //Debug.Log("Fade In Called on Left Arrow");
        l_Arrow.GetComponent<CanvasGroup>().DOFade(1, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
