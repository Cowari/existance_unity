using UnityEngine;

public class PointScript : MonoBehaviour
{
    public GameObject point;
    RayCastSystem rayCast;
    void Start(){
        rayCast = GetComponent<RayCastSystem>();
        
    }

    void Update(){
        point.transform.position = rayCast.getEndRayPos();
    }
}
