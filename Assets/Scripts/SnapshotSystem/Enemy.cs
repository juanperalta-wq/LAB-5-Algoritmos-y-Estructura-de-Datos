using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public int attack = 2;

    public void MoveTowards(Vector3 target, float distance)
    {
        Vector3 dir = (target - transform.position);
        dir.y = 0;
        if (dir.magnitude < 0.1f) return;
        transform.position += dir.normalized * distance;
    }
}
