using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public int walkSpeed;
    public float movementSpeed = 3;
    public bool isRunning;
    public bool isMoving;

    void Update()
    {
        float v = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        float h = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        if(v!=0 || h!=0) isMoving = true;
        else isMoving = false;
        transform.Translate(h, 0, v);
        
        isRunning = GetKeyShift();
    }

    private bool GetKeyShift(){
        return Keyboard.current.shiftKey.isPressed;
    }
}
