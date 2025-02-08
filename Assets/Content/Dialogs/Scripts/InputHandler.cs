using UnityEngine.InputSystem;

public interface IInputHandler{
    bool CheckDialogContinueButton();
}

public class InputHandler : IInputHandler
{
    public bool CheckDialogContinueButton(){
        return Keyboard.current.spaceKey.isPressed || Mouse.current.leftButton.isPressed;
    }
}
