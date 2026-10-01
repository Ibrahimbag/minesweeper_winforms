using System.Data.Common;
using System.Diagnostics;
using System.Numerics;
using System.Windows.Forms; // Ensure this is present for Timer

namespace WinFormsApp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int height = 9, width = 9;
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

            txtY.Text = height.ToString();
            txtX.Text = width.ToString();
            txtMinesCount.Text = mine_count.ToString();

            Add_Buttons();
        }

        private void Add_Buttons()
        {
            int y = (ClientSize.Height - height * 24) / 2;

            if (y < 100)
            {
                y = 100;
            }

            int count = 0;

            for (int i = 0; i < height; i++)
            {
                int x = (ClientSize.Width - width * 24) / 2;
                for (int j = 0; j < width; j++)
                {
                    Button btn = new Button();
                    btn.Name = "" + count;
                    btn.Text = "";
                    btn.Location = new Point(x, y);
                    btn.Size = new Size(24, 24);
                    btn.MouseDown += Button_Click;
                    btn.MouseCaptureChanged += Button_Capture;
                    btn.Tag = "Dynamic";
                    Controls.Add(btn);
                    x = x + 24;
                    count++;
                }
                y += 24;
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
        Image smiley1_image = Image.FromFile("../../../assets/smiley1.png");
        Image smiley2_image = Image.FromFile("../../../assets/smiley2.png");
        Image smiley3_image = Image.FromFile("../../../assets/smiley3.png");
        bool game_started = false;
        bool game_over = false;

        private void Button_Click(object sender, MouseEventArgs e)
        {
            if (game_over)
            {
                return;
            }

            if (!game_started)
            {
                // --- SETUP AND START THE TIMER ---
                TimeLabel.Text = "000"; // Initial display
                gameTimer = new System.Windows.Forms.Timer();
                gameTimer.Interval = 1000; // 1000 milliseconds = 1 second
                gameTimer.Tick += GameTimer_Tick;
                gameTimer.Start();
                game_started = true;
            }

            Button tiklananButton = (Button)sender;

            SmileyButton.Image = smiley2_image;

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

                    SmileyButton.Image = smiley3_image;

                    game_over = true;

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
                    tiklananButton.Font = new Font(tiklananButton.Font.FontFamily, 9.0f, tiklananButton.Font.Style);
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

        private void Button_Capture(object sender, EventArgs e)
        {
            if (!game_over)
            {
                SmileyButton.Image = smiley1_image;
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

        private void SmileyButton_Click(object sender, EventArgs e)
        {
            Restart_Game(sender, e);
        }

        private void Restart_Game(object sender, EventArgs e)
        {
            if (game_started)
            {
                gameTimer.Stop();
            }

            secondsPassed = 0;
            DeleteTaggedButtons(this);
            game_started = false;
            game_over = false;
            TimeLabel.Text = "000";
            minesLeftLabel.Text = "000";
            SmileyButton.Image = smiley1_image;
            flaggedTiles.Clear();

            Form1_Load(sender, e);
        }

        private void DeleteTaggedButtons(Control container)
        {
            for (int i = container.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = container.Controls[i];

                // Only delete it if it is a button marked with our Tag
                if (ctrl is Button && ctrl.Tag?.ToString() == "Dynamic")
                {
                    container.Controls.RemoveAt(i);
                    ctrl.Dispose();
                }
                else if (ctrl.HasChildren)
                {
                    DeleteTaggedButtons(ctrl);
                }
            }
        }

        private void btnDifficulty_MouseClick(object sender, MouseEventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (clickedButton.Name == "btnEasy")
            {
                height = 9;
                width = 9;
                mine_count = 10;
            }
            else if (clickedButton.Name == "btnMedium")
            {
                height = 16;
                width = 16;
                mine_count = 40;
            }
            else if (clickedButton.Name == "btnHard")
            {
                height = 16;
                width = 30;
                mine_count = 99;
            }
            else
            {
                height = int.Parse(txtY.Text);
                width = int.Parse(txtX.Text);
                mine_count = int.Parse(txtMinesCount.Text);
            }

            Restart_Game(sender, e);
        }
    }
}
