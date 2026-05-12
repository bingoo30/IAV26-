using UnityEngine;

public class Basement : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameManager.InputKeys inp;
    private int id = -1;

    // parser to control scheme (input, if we are spawning players, no bots)
    string parse(GameManager.InputKeys key)
    {
        string s = "";
        switch (key)
        {
            case GameManager.InputKeys.WASD:
                s = "WASD";
                break;
            case GameManager.InputKeys.ARROW:
                s = "Arrows";
                break;
        }
        return s;
    }
    private void Start()
    {
        id = GameManager.Instance.GetNextPlayerId();

        Vector3 spawnPos = transform.position + Vector3.up * 2f;

        Player p = GameManager.Instance.SpawnPlayerWithId(prefab, parse(inp), spawnPos);
        p.Id = id;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerDeriveredAShoe(other);
        AShoeJustEntered(other);
    }
    bool PlayerDeriveredAShoe(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player == null || player.Id != id)
            return false;

        PlayerSpringConnector sp = player.GetComponent<PlayerSpringConnector>();
        PlayerScore score = player.GetComponent<PlayerScore>();

        if (sp == null || score == null)
            return false;

        Shoe shoe = sp.Deliver();

        if (shoe != null)
        {
            score.AddScore(shoe.GetValue());
            // notify to less a shoe
            ShoePool.Instance.NotifyShoeDestroyed();
            Destroy(shoe.gameObject);
        }
        return true;
    }
    bool AShoeJustEntered(Collider other)
    {

        Shoe shoe = other.GetComponent<Shoe>();

        if (shoe != null)
        {
            //score.AddScore(shoe.GetValue());
            //// notify to less a shoe
            //ShoePool.Instance.NotifyShoeDestroyed();
            //Destroy(shoe.gameObject);
        }
        return true;
    }
}