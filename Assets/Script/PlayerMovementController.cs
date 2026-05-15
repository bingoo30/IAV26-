using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float baseSpeed = 5.0f;
    [SerializeField] private float sprintMultiplier = 2.0f;

    [Header("Gravity")]
    [SerializeField] private float gravity = -9.81f;

    [Header("Weight")]
    [SerializeField] private float maxWeight = 30.0f;

    private float currentWeight = 0f;
    private float springWeightPenalty = 0f;

    private Vector3 velocity;

    private CharacterController controller;
    private IPlayerControls controls;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        controls = GetComponent<IPlayerControls>();
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        Vector2 moveInput = controls.Move;

        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
        float speed = GetSpeed();

        if (controls.Sprint)
            speed *= sprintMultiplier;

        // gravedad

        velocity.y += gravity * Time.deltaTime;

        Vector3 finalMove = move * speed + Vector3.up * velocity.y;

        controller.Move(finalMove * Time.deltaTime);
    }

    float GetSpeed()
    {
        float totalWeight = currentWeight + springWeightPenalty;

        float weightPercent = Mathf.Clamp01(totalWeight / maxWeight);

        float weightMultiplier = Mathf.Clamp(1f - weightPercent, 0.4f, 1f);

        return baseSpeed * weightMultiplier;
    }

    public void AddWeight(float weight)
    {
        currentWeight = Mathf.Clamp(currentWeight + weight, 0f, maxWeight);
    }

    public void RemoveWeight(float weight)
    {
        currentWeight = Mathf.Clamp(currentWeight - weight, 0f, maxWeight);
    }

    public void SetSpringPenalty(float penalty)
    {
        springWeightPenalty = penalty;
    }

    public void RemoveSpringPenalty()
    {
        springWeightPenalty = 0f;
    }
}