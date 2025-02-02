using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabObjects : MonoBehaviour
{
    [Header("Настройки:")]
    public Transform grabPosRot; // Позиция куда мы перемещаем объект
    public RayCastSystem rayCast;
    public LayerMask PlayerLayMask;
    public LayerMask NothingLayMask;

    GameObject grbd_obj; // объект который мы перемещаем
    Rigidbody rigbd_obj; // переменная для RB перемещаемого объекта
    const float smoothSpeed = 4f;
    bool isGrab;

    void Update(){
        TryGrab();

        if(isGrab) Grab();
        else Drop();
    }


    void TryGrab(){
        if(!Mouse.current.leftButton.isPressed){
            isGrab = false;
        }

        var collider = rayCast.hit.collider;
        if(collider==null){
            return;
        }
        else if(Mouse.current.leftButton.isPressed && collider.CompareTag("pickupable")){
            isGrab = true;
            grbd_obj = collider.gameObject;
            rigbd_obj = grbd_obj.GetComponent<Rigidbody>();
            return;
        }
    }

    void Grab(){
        if(grbd_obj==null && rigbd_obj==null){
            return;
        }
        else{
            rigbd_obj.excludeLayers = PlayerLayMask;
            rigbd_obj.useGravity = false;
            //rigbd_obj.isKinematic = true;

            grbd_obj.transform.rotation = Quaternion.Lerp(grbd_obj.transform.rotation, grabPosRot.rotation, smoothSpeed * Time.deltaTime);
            grbd_obj.transform.position = Vector3.Lerp(grbd_obj.transform.position, grabPosRot.position, smoothSpeed * Time.deltaTime);
        }
    }
    
    void Drop(){
        if(grbd_obj==null && rigbd_obj==null){
            return;
        }
        else{
            rigbd_obj.excludeLayers = NothingLayMask;
            rigbd_obj.useGravity = true;
            //rigbd_obj.isKinematic = false; 
            
            grbd_obj = null;
            rigbd_obj = null;
        }
    }

    public bool getGrab(){
        return isGrab;
    }
}
