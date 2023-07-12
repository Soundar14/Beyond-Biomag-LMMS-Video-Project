using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class SlideDown : MonoBehaviour
{
    [SerializeField]
    private Vector2 slideDistance = new Vector2(0, -100);

   RectTransform rectTransform;
    private void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.DOAnchorPos(slideDistance, 1f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
