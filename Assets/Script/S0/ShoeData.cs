using UnityEngine;

[CreateAssetMenu(fileName = "NewShoeData", menuName = "Game/Shoe Data")]
public class ShoeData : ScriptableObject
{
    [Header("Stats")]
    public float weight = 5f;
    public int value = 10;

    [Header("Visuals")]
    public Color color = Color.white;
}
