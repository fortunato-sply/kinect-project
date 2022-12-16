using System;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Imaging;


Application.SetHighDpiMode(HighDpiMode.SystemAware);
Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);

System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer();


var form = new Form();
form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.None;

form.KeyDown += (o, e) =>
{
    if (e.KeyCode == Keys.Escape)
        Application.Exit();
};

PictureBox pb = new PictureBox();
pb.SizeMode = PictureBoxSizeMode.Zoom;
pb.Dock = DockStyle.Fill;
form.Controls.Add(pb);

Bitmap func(Bitmap m, int x, int y)
{
    Bitmap returnBmp = new Bitmap(m.Width, m.Height);
    for (int i = 0; i < m.Width; i++)
        for (int j = 0; j < m.Height; j++)
            returnBmp.SetPixel(i,j, m.GetPixel(i,j));
    
    for(int i = x-10; i<x + 10; i++)
    {
        for(int j = y-10; j< y+10; j++){
            returnBmp.SetPixel(i,j,Color.Red);
        }
    }
    return returnBmp;
}
form.Load += (o,e) =>
{
    Bitmap back = Image.FromFile("BMP2.bmp") as Bitmap;
    back = func(back, 500,500);
    pb.Image = back;
    tm.Start();

};


Application.Run(form);






Pen Bpen = new Pen(Brushes.Blue, 10f);


// tm.Tick+= (o,e)=> 
// {
    
//     pb.Image = back;
//     pb.Refresh();
// };
