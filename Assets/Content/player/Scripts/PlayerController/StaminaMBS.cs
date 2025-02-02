using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;

public class StaminaMBS : MonoBehaviour
{
    PlayerMovement plyMovement;
    public float energy_value = 100;
    float speed = 1;
    float speedMin =1;

    void Start()
    {
        plyMovement = GetComponent<PlayerMovement>();
        //runSpd = plyMovement.runSpeed;
        StartCoroutine(StaminaUpdate());
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width/2, Screen.height - 100, 750, 750), "Energy: " + energy_value);
    }

    void Update()
    {
        speed = Mathf.Clamp(speed, speedMin, 2);
        plyMovement.movementSpeed = plyMovement.walkSpeed * speed;
    }

    IEnumerator StaminaUpdate()
    {   
        while(true){

            if(plyMovement.isMoving && plyMovement.isRunning == true && energy_value>35){
                energy_value--;
                speed+=0.1f;
                yield return new WaitForSeconds(0.05f);
            }
            else if(energy_value<100 && (!plyMovement.isMoving || plyMovement.isRunning == false)){
                energy_value++;
                speedMin = 1;
                speed-=0.1f;
                yield return new WaitForSeconds(0.1f);
            }
            else{
                yield return null;
            }


            if(plyMovement.isMoving && plyMovement.isRunning == true && energy_value>0 && energy_value<=35){
                energy_value--;
                speedMin = 0.25f;
                speed-=0.1f;
                yield return new WaitForSeconds(0.1f);
            }

        }
    }
}
