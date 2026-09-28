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

        private void init_minefield()
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
            init_minefield();

            int y = 200;
            int count = 0;

            for (int i = 0; i < height; i++)
            {
                int x = 300;
                for (int j = 0; j < width; j++)
                {
                    Button btn = new Button();
                    btn.Name = "" + count;
                    btn.Text = "";
                    btn.Location = new Point(x, y);
                    btn.Size = new Size(20, 20);
                    btn.Click += Button_Click;
                    Controls.Add(btn);
                    x = x + 20;
                    count++;
                }
                y += 20;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button tiklananButton = (Button)sender;
            int index = int.Parse(tiklananButton.Name);

            int row = index / width;
            int column = index % width;

            if (minefield[row, column] == true)
            {
                tiklananButton.BackColor = Color.Red;
                MessageBox.Show("Mayýna bastýnýz");
            }
            else
            {
                tiklananButton.BackColor = Color.Green;
            }
        }
    }
}
