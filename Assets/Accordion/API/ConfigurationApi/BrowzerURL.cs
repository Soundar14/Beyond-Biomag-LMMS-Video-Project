//Weblink navigation will be handled in this script.
using UnityEngine;
using System.Collections;

public class BrowzerURL : MonoBehaviour {

	public  GameObject langpanel,promotionPanel;
	public  GameObject UnderConstructionPanel;
	public GameObject AboutUsPanel;
	public GameObject BasicConcepts;
	public GameObject TermsConditionPanel;
	public GameObject TutorialPanel, flashing_Label,navdot,promdot, PromotionPage;



    public void Update()
    {
        if (PlayerPrefs.GetInt("OpenedEvent") == 1)
        {
            navdot.SetActive(false);
            promdot.SetActive(false);
        }
    }

    public void BasicConcept()
	{

		BasicConcepts.SetActive(true);
	}
	public void About()
	{
		AboutUsPanel.SetActive (true);
	}
	public void LanguagesOn()
	{
		langpanel.SetActive (true);
	}
	public void LanguagesOff()
	{
		langpanel.SetActive (false);
	}
    public void PromoOn()
    {
        promotionPanel.SetActive(true);

        if (PlayerPrefs.GetInt("OpenedEvent") != 1)
        {
            Blinkscript.blinked = true;
        }
        else
        {
            Blinkscript.blinked = false;
            //navdot.SetActive(false);
            //promdot.SetActive(false);
        }

    }
    public void PromoOff()
    {
        promotionPanel.SetActive(false);
    }

    public void Bloglnk()
    {
        Application.OpenURL("https://www.beyondbiomag.io/blog");
        promotionPanel.SetActive(false);

    }

    public void Trainlnk()
    {
        Blinkscript.blinked = false;
        PlayerPrefs.SetInt("OpenedEvent", 1);
        Application.OpenURL("https://usbiomag.com/october-seminar/");
        PromoOff();
    }

    public void regislink()
    {
        Application.OpenURL("https://usbiomag.com/october-seminar/");

    }
    public void RegisSpanishlink()
    {
        Application.OpenURL("https://usbiomag.com/inicio/");

    }
    public void Promoclose()
    {
        PromotionPage.SetActive(false);
    }
    public void Promoopen()
    {
        PromoOff();
        PlayerPrefs.SetInt("OpenedEvent", 1);
        PromotionPage.SetActive(true);


    }

    public void TermsAndCondition()
	{
		Application.OpenURL("https://www.beyondbiomag.io/terms-and-policy");
		//TermsConditionPanel.SetActive(true);

	}


	public void website(){
		Application.OpenURL("https://www.beyondbiomag.io/");
	}
	IEnumerator WaitInfo(){
		
		UnderConstructionPanel.SetActive (true);
		yield return new WaitForSeconds (3);
		UnderConstructionPanel.SetActive (false);
	}

	public void AboutUsOff(){
		AboutUsPanel.SetActive (false);
		BasicConcepts.SetActive (false);
		TermsConditionPanel.SetActive(false);
	}

	public void TutorialOn(){
		
		TutorialPanel.SetActive (true);
	}

	public void TutorialOff(){

		TutorialPanel.SetActive (false);
	}




}
