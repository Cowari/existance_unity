using TMPro;
using UnityEngine;

public interface ITremorManager{
    void UpdateTremor(bool isActive);
}

public class TremorManager : ITremorManager
{
    private TextMeshProUGUI myText;
    private float tremorStrength;
    private Vector3 defPos; // Default position.

    public TremorManager(TextMeshProUGUI text, float strength, Vector3 position){
        myText = text;
        tremorStrength = strength;
        defPos = position;
    }

    public void UpdateTremor(bool isActive){
        if(isActive){
            float x = Random.Range(defPos.x - tremorStrength, defPos.x + tremorStrength);
            float y = Random.Range(defPos.y - tremorStrength, defPos.y + tremorStrength);
            myText.transform.position = new Vector2(x, y);
        }
        else{
            if(myText.transform.position != defPos){
                myText.transform.position = defPos;
            }
        }
    }
}
