using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Astar
{


    /// <summary>
    /// TODO: Implement this function so that it returns a list of Vector2Int positions which describes a path
    /// Note that you will probably need to add some helper functions
    /// from the startPos to the endPos
    /// </summary>
    /// <param name="startPos"></param>
    /// <param name="endPos"></param>
    /// <param name="grid"></param>
    /// <returns></returns>
    public List<Vector2Int> FindPathToTarget(Vector2Int startPos, Vector2Int endPos, Cell[,] grid)
    {
        List<Node> closedList = new List<Node>();
        List<Node> openList = new List<Node>();

        Node startNode = new Node(startPos, null, 0, 0);
        Node targetNode = new Node(endPos, null, 0, 0);
        openList.Add(startNode);




        while (openList.Count != 0) //a wild while loop replaced by an if for debug
        {
            Node currentNode = openList[0]; //First node when we enter the loop

            for (int i = 1; i < openList.Count; i++) 
            {
                if (openList[i].FScore <= currentNode.FScore) 
                {
                    currentNode = openList[i]; //Node with lowest f score
                }
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            if (currentNode.position == endPos)
            {
                targetNode = currentNode; //set this node as the end node, break the loop and retrace the path back from this node.
                break;
            }

            foreach (Cell neighbour in GetNeighbours(grid[currentNode.position.x, currentNode.position.y], grid))
            {
                Node _neighbourNode = new Node(neighbour.gridPosition, currentNode, (int)currentNode.GScore + 1, ManhattanDistance(neighbour.gridPosition, endPos));

                if (closedList.Any(n => n.position == neighbour.gridPosition)) //Note to self: List<T>.Contains doesn't work here :)
                {
                    continue;
                }

                int _moveCost = (int)currentNode.GScore + ManhattanDistance(currentNode.position, _neighbourNode.position);
                if (_moveCost < _neighbourNode.GScore || !openList.Any(n => n.position == neighbour.gridPosition))
                {
                    _neighbourNode.GScore = _moveCost;
                    _neighbourNode.HScore = ManhattanDistance(neighbour.gridPosition, endPos);

                    if (!openList.Contains(_neighbourNode))
                    {
                        openList.Add(_neighbourNode);
                    }
                }
            }
        }

        return RetraceNodes(startNode, targetNode);
    }


    List<Vector2Int> RetraceNodes(Node startNode, Node endNode)
    {
        List<Vector2Int> pathPostions = new List<Vector2Int>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            pathPostions.Add(currentNode.position);
            currentNode = currentNode.parent;
        }

        pathPostions.Reverse();

        return pathPostions;
    }


    private List<Cell> GetNeighbours(Cell _cell, Cell[,] _grid)
    {
        List<Cell> result = new List<Cell>();

        //[-1, 1] | [0, 1] | [1, 1]
        //[-1, 0] | [0, 0] | [1, 0]
        //[-1, -1]| [0, -1]| [1, -1]

        int _startX = -1, _endX = 1, _startY = -1, _endY = 1;

        if (_cell.HasWall(Wall.UP)) { _endY = 0; }
        if (_cell.HasWall(Wall.DOWN)) { _startY = 0; }
        if (_cell.HasWall(Wall.LEFT)) { _startX = 0; }
        if (_cell.HasWall(Wall.RIGHT)) { _endX = 0; }


        for (int x = _startX; x <= _endX; x++)
        {
            for (int y = _startY; y <= _endY; y++)
            {
                int cellX = _cell.gridPosition.x + x;
                int cellY = _cell.gridPosition.y + y;
                if (cellX < 0 || cellX >= _grid.GetLength(0) || cellY < 0 || cellY >= _grid.GetLength(1) || Mathf.Abs(x) == Mathf.Abs(y))
                {
                    continue;
                }
                Cell canditateCell = _grid[cellX, cellY];

                result.Add(canditateCell);
            }
        }


        //TODO: Return nodelist
        return result;
    }

    int ManhattanDistance(Vector2Int _startPos, Vector2Int _endPos) //Also known as the H(euristic)
    {
        int result = Mathf.Abs(_startPos.x - _endPos.x) + Mathf.Abs(_startPos.y - _endPos.y);

        return result;
    }


    /// <summary>
    /// This is the Node class you can use this class to store calculated FScores for the cells of the grid, you can leave this as it is
    /// </summary>
    public class Node
    {
        public Vector2Int position; //Position on the grid
        public Node parent; //Parent Node of this node

        public float FScore
        { //GScore + HScore
            get { return GScore + HScore; }
        }
        public float GScore; //Current Travelled Distance
        public float HScore; //Distance estimated based on Heuristic

        public Node() { }
        public Node(Vector2Int position, Node parent, int GScore, int HScore)
        {
            this.position = position;
            this.parent = parent;
            this.GScore = GScore;
            this.HScore = HScore;
        }
    }
}
