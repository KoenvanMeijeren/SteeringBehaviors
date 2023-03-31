using System;
using NUnit.Framework;
using Src.graph;
using Src.util;

namespace Tests.util
{
    public class VertexPriorityQueueTests
    {
        [Test]
        public void Create_01_Ok()
        {
            // Arrange
            const int ExpectedCount = 0;
            const bool ExpectedIsEmpty = true;

            // Act
            VertexPriorityQueue queue = new VertexPriorityQueue();

            // Assert
            Assert.That(queue.IsEmpty, Is.EqualTo(ExpectedIsEmpty));
            Assert.That(queue.Count, Is.EqualTo(ExpectedCount));
        }

        [Test]
        public void Enqueue_01_SingleOk()
        {
            // Mocked values
            const int Priority = 0;

            // Arrange
            const int ExpectedCount = 1;
            const bool ExpectedIsEmpty = false;
            Vertex vertex = new Vertex(3, 4);

            // Act
            VertexPriorityQueue queue = new VertexPriorityQueue();
            queue.Enqueue(vertex, Priority);

            // Assert
            Assert.That(queue.IsEmpty, Is.EqualTo(ExpectedIsEmpty));
            Assert.That(queue.Count, Is.EqualTo(ExpectedCount));
        }

        [Test]
        public void Enqueue_02_MultipleOk()
        {
            // Arrange
            const int ExpectedCount = 3;
            const bool ExpectedIsEmpty = false;
            Vertex vertex1 = new Vertex(3, 4);
            Vertex vertex2 = new Vertex(4, 4);
            Vertex vertex3 = new Vertex(5, 4);

            // Act
            VertexPriorityQueue queue = new VertexPriorityQueue();
            queue.Enqueue(vertex1, 0);
            queue.Enqueue(vertex2, 1);
            queue.Enqueue(vertex3, 2);

            // Assert
            Assert.That(queue.IsEmpty, Is.EqualTo(ExpectedIsEmpty));
            Assert.That(queue.Count, Is.EqualTo(ExpectedCount));
        }

        [Test]
        public void Dequeue_01_SingleOk()
        {
            // Mocked values
            const int Priority = 0;

            // Arrange
            const int ExpectedCount = 0;
            const bool ExpectedIsEmpty = true;
            Vertex vertex = new Vertex(3, 4);

            // Act
            VertexPriorityQueue queue = new VertexPriorityQueue();
            queue.Enqueue(vertex, Priority);
            Vertex result = queue.Dequeue();

            // Assert
            Assert.That(result, Is.EqualTo(vertex));
            Assert.That(queue.IsEmpty, Is.EqualTo(ExpectedIsEmpty));
            Assert.That(queue.Count, Is.EqualTo(ExpectedCount));
        }

        [Test]
        public void Dequeue_02_OneOfMultipleOk()
        {
            // Arrange
            const int ExpectedCount = 2;
            const bool ExpectedIsEmpty = false;
            Vertex vertex1 = new Vertex(3, 4);
            Vertex vertex2 = new Vertex(4, 4);
            Vertex vertex3 = new Vertex(5, 4);

            // Act
            VertexPriorityQueue queue = new VertexPriorityQueue();
            queue.Enqueue(vertex1, 0);
            queue.Enqueue(vertex2, 1);
            queue.Enqueue(vertex3, 2);
            Vertex result = queue.Dequeue();

            // Assert
            Assert.That(result, Is.EqualTo(vertex1));
            Assert.That(queue.IsEmpty, Is.EqualTo(ExpectedIsEmpty));
            Assert.That(queue.Count, Is.EqualTo(ExpectedCount));
        }

        [Test]
        public void Dequeue_03_AllOfMultipleOk()
        {
            // Arrange
            const int ExpectedCount = 0;
            const bool ExpectedIsEmpty = true;
            Vertex vertex1 = new Vertex(3, 4);
            Vertex vertex2 = new Vertex(4, 4);
            Vertex vertex3 = new Vertex(5, 4);

            // Act
            VertexPriorityQueue queue = new VertexPriorityQueue();
            queue.Enqueue(vertex1, 0);
            queue.Enqueue(vertex2, 1);
            queue.Enqueue(vertex3, 2);
            Vertex dequeuedVertex1 = queue.Dequeue();
            Vertex dequeuedVertex2 = queue.Dequeue();
            Vertex dequeuedVertex3 = queue.Dequeue();

            // Assert
            Assert.That(dequeuedVertex1, Is.EqualTo(vertex1));
            Assert.That(dequeuedVertex2, Is.EqualTo(vertex2));
            Assert.That(dequeuedVertex3, Is.EqualTo(vertex3));
            Assert.That(queue.IsEmpty, Is.EqualTo(ExpectedIsEmpty));
            Assert.That(queue.Count, Is.EqualTo(ExpectedCount));
        }

        [Test]
        public void Dequeue_04_ThrowsOnEmptyQueue()
        {
            // Act & assert
            VertexPriorityQueue queue = new VertexPriorityQueue();
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public void Contains_01_Ok()
        {
            // Arrange
            Vertex vertex1 = new Vertex(3, 4);
            Vertex vertex2 = new Vertex(4, 4);
            Vertex vertex3 = new Vertex(5, 4);

            // Act
            VertexPriorityQueue queue = new VertexPriorityQueue();
            queue.Enqueue(vertex1, 0);
            queue.Enqueue(vertex2, 1);
            queue.Enqueue(vertex3, 2);

            // Assert
            Assert.That(queue.Contains(vertex1), Is.True);
            Assert.That(queue.Contains(vertex2), Is.True);
            Assert.That(queue.Contains(vertex3), Is.True);
        }

        [Test]
        public void Contains_02_NotOk()
        {
            // Arrange
            Vertex vertex1 = new Vertex(3, 4);
            Vertex vertex2 = new Vertex(4, 4);
            Vertex vertex3 = new Vertex(5, 4);
            Vertex vertex4 = new Vertex(5, 4);

            // Act
            VertexPriorityQueue queue = new VertexPriorityQueue();
            queue.Enqueue(vertex1, 0);
            queue.Enqueue(vertex2, 1);
            queue.Enqueue(vertex3, 2);

            // Assert
            Assert.That(queue.Contains(vertex4), Is.False);
        }

        [Test]
        public void Clear_01_AllOfMultipleOk()
        {
            // Arrange
            const int ExpectedCount = 0;
            const bool ExpectedIsEmpty = true;
            Vertex vertex1 = new Vertex(3, 4);
            Vertex vertex2 = new Vertex(4, 4);
            Vertex vertex3 = new Vertex(5, 4);

            // Act
            VertexPriorityQueue queue = new VertexPriorityQueue();
            queue.Enqueue(vertex1, 0);
            queue.Enqueue(vertex2, 1);
            queue.Enqueue(vertex3, 2);
            queue.Clear();

            // Assert
            Assert.That(queue.IsEmpty, Is.EqualTo(ExpectedIsEmpty));
            Assert.That(queue.Count, Is.EqualTo(ExpectedCount));
        }
    }
}
