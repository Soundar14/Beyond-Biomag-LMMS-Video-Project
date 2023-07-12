using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanpointsHandler : MonoBehaviour
{
    public GameObject[] cam;
    public GameObject[] correspondingCam;
    public GameObject[] child;
    public GameObject[] correspondingChild;
    public GameObject[] scanPoints;

    private void OnEnable()
    {
        MouseClick.onclickAction += Deactivator;
        MouseClick.onclickActionInv += DeactivatorInv;
    }

    private void OnDisable()
    {
        MouseClick.onclickAction -= Deactivator;
        MouseClick.onclickActionInv -= DeactivatorInv;
    }

    void Deactivator(int id)
    {
        Debug.Log("ID =>" + id);
        for(int i = 0; i < cam.Length; i++)
        {
            if(i == id)
            {
                cam[i].SetActive(true);
                scanPoints[i].SetActive(true);
                child[i].SetActive(true);
            }
            else
            {
                cam[i].SetActive(false);
                scanPoints[i].SetActive(false);
                child[i].SetActive(false);
            }
        }
    }

    void DeactivatorInv(int id)
    {
        Debug.Log("ID =>" + id);
        for (int i = 0; i < cam.Length; i++)
        {
            if (i == id)
            {
                correspondingCam[i].SetActive(true);
                scanPoints[i].SetActive(true);
            }
            else
            {
                correspondingCam[i].SetActive(false);
                scanPoints[i].SetActive(false);
            }
        }
        for (int i = 0; i < child.Length; i++)
        {
            if (i == id)
            {
                correspondingChild[i].SetActive(true);
            }
            else
            {
                correspondingChild[i].SetActive(false);
            }
        }
    }
}
