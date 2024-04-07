namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public class Logic
        {
            public static string testOfHappy(int number)//проверка числа на счастье
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
                    outMessage = "Число счастливое";
                else
                    outMessage = "Число не счастливое";
                return outMessage;
            }

        }
        public Form1()//отображение внешнего вида
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.number.ToString();
        }

        private void button1_Click(object sender, EventArgs e)//реализация события рассчёта при нажатии на кнопку
        {
            int number;
            try
            {
                number = int.Parse(textBox1.Text);
            }
            catch (FormatException)//Проверка на ввод
            {
                MessageBox.Show("Некорректный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Properties.Settings.Default.number = number;//сохранение последнего введеного значения
            Properties.Settings.Default.Save();
            if (number < 99999 || number > 1000000)//проверка на 6-значность
            {
                MessageBox.Show("Некорректный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else { label2.Text = Logic.testOfHappy(number);}//вывод результата на экран
            textBox1.Text = "";//очищение формы
        }
        private void button2_Click(object sender, EventArgs e)//реализация события при нажатии на кнопку задание
        {
            MessageBox.Show("Определить, является ли заданное шестизначное число счастливым. (Счастливым называют такое шестизначное число, что сумма его первых трех цифр равна сумме его последних трех цифр.)", "Задание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)//реализация переключения между компонентами по нажатию кнопки enter
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
    }
}