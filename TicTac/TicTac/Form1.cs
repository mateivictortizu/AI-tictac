using System;
using System.Drawing;
using System.Windows.Forms;
using TicTac.xo;
using TicTac.arbore;
using TicTac.mcts;

namespace TicTac
{
    public partial class Form1 : Form
    {

        private Board _board;
        private PlayerType _currentPlayer;
        private Bitmap _boardImage;

        public Form1()
        {
            InitializeComponent();

            try
            {
                _boardImage = (Bitmap)Image.FromFile("board.png");
            }
            catch
            {
                MessageBox.Show("Nu se poate incarca board.png");
                Environment.Exit(1);
            }

            _board = new Board();
            _currentPlayer = PlayerType.None;

            this.ClientSize = new Size(360, 385);
            this.pictureBoxBoard.Size = new Size(500, 500);

            pictureBoxBoard.Refresh();
        }

        private void pictureBoxBoard_Paint(object sender, PaintEventArgs e)
        {
            Bitmap board = new Bitmap(_boardImage);
            e.Graphics.DrawImage(board, 0, 0);
           

            if (_board == null)
                return;
        }

        private void pictureBoxBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if (_currentPlayer != PlayerType.Om)
                return;

            if (_board.CheckFinish() != Board.IN_PROGRESS)
            {
                if(_board.CheckFinish()==Board.EGAL)
                    MessageBox.Show("Jocul s-a terminat egal!");
                else
                    MessageBox.Show("Jocul a fost castigat de playerul "+_board.CheckFinish());
                return;

            }

            int[,] x = _board.GetBoardValues();

            int mouseY = e.X / 120;
            int mouseX = e.Y / 120;

            if (x[mouseX, mouseY] == 0)
            {
                _board.MakeMove(1, new Position(mouseX, mouseY));
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (x[i, j] == 1) {
                            Graphics g = Graphics.FromImage(_boardImage);
                            Pen xPen = new Pen(Color.Red, 5);
                            int xAbs = j * 120;
                            int yAbs = i * 120;


                            g.DrawLine(xPen, xAbs, yAbs, xAbs + 120, yAbs + 120);
                            g.DrawLine(xPen, xAbs + 120, yAbs, xAbs, yAbs + 120);
                            pictureBoxBoard.Image = _boardImage;
                            g.Dispose();
                        }
                        if (x[i, j] == 2)
                        {
                            Graphics g = Graphics.FromImage(_boardImage);
                            Pen oPen = new Pen(Color.Black, 5);
                            int xAbs = j * 125;
                            int yAbs = i * 125;
                            g.DrawEllipse(oPen, xAbs + 10, yAbs + 10, 90, 90);
                            pictureBoxBoard.Image = _boardImage;
                            g.Dispose();
                        }
                    }
                }

                if (_board.CheckFinish() == Board.IN_PROGRESS)
                {
                    ComputerMove();

                }
                else
                {
                    if (_board.CheckFinish() == Board.EGAL)
                        MessageBox.Show("Jocul s-a terminat egal!");
                    else
                        MessageBox.Show("Jocul a fost castigat de playerul " + _board.CheckFinish());
                    return;

                }
            }
            else
            {
                Console.WriteLine("Casuta este deja ocupata");
            }
        }


        private void ComputerMove()
        {
            MonteCarloTreeSearch mcts = new MonteCarloTreeSearch();
            if (this.usorToolStripMenuItem.Checked == true)
                mcts.setLevel(1);
            _board=mcts.findNextMove(_board, 2);
            int[,] x = _board.GetBoardValues();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (x[i, j] == 1)
                    {
                        Graphics g = Graphics.FromImage(_boardImage);
                        Pen xPen = new Pen(Color.Red, 5);
                        //g.DrawLine(xPen, i, j, i + 125, j + 125);
                        //g.DrawLine(xPen, i+ 125, j, i, j + 125);
                        int xAbs = j * 120;
                        int yAbs = i * 120;


                        g.DrawLine(xPen, xAbs, yAbs, xAbs + 120, yAbs + 120);
                        g.DrawLine(xPen, xAbs + 120, yAbs, xAbs, yAbs + 120);
                        pictureBoxBoard.Image = _boardImage;
                        g.Dispose();
                    }
                    if (x[i, j] == 2)
                    {
                        Graphics g = Graphics.FromImage(_boardImage);
                        Pen oPen = new Pen(Color.Black, 5);
                        int xAbs = j * 125;
                        int yAbs = i * 125;
                        g.DrawEllipse(oPen, xAbs + 10, yAbs + 10, 90, 90);
                        pictureBoxBoard.Image = _boardImage;
                        g.Dispose();
                    }
                }
            }
            if (_board.CheckFinish() != Board.IN_PROGRESS)
            {
                if (_board.CheckFinish() == Board.EGAL)
                    MessageBox.Show("Jocul s-a terminat egal!");
                else
                    MessageBox.Show("Jocul a fost castigat de playerul " + _board.CheckFinish());
                return;

            }

        }

        private void jocNouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _board = new Board();
            _currentPlayer = PlayerType.Om;
            _boardImage = (Bitmap)Image.FromFile("board.png");
            pictureBoxBoard.Image = _boardImage;


        }

        private void greuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.greuToolStripMenuItem.Checked = true;
            this.usorToolStripMenuItem.Checked = false;
        }

        private void usorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.greuToolStripMenuItem.Checked = false;
            this.usorToolStripMenuItem.Checked = true;
        }

        private void pictureBoxBoard_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
