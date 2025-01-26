using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject person;
    public float sensetivity = 2;
    float rotationY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensetivity * Time.deltaTime;
        
        
        person.transform.Rotate(Vector3.up, mouseX); // left/right
        
        rotationY-=mouseY;
        rotationY = Mathf.Clamp(rotationY,-90f,90f);
        transform.localRotation = Quaternion.Euler(rotationY,0,0); // up/down
    }
}
