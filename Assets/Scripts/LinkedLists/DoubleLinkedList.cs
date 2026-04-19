using System;
using UnityEngine;

public class DoubleLinkedList<T>
{
    public Node<T> head = null;
    public Node<T> last = null;
    public int Count;

    public virtual void Add(T value)
    {
        Node<T> newNode = new(value);

        if (head == null)
        {
            head = newNode;
            last = newNode;
        }
        else
        {
            last.SetNext(newNode);
            newNode.SetPrev(last);
            last = newNode;
        }
        Count++;
    }

    public virtual void RemoveLast()
    {
        if (Count == 0)
        {
            Debug.Log("La lista esta vacia");
            return;
        }
        else if (Count == 1)
        {
            head = null;
            last = null;
            Count--;
        }
        else
        {
            Node<T> anterior = last.Prev;
            last.SetPrev(null);
            anterior.SetNext(null);
            last = anterior;
            Count--;
        }
    }

    public virtual void RemoveFirst()
    {
        if (Count <= 1)
        {
            head = null;
            last = null;
            Count--;
            return;
        }

        Node<T> siguiente = head.Next;
        head.SetNext(null);
        head = siguiente;
        Count--;
    }
    public virtual void RemoveFrom(Node<T> position)
    {
        if (position == null) return;
        if (position.Next == null) return;

        Node<T> current = position.Next;
        position.SetNext(null);

        while (current != null)
        {
            Node<T> next = current.Next;
            current.SetPrev(null);
            current.SetNext(null);
            current = next;
            Count--;
        }

        last = position;
    }

    public virtual void TraverseInOrder(Action<Node<T>> action)
    {
        Node<T> current = head;
        while (current != null)
        {
            action(current);
            current = current.Next;
        }
    }

    public virtual void TraverseInReverse(Action<Node<T>> action)
    {
        Node<T> current = last;
        while (current != null)
        {
            action(current);
            current = current.Prev;
        }
    }
}
