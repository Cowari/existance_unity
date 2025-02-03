using UnityEngine;

public class PointScript : MonoBehaviour
{
    public GameObject objPoint;
    RayCastSystem rayCast;
    void Start(){
        rayCast = GetComponent<RayCastSystem>();
        
    }

    void Update(){
        objPoint.transform.position = rayCast.GetEndRayPos();
    }
}
