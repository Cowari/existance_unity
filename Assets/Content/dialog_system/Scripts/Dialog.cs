using UnityEngine;
using TMPro;
using System.Collections;

public class dialogueText : MonoBehaviour
{
    // tremor
    public GameObject tremor_object;
    public float diapazon = 0.01f;
    Vector3 pos;
    // text
    public TextMeshProUGUI myText;
    public string speech;
    public float TextSpeed = 0.07f;
    private string word;

    bool stop_tremor = false;


    void Start(){
        // tremor
        pos = tremor_object.transform.localPosition;
        // text
        StartCoroutine(Speech());
    }

    void Update()
    {
        // text
        myText.text = word;

        // tremor
        if(stop_tremor == false){
            float x = Random.Range(pos.x + diapazon, pos.x - diapazon);
            float z = Random.Range(pos.z + diapazon, pos.z - diapazon);

            Vector3 newPos = new Vector3(x,pos.y, z);
            tremor_object.transform.localPosition = newPos;
        }
    }

    IEnumerator Speech()
    {
        foreach(char c in speech){
            word+=c;
            yield return new WaitForSeconds(TextSpeed);
        }
        stop_tremor = true;
    }

}