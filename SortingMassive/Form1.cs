using System.Collections.Generic;
using System.Diagnostics;

namespace SortingMassive
{
    public partial class Form1 : Form
    {
        List<int> Mass1 = new List<int>();
        List<char> Mass2 = new List<char>();
        Panel[] pnls = new Panel[4];

        public Form1()
        {
            InitializeComponent();
            pnls[0] = Panel1NumArray; pnls[1] = Panel2BinArray; pnls[2] = Panel3FlagArray; pnls[3] = Panel4HogwArray;

            string[] sorts = { "Сортировка Пузырьком", "Сортировка Вставками", "Сортировка Слиянием",
            "Быстрая Сортировка" };
            GnComboBox1.Items.AddRange(sorts);
            GnComboBox1.SelectedIndex = 0;
        }

        public static void PanelChange(int numb, Panel[] pnls)
        {
            for (int i = 0; i < pnls.Length; i++)
            {
                if (i == numb)
                { pnls[i].Show(); }
                else
                { pnls[i].Hide(); }
            }
        }

        // Панель Меню
        private void B1NumArray_Click(object sender, EventArgs e)
        {
            PanelChange(0, pnls);
        }
        private void B2BinArray_Click(object sender, EventArgs e)
        {
            PanelChange(1, pnls);
        }
        private void B3FlagArray_Click(object sender, EventArgs e)
        {
            PanelChange(2, pnls);
        }
        private void B4HogwArray_Click(object sender, EventArgs e)
        {
            PanelChange(3, pnls);
        }

        // Генерация числового массива
        private void Pnl1B1_Click(object sender, EventArgs e)
        {
            int minzn = (int)Pnl1N1.Value;
            int maxzn = (int)Pnl1N2.Value;
            int kolvo = (int)Pnl1N3.Value;
            int[] Massive = new int[kolvo];
            Massive = SortingAlgorithms.GenerateIntArray(kolvo, minzn, maxzn);
            Mass1.Clear();
            Mass1.AddRange(Massive);
            MassiveView.Rows.Clear();
            for (int i = 0; i < Massive.Length; i++)
            { MassiveView.Rows.Add(Massive[i].ToString()); }
        }

        // Генерация бинарного массива
        private void Pnl2B1_Click(object sender, EventArgs e)
        {
            int kolvo = (int)Pnl2N1.Value;
            int[] Massive = SortingAlgorithms.GenerateN2Array(kolvo);
            Mass1.Clear();
            Mass1.AddRange(Massive);
            MassiveView.Rows.Clear();
            for (int i = 0; i < Massive.Length; i++)
            { MassiveView.Rows.Add(Massive[i].ToString()); }
        }

        // Генерация массива флага
        private void Pnl3B1_Click(object sender, EventArgs e)
        {
            int kolvo = (int)Pnl3N1.Value;
            char[] Massive = SortingAlgorithms.GenerateFlagArray(kolvo);
            Mass2.Clear();
            Mass2.AddRange(Massive);
            MassiveView.Rows.Clear();
            for (int i = 0; i < Massive.Length; i++)
            { MassiveView.Rows.Add(Massive[i].ToString()); }
        }

        // Генерация массива Хогвартса
        private void Pnl4B1_Click(object sender, EventArgs e)
        {
            int kolvo = (int)Pnl4N1.Value;
            char[] Massive = SortingAlgorithms.GenerateHogwartsArray(kolvo);
            Mass2.Clear();
            Mass2.AddRange(Massive);
            MassiveView.Rows.Clear();
            for (int i = 0; i < Massive.Length; i++)
            { MassiveView.Rows.Add(Massive[i].ToString()); }
        }

        // Обработка минимума и максимума числового массива
        private void Pnl1N1_ValueChanged(object sender, EventArgs e)
        {
            int a = (int)Pnl1N1.Value;
            int b = (int)Pnl1N2.Value;
            if (a == b || a > b)
            { Pnl1N2.Value = a + 1; }
        }
        private void Pnl1N2_ValueChanged(object sender, EventArgs e)
        {
            int a = (int)Pnl1N1.Value;
            int b = (int)Pnl1N2.Value;
            if (a == b || a > b)
            { Pnl1N1.Value = b - 1; }
        }

        // Настройка выбора сортировки
        private void GnComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = GnComboBox1.SelectedIndex;
            if (a == 0 || a == 1)
            { Pnl1L6.Text = "О-нотация: О(n^2)"; }
            else
            { Pnl1L6.Text = "О-нотация: О(n*log(n))"; }
        }

        private void Pnl1B2_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            int a = GnComboBox1.SelectedIndex;
            int[] Massive = Mass1.ToArray();
            switch (a)
            {
                case 0:
                    {
                        timer.Start();
                        SortingAlgorithms.BubbleSort(Massive);
                        timer.Stop();
                        MassiveView.Rows.Clear();
                        for (int i = 0; i < Massive.Length; i++)
                        { MassiveView.Rows.Add(Massive[i].ToString()); }
                        GnText1.Text = timer.ElapsedMilliseconds.ToString();
                        break;
                    }
                case 1:
                    {
                        timer.Start();
                        SortingAlgorithms.InsertionSort(Massive);
                        timer.Stop();
                        MassiveView.Rows.Clear();
                        for (int i = 0; i < Massive.Length; i++)
                        { MassiveView.Rows.Add(Massive[i].ToString()); }
                        GnText1.Text = timer.ElapsedMilliseconds.ToString();
                        break;
                    }
                case 2:
                    {
                        timer.Start();
                        SortingAlgorithms.MergeSort(Massive);
                        timer.Stop();
                        MassiveView.Rows.Clear();
                        for (int i = 0; i < Massive.Length; i++)
                        { MassiveView.Rows.Add(Massive[i].ToString()); }
                        GnText1.Text = timer.ElapsedMilliseconds.ToString();
                        break;
                    }
                case 3:
                    {
                        timer.Start();
                        SortingAlgorithms.QuickSort(Massive);
                        timer.Stop();
                        MassiveView.Rows.Clear();
                        for (int i = 0; i < Massive.Length; i++)
                        { MassiveView.Rows.Add(Massive[i].ToString()); }
                        GnText1.Text = timer.ElapsedMilliseconds.ToString();
                        break;
                    }
            }
        }

        private void Pnl2B2_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            int[] Massive = Mass1.ToArray();
            timer.Start();
            SortingAlgorithms.SortN2(Massive);
            timer.Stop();
            MassiveView.Rows.Clear();
            for (int i = 0; i < Massive.Length; i++)
            { MassiveView.Rows.Add(Massive[i].ToString()); }
            GnText1.Text = timer.ElapsedMilliseconds.ToString();
        }

        private void Pnl3B2_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            char[] Massive = Mass2.ToArray();
            timer.Start();
            SortingAlgorithms.SortFlag(Massive);
            timer.Stop();
            MassiveView.Rows.Clear();
            for (int i = 0; i < Massive.Length; i++)
            { MassiveView.Rows.Add(Massive[i].ToString()); }
            GnText1.Text = timer.ElapsedMilliseconds.ToString();
        }

        private void Pnl4B2_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            char[] Massive = Mass2.ToArray();
            timer.Start();
            SortingAlgorithms.SortHogwarts(Massive);
            timer.Stop();
            MassiveView.Rows.Clear();
            for (int i = 0; i < Massive.Length; i++)
            { MassiveView.Rows.Add(Massive[i].ToString()); }
            GnText1.Text = timer.ElapsedMilliseconds.ToString();
        }

        private void B7EXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void B5HelpHote_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }
    }
}
