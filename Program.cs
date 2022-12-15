using System.Drawing;
using System.Windows.Forms;

ApplicationConfiguration.Initialize();

var form = new Form();
form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.None;

PictureBox pb = new PictureBox();
pb.Dock = DockStyle.Fill;
form.Controls.Add(pb);

Bitmap bmp = null;

System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer();
tm.Interval = 25;

form.KeyDown += (o, e) =>
{
    if (e.KeyCode == Keys.Escape)
        Application.Exit();
};

Graphics g = null;
form.Load += delegate
        {
            bmp = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            pb.Image = bmp;
            g.DrawImage(Bitmap.FromFile("BMP1.bmp"), new Point(0,0));

            HandRecognizer handrec = new HandRecognizer();
            var center = handrec.GetCenterPixel(Bitmap.FromFile("BMP1.bmp") as Bitmap);
            Pen pen = new Pen(Color.Red, 2);
            g.FillRectangle(Brushes.Red, 42, 12, 1, 1);

            tm.Start();
        };

// form.Load += (o, e) =>
// {
//     bmp = Bitmap.FromFile("BMP1.bmp") as Bitmap;
//     pb.Image = bmp;
    
//     HandRecognizer handrec = new HandRecognizer();
//     var teste1 = handrec.GetCenterPixel(Bitmap.FromFile("BMP2.bmp") as Bitmap).ToString();
//     var g = Graphics.FromImage(bmp);
//     // DrawStrin(g, teste1);
//     g.
//     // g.DrawLine(Pens.Blue, 
//     //     0, 0,
//     //     pb.Width, pb.Height);



//     // pb.Refresh();
//     tm.Start();
// };

// int i = 0;
// tm.Tick += (o, e) =>
//    
//     float a = pb.Height / (float)pb.Width;
//     bmp.SetPixel(i, (int)(a * i), Color.Blue);
//     Console.WriteLine(bmp.GetPixel(1, 2).ToKnownColor());
//     i++;

//     if (i >= pb.Width/2)
//         Application.Exit();
    
//     pb.Refresh();
//;

void DrawStrin(Graphics form, string text)
{
    System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 16);
    System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
    float x = 150.0F;
    float y = 50.0F;
    System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
    form.DrawString(text, drawFont, drawBrush, x, y, drawFormat);
    drawFont.Dispose();
    drawBrush.Dispose();
    form.Dispose();
}

Application.Run(form);