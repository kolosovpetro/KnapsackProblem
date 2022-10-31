using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackProblem;

public static class KnapsackSolver
{
    public static int GetOptimalProducts(IEnumerable<Product> products, int knapsackSize)
    {
        var productsArray = products.OrderBy(x => x.Price).ToArray();
        var productsCount = productsArray.Length;

        var jaggedArray = GenerateJaggedArray(knapsackSize, productsCount);

        for (var row = 0; row < productsCount; row++)
        {
            for (var column = 0; column < knapsackSize; column++)
            {
                var product = productsArray[row];

                var previousMaxIndex = row - 1;

                var previousMax = GetElement(jaggedArray, previousMaxIndex, column);

                if (product.Weight > column + 1)
                {
                    jaggedArray[row][column] = previousMax;
                    continue;
                }

                var remainingRow = row - 1;
                var remainingColumn = column - product.Weight;

                var remainingWeight = GetElement(jaggedArray, remainingRow, remainingColumn);
                var currentPrice = product.Price + remainingWeight;

                var result = Math.Max(previousMax, currentPrice);

                jaggedArray[row][column] = result;
            }
        }
        
        var max = jaggedArray[productsCount - 1][knapsackSize - 1];

        return max;
    }

    private static int[][] GenerateJaggedArray(int knapsackSize, int productsCount)
    {
        var jaggedArray = new int[productsCount][];

        for (var i = 0; i < productsCount; i++)
        {
            jaggedArray[i] = new int[knapsackSize];
        }

        return jaggedArray;
    }

    private static int GetElement(int[][] array, int row, int column)
    {
        try
        {
            return array[row][column];
        }
        catch (IndexOutOfRangeException)
        {
            return 0;
        }
    }
}