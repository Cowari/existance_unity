using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class DialogueText : MonoBehaviour
{
    [Header("Настройки:")]
    [SerializeField] List<string> paragraphs = new List<string>();
    public float tremorStrength = 2f;
    public float textAnimSpeed = 0.07f;
    public TextMeshProUGUI myText;

    private Coroutine symbolAppearCoroutine;
    private StringBuilder symbolsBuilder = new StringBuilder();
    private bool tremorActive = true;
    private int pIndex = 0; // paragraph index
    private Vector3 initPos;

    private DialogState currentState = DialogState.Idle;
    private ITremorManager tremorManager;
    private IInputHandler inputHandler;

    private enum DialogState{
        Idle,
        Typing,
        Completed
    }

    void Start(){
        if(myText == null){
            Debug.LogError("TextMeshProUGUI не назначен!");
            return;
        }
        initPos = myText.transform.position;
        myText.text = string.Empty;
        tremorManager = new TremorManager(myText, tremorStrength, initPos);
        inputHandler = new InputHandler();

        //symbolAppearCoroutine = StartCoroutine(SymbolAppear());
        if(paragraphs.Count > 0){
            StartNextParagraph();
        }
    }

    void Update(){
        if(inputHandler.CheckDialogContinueButton()) // Если кнопка для продолжения нажата.
        {
            HandleInput();
        }

        tremorManager.UpdateTremor(tremorActive);
        myText.text = symbolsBuilder.ToString();
    }

    private void HandleInput(){
        switch(currentState){
            case DialogState.Typing:
                SkipTyping();
                break;
            case DialogState.Completed:
                pIndex++;
                StartNextParagraph();
                break;
        }
    }

    private void StartNextParagraph(){
        if(pIndex >= paragraphs.Count){
            enabled = false;
            return;
        }
        tremorActive = true;
        symbolsBuilder.Clear();
        currentState = DialogState.Typing;
        symbolAppearCoroutine = StartCoroutine(SymbolAppear());
    }

    private void SkipTyping(){
        if(symbolAppearCoroutine != null){
            StopCoroutine(symbolAppearCoroutine);
            symbolAppearCoroutine = null;
            symbolsBuilder.Clear();
            symbolsBuilder.Append(paragraphs[pIndex]);
            tremorActive = false;
            currentState = DialogState.Completed;
        }
    }

    IEnumerator SymbolAppear(){
        while(tremorActive && pIndex < paragraphs.Count)
        {
            foreach(char c in paragraphs[pIndex]){
                symbolsBuilder.Append(c);
                yield return new WaitForSeconds(textAnimSpeed);
            }
            tremorActive = false;
            currentState = DialogState.Completed;
            symbolAppearCoroutine = null;
        }
    }
}