#pragma strict


public var obj : GameObject;
function Start () {

}

function Update () {
  
  
    if(Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Began)
    {
       obj = null;
       var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
       var hit : RaycastHit;
       if(Physics.Raycast(ray,hit, 100))
       {
           obj = hit.transform.gameObject;
           }
           }
           if(obj && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
           {
              obj.transform.position += Vector3(Input.GetTouch(0).deltaPosition.x/200.0,Input.GetTouch(0).deltaPosition.y/200.0,0);
             }
             if(obj && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
             {
                obj = null;
                }
                }
