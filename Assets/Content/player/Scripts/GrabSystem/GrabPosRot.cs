using UnityEngine;
using Player.GrabSystem;
public class GrabPosRot : MonoBehaviour
{
    public GrabObjects grabObjects;

    Vector3 newDistance;
    float scrollDist;
    float minDist = 1.5f;
    float midDist;
    float maxDist = 3f;
    bool isGrab;
    
    
    void Start(){
        midDist = maxDist - minDist/2;
        scrollDist = midDist;
    }

    void Update(){
        isGrab = grabObjects.getGrab();
        //Debug.Log(scrollDist);
        
        newDistance = NewPos();
        transform.localPosition = newDistance;
    }

    Vector3 NewPos(){
        if(isGrab) scrollDist += Input.GetAxis("Mouse ScrollWheel");
        else scrollDist = midDist;
        scrollDist = Mathf.Clamp(scrollDist, minDist, maxDist);

        return new Vector3(0,0,scrollDist);
    }

    public Vector3 getNewDistance(){
        return newDistance;
    }
}
