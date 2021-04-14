using System;
using System.Drawing;
using System.Windows.Forms;

class Dia:UserControl
{
    private TextureBrush CaiDia;
    private int so;
    public int ChieuRong
    {
        get { return this.CaiDia.Image.Width; }
    }

    public int So
    {
        get { return this.so; }
    }

    public Dia(int so)
    {
        this.so = so;
        this.CaiDia = new TextureBrush(global::ThapHaNoi.Properties.Resources.dia);
        this.BackgroundImageLayout=ImageLayout.Stretch;
        this.BackgroundImage=this.CaiDia.Image;
        this.Width=(this.CaiDia.Image.Width-25)+(so*10);
        this.Height=this.CaiDia.Image.Height-2;
    }

}
