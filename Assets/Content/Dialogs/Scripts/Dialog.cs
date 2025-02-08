using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class DialogueText : MonoBehaviour
{
    [SerializeField] List<string> paragraphs = new List<string>();
    public TextMeshProUGUI myText;

    private Coroutine symbolAppearCoroutine;
    float tremorStrength = 2f;
    float textAnimSpeed = 0.07f;
    bool tremorActive = true;
    int pIndex = 0; // paragraph index
    string symbols;
    Vector3 pos;


    void Start(){
        pos = myText.transform.position;
        symbolAppearCoroutine = StartCoroutine(SymbolAppear());
    }

    void Update(){
        if(DialogContinueButton()){ // Если кнопка для продолжения нажата
            tremorActive = true;
            if(symbolAppearCoroutine == null){
                symbols = null;
                pIndex++;
                symbolAppearCoroutine = StartCoroutine(SymbolAppear());
            }
        }

        if(tremorActive){
            float x = Random.Range(pos.x + tremorStrength, pos.x - tremorStrength);
            float y = Random.Range(pos.y + tremorStrength, pos.y - tremorStrength);

            Vector2 newPos = new Vector2(x, y);
            myText.transform.position = newPos;
        }

        myText.text = symbols;

    }

    IEnumerator SymbolAppear()
    {
        while(true && tremorActive){
            foreach(char c in paragraphs[pIndex]){
                symbols += c;

                yield return new WaitForSeconds(textAnimSpeed);
            }
            tremorActive = false;
            symbolAppearCoroutine = null;
        }
    }

    private bool DialogContinueButton(){
        return Keyboard.current.spaceKey.isPressed || Mouse.current.leftButton.isPressed;
    }

}