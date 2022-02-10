using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace KnapsackProblem.Tests;

[TestFixture]
public class KnapsackTests
{
    [Test]
    public void SimpleTest()
    {
        var products = new[]
        {
            new Product {Title = "Radio", Price = 3000, Weight = 4},
            new Product {Title = "Laptop", Price = 2000, Weight = 3},
            new Product {Title = "Guitar", Price = 1500, Weight = 1},
            new Product {Title = "Iphone", Price = 4000, Weight = 1},
        };
        const int size = 4;
        var expected = new[]
        {
            new Product {Title = "Laptop", Price = 2000, Weight = 3},
            new Product {Title = "Guitar", Price = 1500, Weight = 1},
        };

        var optimal = KnapsackSolver.GetOptimalProducts(products, size);

        optimal.SequenceEqual(expected).Should().BeTrue();
    }
}