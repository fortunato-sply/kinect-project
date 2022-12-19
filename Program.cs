using System.Drawing;
using System.Windows.Forms;

ApplicationConfiguration.Initialize();

var form = new Form();
form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.None;

PictureBox pb = new PictureBox();
pb.Dock = DockStyle.Fill;
pb.SizeMode = PictureBoxSizeMode.Normal;
form.Controls.Add(pb);

Bitmap bmp = null;

System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer();
tm.Interval = 25;

form.KeyDown += (o, e) =>
{
    if (e.KeyCode == Keys.Escape)
        Application.Exit();
};


 //-------------- VISUALIZAR STRING FUNCIONANDO NAO APAGA POR FAVOOR ----------

// Graphics g = null;
// form.Load += delegate
// {
//     bmp = new Bitmap(pb.Width, pb.Height);
//     g = Graphics.FromImage(bmp);
//     g.Clear(Color.White);
//     pb.Image = bmp;


//     var img = Bitmap.FromFile("BMP1.bmp") as Bitmap;

//     HandRecognizer handrec = new HandRecognizer();

//     DrawStrin(g, handrec.HandOpen(img));


// };



// // --------------- DAQUI PRA BAIXO É O CÓDIGO DE VISUALIZAR O PONTO NA IMAGEM ----------------

Graphics g = null;
form.Load += delegate
{
    bmp = new Bitmap(pb.Width, pb.Height);
    g = Graphics.FromImage(bmp);
    g.Clear(Color.White);
    pb.Image = bmp;

    var img = Bitmap.FromFile("BMP2.bmp") as Bitmap;

    HandRecognizer handrec = new HandRecognizer();
    var center = handrec.GetCenterPixel(img);

    
    if (handrec.HandOpen(img))
    {
        Pen pen = new Pen(Color.Green, 2);
    }
    else
    {
        Pen pen = new Pen(Color.Red, 2);
    }
    g.DrawImage(img, new Rectangle(0, 0, 1600, 1200),
        new Rectangle(0, 0, 1600, 1200), GraphicsUnit.Pixel);
    if (handrec.HandOpen(img))
    {
        g.FillRectangle(Brushes.Green, center.X - 5, center.Y - 5, 10, 10);
    }
    else
    {
        g.FillRectangle(Brushes.Red, center.X - 5, center.Y - 5, 10, 10);
    }
    pb.Refresh();
    tm.Start();
    // DrawPoint(g,500,500) 
};


// // --------------- ATE AQUI PRA VISUALIZAR A IMAGEM, O RESTO COMENTADO É LIXO ----------------



// // --------------- ISSO AQUI NAO TA FUNCIONANDO, E NÃO SERVE PRA NADA, MAS NAO APAGAR CASO TENHA UTILIDADE FUTURA ----------------

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


// // --------------- O LIXO ACABA AQUI  ----------------


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


Bitmap DrawPoint(Bitmap m, int x, int y)
{
    Bitmap returnBmp = new Bitmap(m.Width, m.Height);
    for (int i = 0; i < m.Width; i++)
        for (int j = 0; j < m.Height; j++)
            returnBmp.SetPixel(i,j, m.GetPixel(i,j));
    
    for(int i = x-5; i < x+5; i++)
    {
        for(int j = y-10; j < y+10; j++){
            returnBmp.SetPixel(i,j,Color.Red);
        }
    }
    return returnBmp;
}





Application.Run(form);