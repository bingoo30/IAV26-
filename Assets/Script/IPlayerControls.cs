using UnityEngine;

public interface IPlayerControls
{
    Vector2 Move { get; }
    bool Sprint { get; }
    bool Drop { get; }
}
