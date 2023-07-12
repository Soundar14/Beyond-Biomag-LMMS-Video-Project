using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnimateUI : MonoBehaviour
{
    [SerializeField]
    private RectTransform rectTRight;
    [SerializeField]
    private RectTransform rectTLeft;
    [SerializeField]
    private Vector3 previousPos;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void RightDoHide()
    {
        rectTRight.GetComponent<CanvasGroup>().DOFade(0, 2f);
        //previousPos = rectTRight.position;
        //rectTRight.DOScale(Vector3.zero, 1f);
        ////rectT.DOAnchorPos(rectT.position+verticalSlideDistance,2f);
    }
    public void RightDoReveal() 
    {
        rectTRight.GetComponent<CanvasGroup>().DOFade(1, 2f);
        //Debug.Log(previousPos);
        //rectTRight.DOScale(previousPos, 1f);
    }
    public void LeftDoHide()
    {
        rectTLeft.GetComponent<CanvasGroup>().DOFade(0, 2f);
        //rectT.DOAnchorPos(rectT.position+verticalSlideDistance,2f);
    }
    public void LeftDoReveal()
    {
        rectTLeft.GetComponent<CanvasGroup>().DOFade(1, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
