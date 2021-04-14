using System;
using System.Windows.Forms;
using System.Drawing;

class Cot : UserControl
{
    private TextureBrush CoAnh;
    public Cot(int chieucao)
    {
        this.CoAnh = new TextureBrush(global::ThapHaNoi.Properties.Resources.cot);
        this.Width = this.CoAnh.Image.Width;
        this.Height = chieucao;
        this.BackgroundImage = this.CoAnh.Image;
        this.BackgroundImageLayout = ImageLayout.Stretch;
    }
}