using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;

public class StaminaMBS : MonoBehaviour
{
    PlayerMovement playerMovement;
    public float energy_value = 100;
    float updateSpeed;
    float suka;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        StartCoroutine(StaminaUpdate());
        suka = playerMovement.runSpeed;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width/2, Screen.height - 100, 750, 750), "Energy: " + energy_value);
    }

    IEnumerator StaminaUpdate()
    {
        
        while(true){
            if(playerMovement.isMoving && playerMovement.isRunning == true && energy_value>0){
                energy_value--;
                yield return new WaitForSeconds(0.05f);

                if(energy_value<35){
                    updateSpeed = 0.3f;
                    energy_value--;
                    if(playerMovement.runSpeed>playerMovement.walkSpeed-1){
                        playerMovement.runSpeed-=0.5f;
                    }
                yield return new WaitForSeconds(0.02f);
                }
            }
            else if(energy_value<100 && (!playerMovement.isMoving || playerMovement.isRunning == false)){
                energy_value++;
                if(energy_value>35){
                    updateSpeed = 0.1f;
                    if(playerMovement.runSpeed<suka){
                        playerMovement.runSpeed++;
                        yield return new WaitForSeconds(0.3f);
                    }
                }
                yield return new WaitForSeconds(updateSpeed);
            }
            else{
                yield return null;
            }

        }
    }
}
