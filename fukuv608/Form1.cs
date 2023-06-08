using System.Windows.Forms.Design;

namespace fukuv608
{
    public partial class Form1 : Form
    {
        static Random rand = new Random();

        int vx = rand.Next(-5, 66);
        int vy = rand.Next(-5,66);
        int iTime = 0;

        public Form1()
        {
            InitializeComponent();
            label1.Left = rand.Next(ClientSize.Width - label1.Width);
            label1.Top = rand.Next(ClientSize.Height-label1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            iTime++;
            label5.Text = $"{iTime}";


            label1.Left += vx;
            label1.Top += vy;

            /*if (label1.Left < 0)
            {
                vx = 10;
            }*/
            if (label1.Left < 0)
            {
                vx = Math.Abs(vx + (vx / 10));
            }
            else if (label1.Right > ClientSize.Width)
            {
                vx = Math.Abs(vx + (vx / 10));
            }
            /*if (label1.Top < 0)
            {
                vy = 10;
            }*/
            if (label1.Top < 0)
            {
                vy = Math.Abs(vy + (vy / 10));
            }
            else if (label1.Bottom > ClientSize.Height)
            {
                vy = -Math.Abs(vy);// 10);
            }
            if (label1.Right > 800)
            {
                vx = -10;
            }
            if (label1.Bottom > 450)
            {
                vy = -10;
            }

            // 変数mposを宣言して、マウスのフォーム座標を取り出す
            //// 1. MousePositionにマウス座標のスクリーン左上からのX、Yが入っている
            Text = $"{MousePosition.X} {MousePosition.Y}";

            //// 2. 変数fposを宣言して、PointToClient()でスクリーン座標をフォーム座標に変換
            var fpos = PointToClient(MousePosition);
            label1.Text = $"{fpos.X},{fpos.Y}";

            // ラベルに座標を表示
            //// 変換したフォーム座標は、fpos.X、fpos.Yで取り出せる
            label1.Text = $"{fpos.X},{fpos.Y}";

            //label2.widthでラベルの幅
            //label2.heightでラベルの高さ
            //マウスカーソルの位置がlabel2の中央になるようにする
            label4.Left = fpos.X - label4.Width / 2;
            label4.Top = fpos.Y - label4.Height / 2;

            if ((label1.Left < fpos.X) && (label1.Right > fpos.X) &&
                (label1.Top < fpos.Y) && (label1.Bottom > fpos.Y))
            {
                timer1.Enabled = false;
            }



        }

        private void label1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            label1.Text = "蝦名";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}