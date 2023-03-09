using Src.graph;
using System;
using System.Collections.Generic;
using System.Linq;

public class VertexPriorityQueue
{
    private SortedDictionary<float, Queue<Vertex>> priorityQueue;

    public VertexPriorityQueue()
    {
        priorityQueue = new SortedDictionary<float, Queue<Vertex>>();
    }

    public bool IsEmpty => priorityQueue.Count == 0;

    public int Count => priorityQueue.Count;

    public void Enqueue(Vertex vertex, float priority)
    {
        Queue<Vertex> vertexQueue;

        if (!priorityQueue.TryGetValue(priority, out vertexQueue))
        {
            vertexQueue = new Queue<Vertex>();
            priorityQueue.Add(priority, vertexQueue);
        }

        vertexQueue.Enqueue(vertex);
    }

    public Vertex Dequeue()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Priority queue is empty");
        }

        float priority = priorityQueue.Keys.First();
        Queue<Vertex> vertexQueue = priorityQueue[priority];
        Vertex vertex = vertexQueue.Dequeue();

        if (vertexQueue.Count == 0)
        {
            priorityQueue.Remove(priority);
        }

        return vertex;
    }

    public bool Contains(Vertex vertex)
    {
        foreach (Queue<Vertex> vertexQueue in priorityQueue.Values)
        {
            if (vertexQueue.Contains(vertex))
            {
                return true;
            }
        }

        return false;
    }

    public void Clear()
    {
        priorityQueue.Clear();
    }
}
