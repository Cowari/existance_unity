using UnityEngine;

public class RayCastSystem : MonoBehaviour{
    public RaycastHit hit;
    Vector3 endRayPos;
    const float rayLength = 3;

    void FixedUpdate(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, rayLength)){
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            endRayPos = hit.point;
        }
    }

    public Vector3 GetEndRayPos(){
        return endRayPos;
    }


    void OnGUI(){
        if(hit.collider!=null){
            GUI.Label(new Rect(Screen.width/2, 50, 750, 750), "Name = " + hit.collider.name + "\nTag = " + hit.collider.tag);
            switch(hit.collider.tag){
                case "enemy":
                    //Debug.Log("Это странное существо...");
                    break;
                case "pickupable":
                    //Debug.Log("ПОДНИМИ ЭТО!");
                    break;
            }
        }
    }
}
