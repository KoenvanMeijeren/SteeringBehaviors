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
            Vertex vertexCurrent = _vertices[vertexX, vertexY];

            Vertex vertexNorth = getVertex(vertexX, vertexY-1);
            Vertex vertexNorthEast = getVertex(vertexX+1, vertexY-1);
            Vertex vertexEast = getVertex(vertexX+1, vertexY);
            Vertex vertexSouthEast = getVertex(vertexX+1, vertexY+1);
            Vertex vertexSouth = getVertex(vertexX, vertexY+1);
            Vertex vertexSouthWest = getVertex(vertexX-1, vertexY+1);
            Vertex vertexWest = getVertex(vertexX-1, vertexY);
            Vertex vertexNorthWest = getVertex(vertexX-1, vertexY-1);

            if (vertexNorth != null)
            {
                Edge edge = new Edge(vertexCurrent, vertexNorth);
                vertexCurrent.AddEdge(edge);
            }

            if (vertexNorthEast != null && vertexNorth != null && vertexEast != null)
            {
                Edge edge = new Edge(vertexCurrent, vertexNorthEast);
                vertexCurrent.AddEdge(edge);
            }

            if (vertexEast != null)
            {
                Edge edge = new Edge(vertexCurrent, vertexEast);
                vertexCurrent.AddEdge(edge);
            }

            if (vertexSouthEast != null && vertexSouth != null && vertexEast != null)
            {
                Edge edge = new Edge(vertexCurrent, vertexSouthEast);
                vertexCurrent.AddEdge(edge);
            }

            if (vertexSouth != null)
            {
                Edge edge = new Edge(vertexCurrent, vertexSouth);
                vertexCurrent.AddEdge(edge);
            }

            if (vertexSouthWest != null && vertexSouth != null && vertexWest != null)
            {
                Edge edge = new Edge(vertexCurrent, vertexSouthWest);
                vertexCurrent.AddEdge(edge);
            }

            if (vertexWest != null)
            {
                Edge edge = new Edge(vertexCurrent, vertexWest);
                vertexWest.AddEdge(edge);
            }

            if (vertexNorthWest != null && vertexNorth != null && vertexWest != null)
            {
                Edge edge = new Edge(vertexCurrent, vertexNorthWest);
                vertexCurrent.AddEdge(edge);
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
