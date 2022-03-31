using UnityEngine;

public interface IInput
{
    Vector2 MovementInputVector { get; }
    bool IsShooting { get; }
}