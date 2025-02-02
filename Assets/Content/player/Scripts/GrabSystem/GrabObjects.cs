using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.GrabSystem{
    public class GrabObjects : MonoBehaviour
    {
        [Header("Настройки:")]
        public Transform grabPosRot; // Позиция куда мы перемещаем объект
        public RayCastSystem rayCast;
        public LayerMask PlayerLayMask;
        public LayerMask NothingLayMask;

        GameObject grbd_obj; // объект который мы перемещаем
        Rigidbody rigbd_obj; // переменная для RB перемещаемого объекта
        [SerializeField] private float smoothSpeed = 4f;
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
            }
        }

        void Grab(){
            if(IsObjectNotValid()){
                return;
            }
            
            rigbd_obj.excludeLayers = PlayerLayMask;
            rigbd_obj.useGravity = false;

            if(Quaternion.Angle(grbd_obj.transform.rotation, grabPosRot.rotation) > 0.01f){
                    grbd_obj.transform.rotation = Quaternion.Lerp(grbd_obj.transform.rotation, grabPosRot.rotation, smoothSpeed * Time.deltaTime);
            }
            if(Vector3.Distance(grbd_obj.transform.position, grabPosRot.position) > 0.01f){
                grbd_obj.transform.position = Vector3.Lerp(grbd_obj.transform.position, grabPosRot.position, smoothSpeed * Time.deltaTime);
            }
        }
        
        void Drop(){
            if(IsObjectNotValid()){
                return;
            }
            
            rigbd_obj.excludeLayers = NothingLayMask;
            rigbd_obj.useGravity = true;
                
            grbd_obj = null;
            rigbd_obj = null;
        }

        private bool IsObjectNotValid(){
            return grbd_obj==null && rigbd_obj==null;
        }

        public bool getGrab(){
            return isGrab;
        }
    }
}
