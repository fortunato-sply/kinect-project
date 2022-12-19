public class HandRecognizer
{
    private Bitmap bmp = null;
    private Point getRightPixel(Bitmap bmp)
    {
        for (int i = bmp.Width - 1; i > 0; i--)
        {
            for (int j = 0; j < bmp.Height; j++)
            {
                Color pixel = bmp.GetPixel(i, j);

                if (pixel.G != 0)
                {
                    return new Point(i, j);
                }
                
            }
        }
        throw new Exception();
    }

    public Point GetTopPixel(Bitmap bmp)
    {
        Point rightPixel = getRightPixel(bmp);

        for (int j = 0; j < bmp.Height; j++)
        {
            for (int i = (rightPixel.X - 80); i < (rightPixel.X + 80); i++)
            {
                Color pixel = bmp.GetPixel(i,j);

                if (pixel.G != 0)
                {
                    return new Point(i,j);
                }
            }
        }
        throw new Exception();
    }

    public Point GetCenterPixel(Bitmap bmp)
    {
        Point topPixel = GetTopPixel(bmp);

        for (int k = 0; k < 3; k++)
        {
            long sX = 0;
            long sY = 0;
            int count = 0;
            for (int j = topPixel.Y - 100; j < topPixel.Y + 100; j += 5)
            {
                for (int i = topPixel.X - 100; i < topPixel.X + 100; i += 5)
                {
                    Color pixel = bmp.GetPixel(i, j);

                    if (pixel.G != 0)
                    {
                        sX += i;
                        sY += j;
                        count++;
                    }
                }
            }
            topPixel = new Point((int)(sX / count), (int)(sY / count));
        }
        
        return topPixel;
    }

    public Boolean HandOpen(Bitmap bmp)
    {
        Point topPixel = GetTopPixel(bmp);
        int calibration = 60;
        double temp = 0;
        long whites = 1000;
        long count = 0;
        for (int j = topPixel.Y; j < (topPixel.Y + 50) ; j++)
        {
            for (int i = (topPixel.X - 50); i < (topPixel.X + 50); i++)
            {
                Color pixel = bmp.GetPixel(i, j);

                if (pixel.G != 0)
                {
                    whites += 1;
                }
                count += 1;
            }
        }

        temp = (whites/count)*100;

        if ((int)temp>calibration)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
