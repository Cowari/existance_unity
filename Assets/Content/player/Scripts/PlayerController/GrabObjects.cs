using System.Collections;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    public Transform grab_pos;
    public RayCast rayCast;
    private RaycastHit hit;
    private GameObject grbd_obj;
    private Rigidbody rigbd_obj;
    private bool isGrab;

    void Update(){
        TryGrab();
    }


    void TryGrab(){
        if(rayCast.hit.collider!=null){
            hit = rayCast.hit;
        }
        
    
        if(Input.GetAxis("Fire1")==1){
            if(hit.collider.tag=="pickupable"){
                grbd_obj = hit.collider.gameObject;
                rigbd_obj = grbd_obj.GetComponent<Rigidbody>();
                isGrab = true;
            }
        }else{
            isGrab = false;
        }

        if(isGrab) Grab();
        if(rigbd_obj!=null && !isGrab) Drop();
    }

    void Grab(){  
        rigbd_obj.useGravity = false;
        rigbd_obj.isKinematic = true;

        grbd_obj.transform.position = grab_pos.position;
    }
    
    void Drop(){
        rigbd_obj.useGravity = true;
        rigbd_obj.isKinematic = false; 
    }

    /*IEnumerator ObjPosition(){
        while(true){

            yield return new WaitForSeconds(0.1f);
        }
    }*/
}
