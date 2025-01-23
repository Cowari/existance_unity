using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    StaminaMBS staminaMBS;
    public int walkSpeed;
    public float runSpeed;
    public float movementSpeed = 3;
    public bool isRunning;
    public bool isMoving;

    void Start()
    {
        staminaMBS = GetComponent<StaminaMBS>();
    }

    void Update()
    {
        float v = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        float h = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        if(v!=0 || h!=0) isMoving = true;
        else isMoving = false;

        transform.Translate(h, 0, v);

        if (Input.GetKeyUp(KeyCode.LeftShift)) isRunning = false;
        if (Input.GetKeyDown(KeyCode.LeftShift)) isRunning = true;

        //if(isRunning==true) movementSpeed = runSpeed * (staminaMBS.energy_value/100);
        if(isRunning==true) movementSpeed = runSpeed;
        if(isRunning==false) movementSpeed = walkSpeed;

        //if(movementSpeed<walkSpeed) isRunning = false;
    }
}
