namespace KnapsackProblem;

public class Product
{
    public string Title { get; set; }
    public int Weight { get; set; }
    public int Price { get; set; }

    public override string ToString()
    {
        return $"Title: {Title}, Weight: {Weight}, Price: {Price}";
    }
}