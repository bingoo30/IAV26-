using UnityEngine;

public class Shoe : MonoBehaviour
{
    private ShoeData data;

    private Renderer rend;
    private Rigidbody rb;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }

    public void ApplyData(ShoeData data)
    {
        this.data = data;
        ApplyData();
    }
    void ApplyData()
    {
        if (data == null || rb == null || rend == null) return;

        // color
        rend.material.color = data.color;

        // peso físico
        if (rb != null)
        {
            rb.mass = data.weight;
        }
    }

    public float GetWeight()
    {
        return data.weight;
    }

    public int GetValue()
    {
        return data.value;
    }
}