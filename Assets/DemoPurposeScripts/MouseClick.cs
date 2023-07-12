using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MouseClick : MonoBehaviour
{
    private Camera mainCamera;

    public int id;

    public static Action<int> onclickAction;
    public static Action<int> onclickActionInv;

    public bool canExpand;
    public GameObject background;
    private void Start()
    {
        mainCamera = Camera.main;
        canExpand = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                onclickAction?.Invoke(clickedObject.GetComponent<MouseClick>().id);
            }
        }
    }

    public void SwitchCam()
    {
        onclickActionInv?.Invoke(id);
    }

    public void ExpandConverge()
    {
        if(canExpand)
        {
            background.SetActive(true);
        }
        else
        {
            background.SetActive(false);
        }
        canExpand = !canExpand;
    }
}