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
        private int _selected; // indexul piesei selectate
        private PlayerType _currentPlayer; // om sau calculator
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
            _selected = -1; // nicio piesa selectata

            this.ClientSize = new System.Drawing.Size(360, 385);
            this.pictureBoxBoard.Size = new System.Drawing.Size(500, 500);

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

            int mouseY = e.X / 120;
            int mouseX = e.Y / 120;

            int [,] x=_board.getBoardValues();
            if (x[mouseX, mouseY] == 0)
            {
                _board.MakeMove(1, new Position(mouseX, mouseY));
                Console.WriteLine("---------------------------------\n\n\n\n\n");
                _board.printBoard();
                _board.printStatus();
                if(_board.CheckFinish()==Board.IN_PROGRESS)
                    ComputerMove();
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
            _board.printBoard();
            _board.printStatus();

        }

        private void jocNouToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            _board = new Board();
            _currentPlayer = PlayerType.Om;
           
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
    }
}
