using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float endOfray = 3;
    public Vector3 endOfrayPos;
    RaycastHit hit;
    void FixedUpdate(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, endOfray)){
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            //Debug.Log(hit.collider);
            endOfrayPos = hit.point;
            
            
        }
    }



    void OnGUI(){
        if(hit.collider!=null){
            GUI.Label(new Rect(Screen.width/2, 50, 750, 750), "Name = " + hit.collider.name + "\nTag = " + hit.collider.tag);
            switch(hit.collider.tag){
                case "enemy":
                    Debug.Log("Это странное существо...");
                    break;
                case "pickupable":
                    Debug.Log("ПОДНИМИ ЭТО!");
                    break;
            }
        }
    }
}
