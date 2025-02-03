using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Настройки:")]
    public GameObject playerObject;
    public float mouseSensitivityScale  = 1000f;

    float rotationY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityScale * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityScale * Time.deltaTime;
        
        
        playerObject.transform.Rotate(Vector3.up, mouseX); // left/right
        
        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotationY, 0, 0); // up/down
    }
}

