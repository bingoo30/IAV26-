using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : PlayerInputBase, IPlayerControls
{
    public void OnMove(InputAction.CallbackContext ctx)
    {
        move = ctx.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext ctx)
    {
        sprint = ctx.ReadValue<float>() > 0.5f;
    }

    public void OnDrop(InputAction.CallbackContext ctx)
    {
        drop = ctx.ReadValue<float>() > 0.5f;
    }
}