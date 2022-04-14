namespace StandardOperators;

public static class Chunking
{
    public static void ChunkingNumbers()
    {
        IEnumerable<int> lotsOfNumbers = Enumerable.Range(1, 50);

        IEnumerable<int[]> chunked = lotsOfNumbers.Chunk(15);
        foreach (int[] chunk in chunked)
        {
            Console.WriteLine(
                $"Chunk (length {chunk.Length}): {String.Join(", ", chunk)}");
        }
    }
}