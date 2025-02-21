using UnityEngine.InputSystem;

public interface IInputHandler{
    bool CheckDialogContinueButton();
}

public class InputHandler : IInputHandler
{
    public bool CheckDialogContinueButton(){
        if(Keyboard.current == null || Mouse.current == null){ // если клавиатура или мышь не существуют, то возвращаем false
            return false;
        }

        return Keyboard.current.spaceKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame;
    }
}
