using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

public class HandRecognizer
{
    private Bitmap bmp = null;
    public Point getRightPixel(Bitmap bmp)
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

    public Point getRightPixell(Bitmap bmp)
    {
        var data = bmp.LockBits(
            new Rectangle(0, 0, bmp.Width, bmp.Height),
            ImageLockMode.ReadWrite,
            PixelFormat.Format24bppRgb);
        
        unsafe
        {
            byte* p = (byte*)data.Scan0.ToPointer();
            
            for (int j = bmp.Width - 1; j > 0; j--)
            {
                for (int i = 0; i < bmp.Height; i++)
                {
                    byte* l = p + (i * data.Stride) + 3 * j;
                    if(l[0] > 100)
                    {
                        bmp.UnlockBits(data);
                        return new Point(j, i);
                    }
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
}
