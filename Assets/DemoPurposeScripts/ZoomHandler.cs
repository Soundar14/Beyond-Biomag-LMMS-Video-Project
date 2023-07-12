using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomHandler : MonoBehaviour
{
    public GameObject initialCam;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject[] magnetPoints;
    public GameObject info1;
    public GameObject info2;
    private void Start()
    {
        StartCoroutine(ZoomEffect());
    }

    IEnumerator ZoomEffect()
    {
        yield return new WaitForSeconds(5f);
        initialCam.SetActive(false);
        cam1.SetActive(true);
        yield return new WaitForSeconds(1f);
        magnetPoints[1].SetActive(true);
        yield return new WaitForSeconds(2f);
        cam1.SetActive(false);
        initialCam.SetActive(true);
        yield return new WaitForSeconds(2f);
        initialCam.SetActive(false);
        cam2.SetActive(true);
        info2.SetActive(true);
        yield return new WaitForSeconds(1f);
        magnetPoints[0].SetActive(true);
        yield return new WaitForSeconds(2f);
        cam2.SetActive(false);
        initialCam.SetActive(true);
        yield return new WaitForSeconds(1f);
    }
}
