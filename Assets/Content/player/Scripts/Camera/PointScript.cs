using UnityEngine;

public class PointScript : MonoBehaviour
{
    public GameObject point;
    RayCast rayCast;
    void Start(){
        rayCast = GetComponent<RayCast>();
        
    }

    void Update(){
        point.transform.position = rayCast.endOfrayPos;
    }
}
