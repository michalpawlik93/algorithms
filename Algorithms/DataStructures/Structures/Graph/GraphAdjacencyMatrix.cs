using System;
using System.Linq;

namespace DataStructures.Structures.Graph;

public record Vertex(int Id);

public record struct MatrixIndex(int Vertical, int Horizontal);

public class GraphAdjacencyMatrix
{
    private const int DefaultCapacity = 20;
    private readonly int?[][] Matrix;
    private int MatrixSize = 0;

    public GraphAdjacencyMatrix()
    {
        Matrix = new int?[DefaultCapacity][].Select(_ => new int?[DefaultCapacity]).ToArray();
    }

    public void PrintMatrix()
    {
        for (int i = 0; i < Matrix.Length; i++)
        {
            for (int j = 0; j < Matrix[i].Length; j++)
            {
                Console.Write($"{Matrix[i][j]} ");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Add Vertex as a source for vertices
    /// </summary>
    /// <param name="vertex"></param>
    /// <param name="destinationVertices"></param>
    /// <exception cref="MatrixException"></exception>
    public void Add(Vertex vertex, Vertex[] destinationVertices)
    {
        GuardAdd(vertex, destinationVertices);
        var diagonalIndex = GetDiagonalIndex(vertex);
        if (diagonalIndex.HasValue)
        {
            throw new MatrixException("Vertex already exists");
        }
        var newMatrixSize = MatrixSize + 1;
        CheckOverflow(newMatrixSize);
        Matrix[newMatrixSize][newMatrixSize] = vertex.Id;
        UpdateVertexIndices(newMatrixSize, destinationVertices);
        MatrixSize = newMatrixSize;
    }

    private void CheckOverflow(int size)
    {
        if (size >= DefaultCapacity)
        {
            throw new MatrixException("Matrix overflow");
        }
    }

    private void GuardAdd(Vertex vertex, Vertex[] destinationVertices)
    {
        if (vertex.Id <= 0)
        {
            throw new MatrixException("Vertex restricted value");
        }
        if (Array.Exists(destinationVertices, x => x.Id == vertex.Id))
        {
            throw new MatrixException(
                "Vertices must have a value and can not contain source vertex"
            );
        }
    }

    private MatrixIndex? GetDiagonalIndex(Vertex vertex)
    {
        for (int y = 0; y < MatrixSize; y++)
        {
            if (y == vertex.Id)
            {
                return new(y, y);
            }
        }
        return default;
    }

    private void UpdateVertexIndices(int verticalIndex, Vertex[] destinationVertices)
    {
        for (int diagonal = 0; diagonal < MatrixSize; diagonal++)
        {
            var destVertex = Array.Find(
                destinationVertices,
                x => x.Id == Matrix[diagonal][diagonal]
            );
            if (Matrix[diagonal][diagonal].HasValue && destVertex != null)
            {
                Matrix[verticalIndex][diagonal] = destVertex.Id;
            }
        }
    }
}

public class MatrixException : Exception
{
    public MatrixException() { }

    public MatrixException(string message) : base(message) { }

    public MatrixException(string message, Exception inner) : base(message, inner) { }
}
