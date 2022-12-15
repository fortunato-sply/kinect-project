public class HandRecognizer {
    private Bitmap bmp = null;
    public Point GetRightPixel(Bitmap bmp)
    {
        for (int i = bmp.Width - 1; i > 0; i--)
        {
            for (int j = 0; j < bmp.Height; j++)
            {
                Color pixel = bmp.GetPixel(i,j);

                if (pixel.G != 0)
                {
                    Console.WriteLine($"{i}, {j}");
                    return new Point(i, j);
                }
            }
        }
        throw new Exception();
    }

    public Point GetTopPixel()
    {
        // TODO
    }
}
