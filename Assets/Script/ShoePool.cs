using UnityEngine;
using System.Collections;

public class ShoePool : MonoBehaviour
{
    public static ShoePool Instance { get; private set; }
    public enum ShoeType
    {
        Light,
        Normal,
        Heavy,
        NUM
    }

    [Header("Shoot Prefabs")]
    [SerializeField]
    private GameObject shoePrefab;
    [SerializeField]
    private ShoeData[] shoeDatas;

    [Header("Spawn Area")]
    private Vector3 center;
    [SerializeField]
    private float spawnRadius = 50f;

    [Header("Spawn Probabilities")]
    [SerializeField] float lightChance = 0.50f;
    [SerializeField] float normalChance = 0.35f;
    [SerializeField] float heavyChance = 0.15f;

    [Header("Auto Respawn")]
    [SerializeField] private int minShoesAlive = 1;
    [SerializeField] private int respawnAmount = 5;
    [SerializeField] private float respawnDelay = 3f;
    [SerializeField] private float timeBetweenSpawns = 0.2f;

    private int activeShoes = 0;
    private bool respawning = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        center = transform.position;
    }
    private void Update()
    {
        if (activeShoes <= minShoesAlive && !respawning)
        {
            StartCoroutine(RespawnCoroutine());
        }
    }

    IEnumerator RespawnCoroutine()
    {
        respawning = true;

        yield return new WaitForSeconds(respawnDelay);

        yield return StartCoroutine(SpawnShoesCoroutine(respawnAmount));

        respawning = false;
    }

    IEnumerator SpawnShoesCoroutine(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            ShoeType type = GetRandomShoeType();
            Vector3 pos = GetRandomPointInCircle(center, spawnRadius);

            GameObject s = Instantiate(shoePrefab, pos, Quaternion.identity);

            s.GetComponent<Shoe>().ApplyData(shoeDatas[(int)type]);

            activeShoes++;

            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public void NotifyShoeDestroyed()
    {
        activeShoes--;

        if (activeShoes < 0) activeShoes = 0;
    }

    ShoeType GetRandomShoeType()
    {
        float r = Random.value;

        if (r < lightChance)
            return ShoeType.Light;

        if (r < lightChance + normalChance)
            return ShoeType.Normal;

        return ShoeType.Heavy;
    }
    Vector3 GetRandomPointInCircle(Vector3 center, float radius)
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);

        // uniform distribution
        float distance = radius * Mathf.Sqrt(Random.value);

        float x = Mathf.Cos(angle) * distance;
        float z = Mathf.Sin(angle) * distance;

        return center + new Vector3(x, 0f, z);
    }
}