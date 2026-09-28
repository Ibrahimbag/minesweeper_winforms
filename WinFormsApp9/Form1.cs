using System.Data.Common;
using System.Diagnostics;

namespace WinFormsApp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int height = 5, width = 10;
        int mine_count = 10;

        bool[,] minefield; 

        private void Init_Minefield()
        {
            Random random = new Random();

            minefield = new bool[height, width];

            int mineCountPlaced = 0;

            while (mineCountPlaced < mine_count)
            {
                int i = random.Next(height);
                int j = random.Next(width);

                if (!minefield[i, j])
                {
                    minefield[i, j] = true;
                    mineCountPlaced++;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init_Minefield();

            int y = 100;
            int count = 0;

            for (int i = 0; i < height; i++)
            {
                int x = 150;
                for (int j = 0; j < width; j++)
                {
                    Button btn = new Button();
                    btn.Name = "" + count;
                    btn.Text = "";
                    btn.Location = new Point(x, y);
                    btn.Size = new Size(50, 50);
                    btn.Click += Button_Click;
                    Controls.Add(btn);
                    x = x + 50;
                    count++;
                }
                y += 50;
            }
        }

        private int Count_Surrounding_Mines(int index, int row, int col)
        {
            int count = 0;

            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i >= 0 && i < height && j >= 0 && j < width)
                    {
                        if (minefield[i, j] == true)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button tiklananButton = (Button)sender;

            int index = int.Parse(tiklananButton.Name);
            int row = index / width;
            int col = index % width;

            if (minefield[row, col] == true)
            {
                tiklananButton.BackColor = Color.Red;
                MessageBox.Show("Mayýna bastýnýz");
            }
            else
            {
                tiklananButton.BackColor = Color.Green;
                int count = Count_Surrounding_Mines(index, row, col);
                tiklananButton.Text = count.ToString();
            }
        }
    }
}
