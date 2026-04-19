using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CustomDoubleLinkedList snapshotSystem = new();
    public Player player;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        if (player != null)
            SaveTurn();
    }

    public void EndTurn()
    {

        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        foreach (var e in enemies)
        {
            e.MoveTowards(player.transform.position, 1f);
        }

        SaveTurn();
    }

    public void SaveTurn()
    {
        snapshotSystem.SaveTurn();
        Debug.Log("Turno guardado: " + snapshotSystem.Count);
    }

    public void LoadTurn()
    {
        snapshotSystem.LoadTurn(player);
    }

    public void NextTurn()
    {
        snapshotSystem.Next();
        LoadTurn();
    }

    public void PrevTurn()
    {
        snapshotSystem.Prev();
        LoadTurn();
    }

    public float moveDistance = 1f;

    public void MoveForwardZ()
    {
        player.transform.position += new Vector3(0, 0, moveDistance);
    }

    public void MoveBackZ()
    {
        player.transform.position += new Vector3(0, 0, -moveDistance);
    }

    public void MoveRightX()
    {
        player.transform.position += new Vector3(moveDistance, 0, 0);
    }

    public void MoveLeftX()
    {
        player.transform.position += new Vector3(-moveDistance, 0, 0);
    }
}