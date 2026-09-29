using System.Data.Common;
using System.Diagnostics;
using System.Windows.Forms; // Ensure this is present for Timer

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
        private List<Point> flaggedTiles = new();
        bool[,] minefield;

        // --- NEW VARIABLES FOR TIMER ---
        private System.Windows.Forms.Timer gameTimer;
        private int secondsPassed = 0;

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

            // --- SETUP AND START THE TIMER ---
            TimeLabel.Text = "000"; // Initial display
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 1000; // 1000 milliseconds = 1 second
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

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
                    btn.MouseDown += Button_Click;
                    Controls.Add(btn);
                    x = x + 50;
                    count++;
                }
                y += 50;
            }
        }

        // --- NEW TICK EVENT HANDLER ---
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            secondsPassed++;

            // Keeps it capped at 999 max just like classic Minesweeper
            if (secondsPassed > 999)
            {
                secondsPassed = 999;
                gameTimer.Stop();
            }

            TimeLabel.Text = $"{secondsPassed:D3}";
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

        Image mine_image = Image.FromFile("../../../assets/mine.png");
        Image flag_image = Image.FromFile("../../../assets/flag.png");

        private void Button_Click(object sender, MouseEventArgs e)
        {
            Button tiklananButton = (Button)sender;

            int index = int.Parse(tiklananButton.Name);
            int row = index / width;
            int col = index % width;

            if (e.Button == MouseButtons.Right)
            {
                Flag_Tile(tiklananButton, row, col);
            }
            else if (e.Button == MouseButtons.Left && !flaggedTiles.Contains(new Point(col, row)))
            {
                if (minefield[row, col] == true)
                {
                    tiklananButton.BackColor = Color.Red;
                    tiklananButton.Image = mine_image;

                    // --- STOP TIMER ON GAME OVER ---
                    gameTimer.Stop();
                }
                else
                {
                    Color[] colors =
                    [
                        Color.Blue,
                        Color.Green,
                        Color.Red,
                        Color.Magenta,
                        Color.DarkRed,
                        Color.Teal,
                        Color.Black,
                        Color.Gray,
                    ];

                    int count = Count_Surrounding_Mines(index, row, col);

                    tiklananButton.Text = count.ToString();
                    tiklananButton.Font = new Font(tiklananButton.Font.FontFamily, 20.0f, tiklananButton.Font.Style);
                    tiklananButton.BackColor = Color.LightGray;

                    if (count == 0)
                    {
                        tiklananButton.ForeColor = tiklananButton.BackColor;
                    }

                    if (count > 0)
                    {
                        tiklananButton.ForeColor = colors[count - 1];
                    }
                }
            }

            int minesLeft = mine_count - flaggedTiles.Count;
            if (minesLeft >= 0)
            {
                minesLeftLabel.Text = $"{minesLeft:D3}";
            }
            else
            {
                minesLeftLabel.Text = $"{minesLeft:D2}";
            }
        }

        private void Flag_Tile(Button tiklananButton, int row, int col)
        {
            if (tiklananButton.Text != "" || tiklananButton.Image == mine_image)
            {
                return;
            }

            if (flaggedTiles.Contains(new Point(col, row)))
            {
                flaggedTiles.Remove(new Point(col, row));
                tiklananButton.Image = null;
            }
            else
            {
                flaggedTiles.Add(new Point(col, row));
                tiklananButton.Image = flag_image;
            }
        }
    }
}
