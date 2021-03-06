
using System;
using System.Windows.Forms;
using System.Drawing;
//Dùng để xét các cặp gửi-nhận có thể được chọn
struct CapThap
{
    public int ThapGui;
    public int ThapNhan;
    public int ChiPhi;
}

class ChuongTrinh : Form
{
    static void Main()
    {
        Application.Run(new ChuongTrinh());
    }

    private Image ThienThanIT;

    private Label LbTieuDe;
    private Label LbSoDia;
    private TextBox TbSoDia;
    private Button BtSoDia;
    private Thap[] CacThap;
    private Label LbA;
    private Label LbB;
    private Label LbC;
    private Button BtKhoiDongLai;

    private int SoLanChuyen;
    private Label LbSoDiaDung;
    private Button BtDiChuyen;
    private Label LbThanhCong;
    
    //Dùng để xét từng cặp gửi-nhận
    private CapThap[] CacCapThap=new CapThap[6];
    //Dùng để lưu lại cặp gửi-nhận liền trước
    private static CapThap CapTruoc;
    public ChuongTrinh()
    {
        this.Width = 800;
        this.Height = 600;
        this.FormBorderStyle = FormBorderStyle.Fixed3D;
        this.Text = "Thuật Giải Tháp Hà Nội - ThienThanIT";
        this.BackColor = Color.Black;
        this.Paint += new PaintEventHandler(ChuongTrinh_Paint);

        this.ThienThanIT = Image.FromFile(@".../.../ThienThanIt.jpg");

        this.LbTieuDe = new Label();
        this.LbTieuDe.Location = new Point(280,10);
        this.LbTieuDe.Size = new Size(300,30);
        this.LbTieuDe.Text = "Thuật Giải Tháp Hà Nội";
        this.LbTieuDe.Font = new Font(new FontFamily("Arial"),15);
        this.LbTieuDe.ForeColor = Color.Red;
        this.Controls.Add(this.LbTieuDe);

        this.LbSoDia = new Label();
        this.LbSoDia.Location = new Point(260,68);
        this.LbSoDia.AutoSize = true;
        this.LbSoDia.Text = "Nhập số đĩa cần chuyển: ";
        this.LbSoDia.ForeColor = Color.Blue;
        this.Controls.Add(this.LbSoDia);

        this.TbSoDia = new TextBox();
        this.TbSoDia.Location = new Point(400,62);
        this.TbSoDia.Width = 30;
        this.TbSoDia.BackColor = Color.Black;
        this.TbSoDia.ForeColor = Color.Green;
        this.Controls.Add(this.TbSoDia);

        this.BtSoDia = new Button();
        this.BtSoDia.Location = new Point(450,60);
        this.BtSoDia.Width = 50;
        this.BtSoDia.BackgroundImage = global::ThapHaNoi.Properties.Resources.nhap;
        this.BtSoDia.BackgroundImageLayout = ImageLayout.Stretch;
        this.BtSoDia.Click+=new EventHandler(BtSoDia_Click);
        this.Controls.Add(this.BtSoDia);

        this.LbA = new Label();
        this.LbA.Location = new Point(110, 530);
        this.LbA.Text = "Tháp A";
        this.LbA.ForeColor = Color.Red;
        this.LbA.Size = new Size(50,20);
        this.Controls.Add(this.LbA);

        this.LbB = new Label();
        this.LbB.Location = new Point(380, 530);
        this.LbB.Text = "Tháp B";
        this.LbB.ForeColor = Color.Red;
        this.LbB.Size = new Size(50, 20);
        this.Controls.Add(this.LbB);

        this.LbC = new Label();
        this.LbC.Location = new Point(650, 530);
        this.LbC.Text = "Tháp C";
        this.LbC.ForeColor = Color.Red;
        this.LbC.Size = new Size(50, 20);
        this.Controls.Add(this.LbC);

        this.LbThanhCong = new Label();
        this.LbThanhCong.Location = new Point(360,150);
        this.LbThanhCong.ForeColor = Color.Yellow;
        this.LbThanhCong.Text = "Thành Công";

        this.CacThap = new Thap[3];
        this.CacThap[0] = new Thap();
        this.CacThap[0].Location = new Point(0, 220);
        this.Controls.Add(this.CacThap[0]);

        this.CacThap[1] = new Thap();
        this.CacThap[1].Location = new Point(270, 220);
        this.Controls.Add(this.CacThap[1]);

        this.CacThap[2] = new Thap();
        this.CacThap[2].Location = new Point(540, 220);
        this.Controls.Add(this.CacThap[2]);

        this.LbSoDiaDung = new Label();
        this.LbSoDiaDung.Location = new Point(310,90);
        this.LbSoDiaDung.AutoSize = true;
        this.LbSoDiaDung.ForeColor = Color.GreenYellow;
        this.Controls.Add(this.LbSoDiaDung);

        this.BtKhoiDongLai = new Button();
        this.BtKhoiDongLai.Location = new Point(700,10);
        this.BtKhoiDongLai.BackgroundImage = global::ThapHaNoi.Properties.Resources.chaylai;
        this.BtKhoiDongLai.BackgroundImageLayout = ImageLayout.Stretch;
        this.BtKhoiDongLai.Click+=new EventHandler(BtKhoiDongLai_Click);

        ChuongTrinh.CapTruoc.ThapNhan = 0;
        ChuongTrinh.CapTruoc.ThapGui = 0;
        
    }

    void ChuongTrinh_Paint(object sender, PaintEventArgs e)
    {
        Graphics ve = e.Graphics;
        ve.DrawImage(this.ThienThanIT, 10, 10,50,40);
    }


    private void BtSoDia_Click(object o, EventArgs e)
    {
        int so;
        try
        {
            so = int.Parse(this.TbSoDia.Text);
        }
        catch
        {
            MessageBox.Show("Nhập Cho Đúng Đi Mà!\n\tOK?");
            this.TbSoDia.Text = string.Empty;
            return;
        }
        if (so <= 20)
        {
            this.Controls.Remove(this.CacThap[0]);
            this.CacThap[0]=Thap.TaoKhoiDau(int.Parse(this.TbSoDia.Text));
            this.CacThap[0].Location = new Point(0, 220);
            this.Controls.Add(this.CacThap[0]);

            this.Controls.Add(this.BtKhoiDongLai);

            this.LbSoDia.Text = "Số lần đã chuyển: "+this.SoLanChuyen;
            this.LbSoDia.ForeColor = Color.GreenYellow;           

            this.LbSoDia.Location = new Point(340, 68);
            this.LbSoDiaDung.Text = "Số đĩa đã chuyển hoàn thành: " + this.CacThap[2].SoDiaDung(int.Parse(this.TbSoDia.Text));

            this.BtDiChuyen = new Button();
            this.BtDiChuyen.Location = new Point(355, 150);
            this.AutoSize = true;
            this.BtDiChuyen.BackgroundImage = global::ThapHaNoi.Properties.Resources.dichuyenon;
            this.BtDiChuyen.BackgroundImageLayout = ImageLayout.Stretch; ;
            this.BtDiChuyen.Click += new EventHandler(ThuatGiaiThapHaNoi);
            this.Controls.Add(this.BtDiChuyen);

            this.TbSoDia.Hide();
            this.BtSoDia.Hide();
        }
        else
            MessageBox.Show("Không đủ màn hình để biểu diễn!\n    Xin vui lòngnhập số <= 20");
    }

    private void BtKhoiDongLai_Click(object o, EventArgs e)
    {
        Application.Restart();
    }

    //Nhận chỉ số của Tháp gửi x và Tháp gửi y và trả về chi phí
    private int TinhChiPhi(int x, int y)
    {
        //Nếu việc gửi nhận không thành công thì chi phí giữ nguyên hiện tại
        int kq=this.CacThap[2].SoLanItNhat(int.Parse(this.TbSoDia.Text));
        //Gửi được nếu Tháp gửi có đĩa
        if (this.CacThap[x].CacDia.Length != 0)
        {
            //Nhưng Tháp nhận phải không có đĩa hoặc có đĩa thì đĩa đầu có phải lớn hơn đĩa đầu của Tháp gửi
            if ((this.CacThap[y].CacDia.Length == 0) || (this.CacThap[y].CacDia.Length != 0 && this.CacThap[x].CacDia[0].Width < this.CacThap[y].CacDia[0].Width))
            {
                //Nếu Tháp gửi là Tháp C
                if (x == 2)
                {
                    //Tạo Tháp tam giống Tháp C để tính chi phí
                    Thap tam=new Thap();
                    tam.CacDia =new Dia[this.CacThap[2].CacDia.Length];
                    for (int i = 0; i < this.CacThap[2].CacDia.Length; i++)
                        tam.CacDia[i] = new Dia(this.CacThap[2].CacDia[i].So);
                    //Thực hiện cho đĩa trước khi tính chi phí
                    tam.ChoDia();
                    kq = tam.SoLanItNhat(int.Parse(this.TbSoDia.Text));
                }
                //Nếu Tháp nhận là Tháp C
                if (y == 2)
                {
                    Thap tam = new Thap();
                    tam.CacDia = new Dia[this.CacThap[2].CacDia.Length];
                    for (int i = 0; i < this.CacThap[2].CacDia.Length; i++)
                        tam.CacDia[i] = new Dia(this.CacThap[2].CacDia[i].So);
                    //Thực hiện nhận đĩa trước khi tính chi phí
                    tam.NhanDia(this.CacThap[x].CacDia[0]);
                    kq = tam.SoLanItNhat(int.Parse(this.TbSoDia.Text));
                }
            }
        }
        return kq;
    }
    //Nhận vào 1 mãng và 1 chỉ số, huỷ phần tử có chỉ số đó ra khỏi mảng
    private int[] RutGonMang(int[] mang, int chisohuy)
    {
        int[] kq=new int[mang.Length-1];
        int k = 0;
        for (int i = 0; i<mang.Length; i++)
        {
            if (i == chisohuy)
            {
                for (int j = i+1; j < mang.Length; j++)
                    kq[k++] = mang[j];
                break;
            }
            kq[k++] = mang[i];
        }
        return kq;
    }

    //Sắp xếp lại các cặp Tháp gửi nhận tăng dần theo chi phí
    private void SapXepCacCapThap()
    {
        for (int i = 1; i < this.CacCapThap.Length; i++)
        {
            CapThap tam=this.CacCapThap[i];
            int j = i - 1;
            while ((j >= 0) && (tam.ChiPhi < this.CacCapThap[j].ChiPhi))
            {
                this.CacCapThap[j+1] = this.CacCapThap[j];
                j--;
            }
            this.CacCapThap[j + 1] = tam;
        }
    }

    //Nhận vào 1 số, tìm ra 1 mảng chứa các số = với min của mảng +x
    private int[] CatDoan(int x)
    {
        int[] kq;
        int so=0,min=this.CacCapThap[0].ChiPhi;
        for (int i = 1; i < this.CacCapThap.Length; i++)
        {
            if (this.CacCapThap[i].ChiPhi < min)
            {
                min = this.CacCapThap[i].ChiPhi;
            }
        }
        for (int i = 0; i < this.CacCapThap.Length; i++)
        {
            if (this.CacCapThap[i].ChiPhi == min + x)
                so++;
        }
        kq = new int[so];
        int h=0;
        for (int i = 0; i < this.CacCapThap.Length; i++)
        {
            if (this.CacCapThap[i].ChiPhi == min + x)
                kq[h++] = i;
        }
        return kq;
    }


    //Thuật giải Tháp Hà Nội, thực hiện khi nhấp nút chuyển
    private void ThuatGiaiThapHaNoi(object o, EventArgs e)
    {
        //Khi thanhcong ==true thi 2 dừng
        bool thanhcong = false;
        while (thanhcong == false)
        {
            //Khi chuyển được 1 đĩa thì số lần chuyển tăng lên
            this.SoLanChuyen++;
            this.LbSoDia.Text = "Số lần đã chuyển: " + this.SoLanChuyen;
            this.LbSoDia.Refresh();
            //Tạo ra các cặp Tháp gửi-nhận
            int k = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j != i)
                    {
                        this.CacCapThap[k].ThapGui = i;
                        this.CacCapThap[k++].ThapNhan = j;
                    }
                }
            }
            //Tính chi phí cho từng cặp Tháp
            for (int i = 0; i < this.CacCapThap.Length; i++)
                this.CacCapThap[i].ChiPhi = TinhChiPhi(this.CacCapThap[i].ThapGui, this.CacCapThap[i].ThapNhan);
            //Lấy ra các cặp có chi phí nhỏ nhất
            int[] cacmin = CatDoan(0);
            bool dung = false;
            int s = 1;
            //Nếu đúng ==true tức là gửi được đĩa thì dừng
            while (dung == false)
            {
                bool co = false;
                int min , x;
                //Nếu kiểm tra hết đoạn min thì chuyển sang đoạn lớn hơn min 1, lớn hơn min 2..
                if (cacmin.Length == 0)
                {
                    cacmin = CatDoan(s);
                    s++;
                    continue;
                }
                //Nếu chưa hết thì lấy ngẫu nhiên 1 chỉ số trong mãng chỉ số đó
                else
                {
                    Random so = new Random();
                    x = so.Next(0, cacmin.Length);
                    min = cacmin[x];
                    cacmin = RutGonMang(cacmin, x);
                }
                //Khi gửi đi thì không được gửi lại
                //Trừ khi Tháp C không có đĩa nào sai
                if ((this.CacCapThap[min].ThapNhan == ChuongTrinh.CapTruoc.ThapGui) && (this.CacCapThap[min].ThapGui == ChuongTrinh.CapTruoc.ThapNhan))
                {
                    if (this.CacThap[0].CacDia.Length != 0 || this.CacThap[2].CacDia.Length != this.CacThap[2].SoDiaDung(int.Parse(this.TbSoDia.Text)))
                        continue;
                }
                //Tháp A không được quay trở lại như lúc khởi đầu
                if (this.CacCapThap[min].ThapNhan == 0 && this.CacThap[0].CacDia.Length == int.Parse(this.TbSoDia.Text) - 1)
                    continue;
                //Chỉ gửi được khi Tháp gửi có đĩa
                if (this.CacThap[this.CacCapThap[min].ThapGui].CacDia.Length == 0)
                    continue;
                //Kiểm tra nhận được hay không
                else
                    co = this.CacThap[this.CacCapThap[min].ThapNhan].NhanDia(this.CacThap[this.CacCapThap[min].ThapGui].CacDia[0]);
                //Nều nhận cũng được luôn thì bắt đầu thực hiện gửi-nhận
                if (co == true)
                {
                    ChuongTrinh.CapTruoc = this.CacCapThap[min];
                    this.CacThap[this.CacCapThap[min].ThapGui].ChoDia();
                    this.Controls.Add(this.CacThap[this.CacCapThap[min].ThapGui]);
                    dung = true;
                    this.LbSoDiaDung.Text = "Số đĩa đã chuyển hoàn thành: " + this.CacThap[2].SoDiaDung(int.Parse(this.TbSoDia.Text));
                    this.LbSoDiaDung.Refresh();
                    this.BtDiChuyen.Hide();
                }
            }
            //Nếu chi phí ==0 thì thành công
            if (this.CacThap[2].SoLanItNhat(int.Parse(this.TbSoDia.Text)) == 0)
                thanhcong = true;
        }
        this.Controls.Add(this.LbThanhCong);
    }
}