using UnityEngine;
using System.Collections;

public class ColliderButton : MonoBehaviour {
    public GameObject Target;
    public string Message;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {

        Target.SendMessage(Message);
    }
}
