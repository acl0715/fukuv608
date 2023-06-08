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

            // �ϐ�mpos��錾���āA�}�E�X�̃t�H�[�����W�����o��
            //// 1. MousePosition�Ƀ}�E�X���W�̃X�N���[�����ォ���X�AY�������Ă���
            Text = $"{MousePosition.X} {MousePosition.Y}";

            //// 2. �ϐ�fpos��錾���āAPointToClient()�ŃX�N���[�����W���t�H�[�����W�ɕϊ�
            var fpos = PointToClient(MousePosition);
            label1.Text = $"{fpos.X},{fpos.Y}";

            // ���x���ɍ��W��\��
            //// �ϊ������t�H�[�����W�́Afpos.X�Afpos.Y�Ŏ��o����
            label1.Text = $"{fpos.X},{fpos.Y}";

            //label2.width�Ń��x���̕�
            //label2.height�Ń��x���̍���
            //�}�E�X�J�[�\���̈ʒu��label2�̒����ɂȂ�悤�ɂ���
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
            label1.Text = "�ږ�";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}