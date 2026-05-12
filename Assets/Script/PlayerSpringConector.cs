using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpringConnector : MonoBehaviour
{
    bool carried = false;

    private PlayerMovementController movement;

    private Shoe currentShoe;
    private Rigidbody currentRb;

    private PlayerControls contr;

    void Start()
    {
        contr = GetComponent<PlayerControls>();
        movement = GetComponent<PlayerMovementController>();
    }
    private void Update()
    {
        if (contr.Drop)
        {
            Drop();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (carried)
            return;

        Shoe shoe = hit.gameObject.GetComponent<Shoe>();

        if (shoe != null)
        {
            Rigidbody rb = hit.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;

                shoe.transform.SetParent(transform);
                shoe.transform.localPosition = new Vector3(0, 2.5f, 0);

                movement.AddWeight(shoe.GetWeight());

                currentShoe = shoe;
                currentRb = rb;

                carried = true;
            }
        }
    }

    private Shoe ReleaseShoe(bool throwForward)
    {
        if (!carried)
            return null;

        Shoe shoe = currentShoe;

        // restaurar física
        currentRb.isKinematic = false;
        currentRb.useGravity = true;

        // soltar del player
        currentShoe.transform.SetParent(null);

        // opcional: empuje
        if (throwForward)
        {
            currentRb.AddForce(transform.forward * 2f, ForceMode.Impulse);
        }

        // quitar peso
        movement.RemoveWeight(currentShoe.GetWeight());

        // reset estado
        currentShoe = null;
        currentRb = null;
        carried = false;

        return shoe;
    }
    public void Drop()
    {
        ReleaseShoe(true);
    }
    public Shoe Deliver()
    {
        return ReleaseShoe(false);
    }
}