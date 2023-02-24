using SteeringCS.util;
using SteeringCS.world;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.graph
{
    public class Graph
    {
        Vertex[,] _vertices;
        private readonly Color _renderColor = Color.IndianRed;

        public Graph(Vertex[,] vertices)
        {
            _vertices = vertices;
            initializeEdges();
        }

        private void initializeEdges()
        {
            for (int x = 0; x < _vertices.GetLength(0); x++)
            {
                for (int y = 0; y < _vertices.GetLength(1); y++)
                {
                    if (_vertices[x,y] != null)
                    {
                        createEdgesWithSurroundingVertices(x, y);
                    }
                }
            }
        }

        private void createEdgesWithSurroundingVertices(int vertexX, int vertexY)
        {
            Vertex VertexCurrent = _vertices[vertexX, vertexY];

            Vertex VertexNorth = getVertex(vertexX, vertexY-1);
            Vertex VertexNorthEast = getVertex(vertexX+1, vertexY-1);
            Vertex VertexEast = getVertex(vertexX+1, vertexY);
            Vertex VertexSouthEast = getVertex(vertexX+1, vertexY+1);
            Vertex VertexSouth = getVertex(vertexX, vertexY+1);
            Vertex VertexSouthWest = getVertex(vertexX-1, vertexY+1);
            Vertex VertexWest = getVertex(vertexX-1, vertexY);
            Vertex VertexNorthWest = getVertex(vertexX-1, vertexY-1);

            if (VertexNorth != null)
            {
                Edge edge = new Edge(VertexCurrent, VertexNorth);
                VertexCurrent.AddEdge(edge);
            }

            if (VertexNorthEast != null && VertexNorth != null && VertexEast != null)
            {
                Edge edge = new Edge(VertexCurrent, VertexNorthEast);
                VertexCurrent.AddEdge(edge);
            }

            if (VertexEast != null)
            {
                Edge edge = new Edge(VertexCurrent, VertexEast);
                VertexCurrent.AddEdge(edge);
            }

            if (VertexSouthEast != null && VertexSouth != null && VertexEast != null)
            {
                Edge edge = new Edge(VertexCurrent, VertexSouthEast);
                VertexCurrent.AddEdge(edge);
            }

            if (VertexSouth != null)
            {
                Edge edge = new Edge(VertexCurrent, VertexSouth);
                VertexCurrent.AddEdge(edge);
            }

            if (VertexSouthWest != null && VertexSouth != null && VertexWest != null)
            {
                Edge edge = new Edge(VertexCurrent, VertexSouthWest);
                VertexCurrent.AddEdge(edge);
            }

            if (VertexWest != null)
            {
                Edge edge = new Edge(VertexCurrent, VertexWest);
                VertexWest.AddEdge(edge);
            }

            if (VertexNorthWest != null && VertexNorth != null && VertexWest != null)
            {
                Edge edge = new Edge(VertexCurrent, VertexNorthWest);
                VertexCurrent.AddEdge(edge);
            }
        }

        private Vertex getVertex(int vertexX, int vertexY)
        {
            if (vertexX < 0 || vertexY < 0)
            {
                return null;
            }

            if (vertexX >= _vertices.GetLength(0) || vertexY >= _vertices.GetLength(1))
            {
                return null;
            }

            return _vertices[vertexX, vertexY]; ;
        }

        public void Render(Graphics graphic)
        {
            int vertexSize = 1;
            Pen penVertex = new Pen(_renderColor , 4);
            Pen penEdge = new Pen(_renderColor);
            Rectangle rectangle = new Rectangle(0,0, vertexSize, vertexSize);


            for (int x = 0; x < _vertices.GetLength(0); x++)
            {
                for (int y = 0; y < _vertices.GetLength(1); y++)
                {
                    if (_vertices[x,y] == null)
                    {
                        continue;
                    }

                    rectangle.X = _vertices[x, y].Position.X - (vertexSize/2);
                    rectangle.Y = _vertices[x, y].Position.Y - (vertexSize/2);
                    graphic.DrawEllipse(penVertex, rectangle);

                    foreach(Edge edge in _vertices[x, y].Edges)
                    {
                        graphic.DrawLine(penEdge, edge.OwnerVertex.Position.X, edge.OwnerVertex.Position.Y, edge.DestinationVertex.Position.X, edge.DestinationVertex.Position.Y);
                    }
                }
            }
        }
    }
}
