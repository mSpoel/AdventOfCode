public class FloodFillAlgorithm
{
    public void FloodFill(int[][] image, int sr, int sc, int newColor)
    {
        if (image[sr][sc] != newColor)
        {
            Fill(image, sr, sc, image[sr][sc], newColor);
        }
    }

    private void Fill(int[][] image, int sr, int sc, int color, int newColor)
    {
        if (sr < 0 || sc < 0 || sr >= image.Length || sc >= image[0].Length || image[sr][sc] != color)
        {
            return;
        }

        image[sr][sc] = newColor;

        Fill(image, sr - 1, sc, color, newColor);
        Fill(image, sr + 1, sc, color, newColor);
        Fill(image, sr, sc - 1, color, newColor);
        Fill(image, sr, sc + 1, color, newColor);
    }
}
