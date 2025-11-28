using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class Green
    {
        public int[] Task1(int[,] matrix)
        {
            int[] answer = null;

            // code here
            answer = new int[matrix.GetLength(0)];
            int position = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int smallestValue = int.MaxValue;
                int columnWithSmallest = 0;

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] < smallestValue)
                    {
                        smallestValue = matrix[row, col];
                        columnWithSmallest = col;
                    }
                }
                answer[position] = columnWithSmallest;
                position++;
            }
            // end

            return answer;
        }
        public void Task2(int[,] matrix)
        {

            // code here
            for (int rowIdx = 0; rowIdx < matrix.GetLength(0); rowIdx++)
            {
                int maximumValue = Int32.MinValue;
                int maximumPosition = 0;

                for (int colIdx = 0; colIdx < matrix.GetLength(1); colIdx++)
                {
                    if (matrix[rowIdx, colIdx] > maximumValue)
                    {
                        maximumValue = matrix[rowIdx, colIdx];
                        maximumPosition = colIdx;
                    }
                }

                for (int colIdx = 0; colIdx < maximumPosition; colIdx++)
                {
                    if (matrix[rowIdx, colIdx] < 0)
                    {
                        matrix[rowIdx, colIdx] = (int)Math.Floor((double)matrix[rowIdx, colIdx] / maximumValue);
                    }
                }
            }
            // end

        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            if ((matrix.GetLength(0) != matrix.GetLength(1)) || (k >= matrix.GetLength(1)))
                return;

            int diagonalMax = int.MinValue;
            int columnWithMax = 0;

            for (int diagonalPos = 0; diagonalPos < matrix.GetLength(0); diagonalPos++)
            {
                if (matrix[diagonalPos, diagonalPos] > diagonalMax)
                {
                    diagonalMax = matrix[diagonalPos, diagonalPos];
                    columnWithMax = diagonalPos;
                }
            }

            if (columnWithMax != k)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    (matrix[row, columnWithMax], matrix[row, k]) = (matrix[row, k], matrix[row, columnWithMax]);
                }
            }
            // end

        }
        public void Task4(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;

            int diagonalMaximum = int.MinValue;
            int diagonalPosition = 0;

            for (int diagonalIndex = 0; diagonalIndex < matrix.GetLength(0); diagonalIndex++)
            {
                if (matrix[diagonalIndex, diagonalIndex] > diagonalMaximum)
                {
                    diagonalMaximum = matrix[diagonalIndex, diagonalIndex];
                    diagonalPosition = diagonalIndex;
                }
            }

            for (int index = 0; index < matrix.GetLength(0); index++)
            {
                (matrix[index, diagonalPosition], matrix[diagonalPosition, index]) =
                (matrix[diagonalPosition, index], matrix[index, diagonalPosition]);
            }
            // end

        }
        public int[,] Task5(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            answer = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            int highestSum = int.MinValue;
            int rowToRemove = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int currentRowSum = 0;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                        currentRowSum += matrix[row, col];
                }

                if (currentRowSum > highestSum)
                {
                    highestSum = currentRowSum;
                    rowToRemove = row;
                }
            }

            int newRowIndex = 0;
            for (int originalRow = 0; originalRow < matrix.GetLength(0); originalRow++)
            {
                if (originalRow == rowToRemove)
                    continue;

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    answer[newRowIndex, col] = matrix[originalRow, col];
                }
                newRowIndex++;
            }
            // end

            return answer;
        }
        public void Task6(int[,] matrix)
        {

            // code here
            int rowWithMaxNegatives = 0;
            int rowWithMinNegatives = 0;
            int maxNegativeCount = Int32.MinValue;
            int minNegativeCount = Int32.MaxValue;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int negativeElementsCount = 0;
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (matrix[row, column] < 0)
                    {
                        negativeElementsCount++;
                    }
                }

                if (negativeElementsCount > maxNegativeCount)
                {
                    maxNegativeCount = negativeElementsCount;
                    rowWithMaxNegatives = row;
                }

                if (negativeElementsCount < minNegativeCount)
                {
                    minNegativeCount = negativeElementsCount;
                    rowWithMinNegatives = row;
                }
            }

            if (rowWithMaxNegatives != rowWithMinNegatives)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    (matrix[rowWithMaxNegatives, column], matrix[rowWithMinNegatives, column]) =
                    (matrix[rowWithMinNegatives, column], matrix[rowWithMaxNegatives, column]);
                }
            }
            // end

        }
        public int[,] Task7(int[,] matrix, int[] array)
        {
            int[,] answer = null;

            // code here
            if (array.Length != matrix.GetLength(0))
                return matrix;

            int smallestValue = Int32.MaxValue;
            int targetColumn = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] < smallestValue)
                    {
                        smallestValue = matrix[row, col];
                        targetColumn = col;
                    }
                }
            }

            answer = new int[matrix.GetLength(0), matrix.GetLength(1) + 1];

            for (int newRow = 0; newRow < answer.GetLength(0); newRow++)
            {
                int originalCol = 0;
                for (int newCol = 0; newCol < answer.GetLength(1); newCol++)
                {
                    if (newCol == targetColumn + 1)
                    {
                        answer[newRow, newCol] = array[newRow];
                    }
                    else
                    {
                        answer[newRow, newCol] = matrix[newRow, originalCol];
                        originalCol++;
                    }
                }
            }
            // end

            return answer;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                int positiveCount = 0;
                int negativeCount = 0;
                int columnMaximum = Int32.MinValue;
                int maxElementRow = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    int currentElement = matrix[row, column];

                    if (currentElement > columnMaximum)
                    {
                        columnMaximum = currentElement;
                        maxElementRow = row;
                    }

                    if (currentElement > 0)
                        positiveCount++;
                    else if (currentElement < 0)
                        negativeCount++;
                }

                if (positiveCount > negativeCount)
                    matrix[maxElementRow, column] = 0;
                else if (negativeCount > positiveCount)
                    matrix[maxElementRow, column] = maxElementRow;
            }
            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;

            int matrixSize = matrix.GetLength(0);

            for (int position = 0; position < matrixSize; position++)
            {
                matrix[0, position] = 0;
                matrix[position, 0] = 0;
                matrix[matrixSize - 1, position] = 0;
                matrix[position, matrixSize - 1] = 0;
            }
            // end

        }
        public (int[] A, int[] B) Task10(int[,] matrix)
        {
            int[] A = null, B = null;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return (A, B);

            int upperTriangleCount = 0;
            int lowerTriangleCount = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row <= col)
                        upperTriangleCount++;
                    else
                        lowerTriangleCount++;
                }
            }

            A = new int[upperTriangleCount];
            B = new int[lowerTriangleCount];

            int indexA = 0;
            int indexB = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row <= col)
                        A[indexA++] = matrix[row, col];
                    else
                        B[indexB++] = matrix[row, col];
                }
            }
            // end

            return (A, B);
        }
        public void Task11(int[,] matrix)
        {

            // code here
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                int[] tempColumn = new int[matrix.GetLength(0)];

                for (int row = 0; row < matrix.GetLength(0); row++)
                    tempColumn[row] = matrix[row, column];

                Array.Sort(tempColumn);

                if (column % 2 == 0)
                    Array.Reverse(tempColumn);

                for (int row = 0; row < matrix.GetLength(0); row++)
                    matrix[row, column] = tempColumn[row];
            }
            // end

        }
        public void Task12(int[][] array)
        {

            // code here
            if (array == null)
                return;

            int[] rowSums = new int[array.Length];

            for (int rowIndex = 0; rowIndex < array.Length; rowIndex++)
            {
                rowSums[rowIndex] = 0;
                if (array[rowIndex] != null)
                {
                    for (int elementIndex = 0; elementIndex < array[rowIndex].Length; elementIndex++)
                        rowSums[rowIndex] += array[rowIndex][elementIndex];
                }
            }

            for (int pass = 0; pass < array.Length - 1; pass++)
            {
                for (int currentIndex = 0; currentIndex < array.Length - 1 - pass; currentIndex++)
                {
                    int currentRowLength = array[currentIndex] != null ? array[currentIndex].Length : 0;
                    int nextRowLength = array[currentIndex + 1] != null ? array[currentIndex + 1].Length : 0;

                    bool shouldSwap = false;

                    if (currentRowLength < nextRowLength)
                    {
                        shouldSwap = true;
                    }
                    else if (currentRowLength == nextRowLength)
                    {
                        if (rowSums[currentIndex] < rowSums[currentIndex + 1])
                        {
                            shouldSwap = true;
                        }
                    }

                    if (shouldSwap)
                    {
                        (array[currentIndex], array[currentIndex + 1]) = (array[currentIndex + 1], array[currentIndex]);

                        (rowSums[currentIndex], rowSums[currentIndex + 1]) = (rowSums[currentIndex + 1], rowSums[currentIndex]);
                    }
                }
            }
            // end

        }
    }
}
