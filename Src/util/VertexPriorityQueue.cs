using System;
using System.Collections.Generic;
using System.Linq;
using Src.graph;

namespace Src.util
{
    public class VertexPriorityQueue
    {
        private readonly SortedDictionary<float, Queue<Vertex>> _priorityQueue;

        public VertexPriorityQueue()
        {
            _priorityQueue = new SortedDictionary<float, Queue<Vertex>>();
        }

        public bool IsEmpty => _priorityQueue.Count == 0;

        public int Count => _priorityQueue.Count;

        public void Enqueue(Vertex vertex, float priority)
        {
            if (!_priorityQueue.TryGetValue(priority, out Queue<Vertex> vertexQueue))
            {
                vertexQueue = new Queue<Vertex>();
                _priorityQueue.Add(priority, vertexQueue);
            }

            vertexQueue.Enqueue(vertex);
        }

        public Vertex Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Priority queue is empty");
            }

            float priority = _priorityQueue.Keys.First();
            Queue<Vertex> vertexQueue = _priorityQueue[priority];
            Vertex vertex = vertexQueue.Dequeue();

            if (vertexQueue.Count == 0)
            {
                _priorityQueue.Remove(priority);
            }

            return vertex;
        }

        public bool Contains(Vertex vertex)
        {
            return _priorityQueue.Values.Any(vertexQueue => vertexQueue.Contains(vertex));
        }

        public void Clear()
        {
            _priorityQueue.Clear();
        }
    }
}
