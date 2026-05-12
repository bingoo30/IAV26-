using UnityEngine;

public class PlayerInputBase : MonoBehaviour
{
    protected Vector2 move;
    protected bool sprint;
    protected bool drop;

    public Vector2 Move => move;
    public bool Sprint => sprint;
    public bool Drop => drop;
}