using System;
using UnityEngine;

public class CircularDoubleLinkedList<T>
{
    public Node<T> head = null;
    public Node<T> tail = null;
    public int Count;

    public virtual void Add(T value)
    {
        Node<T> newNode = new(value);

        if (head == null)
        {
            head = newNode;
            tail = newNode;

            head.SetPrev(tail);
            tail.SetNext(head);

        }
        else if (head != null)
        {
            tail.SetNext(newNode);
            newNode.SetPrev(tail);
            tail = newNode;

            head.SetPrev(tail);
            tail.SetNext(head);
        }
        Count++;
    }



    public void RemoveLast()
    {


        if (Count == 0)
        {
            Debug.Log("La lista esta vacia");
            return;
        }
        else if (Count == 1)
        {
            head = null;
            tail = null;
            Count--;
        }
        else if (Count >= 2)
        {
            Node<T> Evaluator = tail.Prev;
            tail.SetPrev(null);
            Evaluator.SetNext(null);
            tail = Evaluator;

            head.SetPrev(tail);
            tail.SetNext(head);

            Count--;
        }


    }

    public void RemoveFirst()
    {

        if (Count <= 1)
        {
            head = null;
            tail = null;
            Count--;
            return;
        }

        Node<T> Evaluator = head.Next;
        head.SetNext(null);
        head.SetPrev(null);
        head = Evaluator;

        head.SetPrev(tail);
        tail.SetNext(head);

        Count--;


    }

    public void TraverseInOrder(Action<Node<T>> action)
    {
        Node<T> Evaluator = head;
        int count = 0;
        while (count < Count)
        {

            action(Evaluator);

            Evaluator = Evaluator.Next;
            count++;
        }
    }
    public void TraverseInReverse(Action<Node<T>> action)
    {
        Node<T> Evaluator = tail;
        int count = 0;
        while (count < Count)
        {

            action(Evaluator);

            Evaluator = Evaluator.Prev;
            count++;
        }
    }


}
