using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    public Transform grab_pos;
    public RayCast rayCast;
    private GameObject grbd_obj;
    private Rigidbody rigbd_obj;
    private bool isGrab;
    const float smoothSpeed = 4f;

    void Update(){
        TryGrab();
    }


    void TryGrab(){
        if(rayCast.hit.collider!=null){
            if(Input.GetButton("Fire1")){
                if(rayCast.hit.collider.CompareTag("pickupable")){
                    grbd_obj = rayCast.hit.collider.gameObject;
                    rigbd_obj = grbd_obj.GetComponent<Rigidbody>();
                    isGrab = true;
                }
            }
        }
        if(!Input.GetButton("Fire1"))isGrab = false;

        if(isGrab) Grab();
        else if(rigbd_obj!=null) Drop();
    }

    void Grab(){
        if(grbd_obj!=null && rigbd_obj!=null){
            rigbd_obj.useGravity = false;
            rigbd_obj.isKinematic = true;

            grbd_obj.transform.rotation = Quaternion.Lerp(grbd_obj.transform.rotation, grab_pos.rotation, smoothSpeed * Time.deltaTime);
            grbd_obj.transform.position = Vector3.Lerp(grbd_obj.transform.position, grab_pos.position, smoothSpeed * Time.deltaTime);
        }
    }
    
    void Drop(){
        if(grbd_obj!=null && rigbd_obj!=null){
            rigbd_obj.useGravity = true;
            rigbd_obj.isKinematic = false; 
            
            grbd_obj = null;
            rigbd_obj = null;
        }
    }
}
