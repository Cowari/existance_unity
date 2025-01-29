using UnityEngine;
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

    void Update()
    {
        isGrab = grabObjects.GrabVal();
        NewPos();
        //Debug.Log(scrollDist);
        
        transform.localPosition = newDistance;
    }

    void NewPos(){
        if(isGrab) scrollDist += Input.GetAxis("Mouse ScrollWheel");
        else scrollDist = midDist;
        scrollDist = Mathf.Clamp(scrollDist, minDist, minDist*2);

        newDistance = new Vector3(0,0,scrollDist);
    }

    public Vector3 get_newDistance(){
        return newDistance;
    }
}
