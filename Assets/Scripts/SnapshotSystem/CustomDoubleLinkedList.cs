using UnityEngine;

public class CustomDoubleLinkedList : DoubleLinkedList<SnapshotNode>
{
    public Node<SnapshotNode> Pivot;

    public void SaveTurn()
    {
        if (Pivot != null && Pivot != last)
        {
            RemoveFrom(Pivot);
        }

        SnapshotNode snapshot = new SnapshotNode(GameManager.instance.player, Count + 1);
        Add(snapshot);
        Pivot = last;
    }

    public void ResetPivot()
    {
        Pivot = last;
    }

    public void Prev()
    {
        if (Pivot == null || Pivot.Prev == null) return;
        Pivot = Pivot.Prev;
    }

    public void Next()
    {
        if (Pivot == null || Pivot.Next == null) return;
        Pivot = Pivot.Next;
    }

    public void LoadTurn(Player player)
    {
        if (Pivot == null) return;
        Debug.Log("Turno actual: " + Pivot.Value.Turn);
        player.transform.position = Pivot.Value.playerPosition;
        player.transform.eulerAngles = Pivot.Value.playerRotation;
        player.str = Pivot.Value.str;
        player.dtx = Pivot.Value.dtx;
        player.spd = Pivot.Value.spd;
    }
}
