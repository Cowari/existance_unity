using Unity.VisualScripting;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    [Header("Настройки:")]
    public Transform grab_pos; // Позиция куда мы перемещаем объект
    public RayCast rayCast;

    GameObject grbd_obj; // объект который мы перемещаем
    Rigidbody rigbd_obj; // переменная для RB перемещаемого объекта
    const float smoothSpeed = 4f;
    bool isGrab;

    void Update(){
        TryGrab();

        if(isGrab) Grab();
        else Drop();
        //Debug.Log(isGrab);
    }


    void TryGrab(){
        if(rayCast.hit.collider!=null && Input.GetButton("Fire1") && rayCast.hit.collider.CompareTag("pickupable")){
            isGrab = true;
            grbd_obj = rayCast.hit.collider.gameObject;
            rigbd_obj = grbd_obj.GetComponent<Rigidbody>();
            return;
        }
        if(!Input.GetButton("Fire1")){
            isGrab = false;
        }
    }

    void Grab(){
        if(grbd_obj!=null && rigbd_obj!=null){
            rigbd_obj.useGravity = false;
            //rigbd_obj.isKinematic = true;

            grbd_obj.transform.rotation = Quaternion.Lerp(grbd_obj.transform.rotation, grab_pos.rotation, smoothSpeed * Time.deltaTime);
            grbd_obj.transform.position = Vector3.Lerp(grbd_obj.transform.position, grab_pos.position, smoothSpeed * Time.deltaTime);
        }
    }
    
    void Drop(){
        if(grbd_obj!=null && rigbd_obj!=null){
            rigbd_obj.useGravity = true;
            //rigbd_obj.isKinematic = false; 
            
            grbd_obj = null;
            rigbd_obj = null;
        }
    }

    public bool GrabVal(){
        return isGrab;
    }
}
