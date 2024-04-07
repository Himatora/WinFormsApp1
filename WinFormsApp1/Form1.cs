namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public class Logic
        {
            public static string testOfHappy(int number)//�������� ����� �� �������
            {
                var sum1 = 0;
                var sum2 = 0;
                string outMessage = "";


                for (int i = 0; i < 6; i++)
                {
                    if (i < 3)
                    {
                        sum1 += number % 10;
                    }
                    else
                    {
                        sum2 += number % 10;
                    }
                    number = number / 10;
                }
                if (sum1 == sum2)
                    outMessage = "����� ����������";
                else
                    outMessage = "����� �� ����������";
                return outMessage;
            }

        }
        public Form1()//����������� �������� ����
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.number.ToString();
        }

        private void button1_Click(object sender, EventArgs e)//���������� ������� �������� ��� ������� �� ������
        {
            int number;
            try
            {
                number = int.Parse(textBox1.Text);
            }
            catch (FormatException)//�������� �� ����
            {
                MessageBox.Show("������������ ����", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Properties.Settings.Default.number = number;//���������� ���������� ��������� ��������
            Properties.Settings.Default.Save();
            if (number < 99999 || number > 1000000)//�������� �� 6-���������
            {
                MessageBox.Show("������������ ����", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else { label2.Text = Logic.testOfHappy(number);}//����� ���������� �� �����
            textBox1.Text = "";//�������� �����
        }
        private void button2_Click(object sender, EventArgs e)//���������� ������� ��� ������� �� ������ �������
        {
            MessageBox.Show("����������, �������� �� �������� ������������ ����� ����������. (���������� �������� ����� ������������ �����, ��� ����� ��� ������ ���� ���� ����� ����� ��� ��������� ���� ����.)", "�������", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)//���������� ������������ ����� ������������ �� ������� ������ enter
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
    }
}