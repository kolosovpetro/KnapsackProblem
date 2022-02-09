using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace KnapsackProblem.Tests;

[TestFixture]
public class KnapsackTests
{
// - { Name = "Radio", Price = 3000, Weight = 4 },
// - { Name = "Laptop", Price = 2000, Weight = 3 },
// - { Name = "Guitar", Price = 1500, Weight = 1 }
    [Test]
    public void SimpleTest()
    {
        var products = new[]
        {
            new Product {Title = "Radio", Price = 3000, Weight = 4},
            new Product {Title = "Laptop", Price = 2000, Weight = 3},
            new Product {Title = "Guitar", Price = 1500, Weight = 1},
        };
        const int size = 4;
        var expected = new[]
        {
            new Product {Title = "Laptop", Price = 2000, Weight = 3},
            new Product {Title = "Guitar", Price = 1500, Weight = 1},
        };

        var optimal = new KnapsackSolver().GetOptimalProducts(products, size);

        optimal.SequenceEqual(expected).Should().BeTrue();
    }
}