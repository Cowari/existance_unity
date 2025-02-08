using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DialogueText : MonoBehaviour
{
    [Header("Настройки:")]
    [SerializeField] List<string> paragraphs = new List<string>();
    [SerializeField] float tremorStrength = 2f;
    [SerializeField] float textAnimSpeed = 0.07f;

    public TextMeshProUGUI myText;

    private Coroutine symbolAppearCoroutine;
    private bool tremorActive = true;
    private int pIndex = 0; // paragraph index
    private string symbols;
    private Vector3 pos;

    private ITremorManager tremorManager;
    private IInputHandler inputHandler;

    void Start(){
        pos = myText.transform.position;

        tremorManager = new TremorManager(myText, tremorStrength, pos);
        inputHandler = new InputHandler();

        symbolAppearCoroutine = StartCoroutine(SymbolAppear());
    }

    void Update(){
        if(inputHandler.CheckDialogContinueButton()) // Если кнопка для продолжения нажата.
        {
            tremorActive = true;
            if(symbolAppearCoroutine == null){
                symbols = null;
                pIndex++;
                symbolAppearCoroutine = StartCoroutine(SymbolAppear());
            }
        }

        tremorManager.UpdateTremor(tremorActive);

        myText.text = symbols;
    }

    IEnumerator SymbolAppear(){
        while(tremorActive)
        {
            foreach(char c in paragraphs[pIndex]){
                symbols += c;
                yield return new WaitForSeconds(textAnimSpeed);
            }
            tremorActive = false;
            symbolAppearCoroutine = null;
        }
    }
}