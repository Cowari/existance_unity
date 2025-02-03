using System.Collections;
using UnityEngine;

public class StaminaMBS : MonoBehaviour
{
    PlayerMovement plyMovement;
    public float energyVal = 100;
    float speedCoeff = 1; // speed coefficient
    float speedMin = 1; // minimal coefficient speed

    void Start()
    {
        plyMovement = GetComponent<PlayerMovement>();
        //runSpd = plyMovement.runSpeed;
        StartCoroutine(StaminaUpdate());
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width/2, Screen.height - 100, 750, 750), "Energy: " + energyVal);
    }

    void Update()
    {
        speedCoeff = Mathf.Clamp(speedCoeff, speedMin, 2);
        plyMovement.movementSpeed = plyMovement.walkSpeed * speedCoeff;
    }

    IEnumerator StaminaUpdate()
    {   
        while(true){

            if(plyMovement.isMoving && plyMovement.isRunning == true && energyVal > 35){ // движется+бежит+энергия>35
                energyVal--;
                speedCoeff += 0.1f;
                yield return new WaitForSeconds(0.05f);
            }
            else if(energyVal < 100 && (!plyMovement.isMoving || plyMovement.isRunning == false)){ // не движется||не бежит, энергия<100
                energyVal++;
                speedMin = 1;
                speedCoeff -= 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
            else{
                yield return null;
            }


            if(plyMovement.isMoving && plyMovement.isRunning == true && energyVal > 0 && energyVal <= 35){
                energyVal--;
                speedMin = 0.25f;
                speedCoeff -= 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
