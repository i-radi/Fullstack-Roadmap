using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SnakeAndLadder
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
            for (int i = 0; i<4; i++)
            {
                _p[i] = new Player();
                _p[i].PlayOrder = i;
                _p[i].IsActive = i < 2;
            }
        }

        public class Player
        {
            public int Location = 1;
            public int PlayOrder;
            public bool IsActive;

            public Point CalcTokenLocation()
            {
                return new Point(
                    ((Location-1)%10)*60+5+30*(PlayOrder%2),
                    575-((Location-1)/10)*60-30*(PlayOrder/2));
            }
        }

        Player[] _p = new Player[4];
        Point[] _tokenLoc = new Point[4];
        bool _gameOngoing;
        Image _gameBoard = Image.FromFile(Environment.CurrentDirectory + "\\gameboard.jpg");
        List<int> _playerTurn = new List<int>();

        private void MainScreen_Paint(object sender, PaintEventArgs e)
        {
            if (_gameOngoing)
            {
                Brush[] playerColor = { Brushes.Blue, Brushes.Red, Brushes.Green, Brushes.Gold };
                for (int i = 0; i < 4; i++)
                {
                    _tokenLoc[i] = _p[i].CalcTokenLocation();
                }

                Pen gridLine = new Pen(Brushes.Black, 1);
                Pen indicator = new Pen(Brushes.Black, 3);
                int bottom = Height - 23;

                e.Graphics.DrawImage(_gameBoard, 0, 0, 600, 600);
                int tokenSize = 20;
                for (byte i = 1; i <= 10; i++)
                {
                    e.Graphics.DrawLine(gridLine, 60 * i, 0, 60 * i, bottom);
                    e.Graphics.DrawLine(gridLine, 0, 60 * i, Width, 60 * i);
                }
                for (int i = 0; i < 4; i++)
                {
                    if (_p[i].IsActive) e.Graphics.FillEllipse(playerColor[i], _tokenLoc[i].X, _tokenLoc[i].Y, tokenSize, tokenSize);
                    if (_playerTurn.Count>0 && i == _playerTurn[0]) e.Graphics.DrawEllipse(indicator, _tokenLoc[i].X, _tokenLoc[i].Y, tokenSize, tokenSize);
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            _gameOngoing = true;
            Height = 710; //642 without buttons at bottom
            Width = 618;
            for (int i = 0; i < 4; i++)
            {
                if(i < nudPlayerCount.Value)
                {
                    _p[i].IsActive = true;
                    _playerTurn.Add(i);
                }
                else
                {
                    _p[i].IsActive = false;
                }
            }
            Random random = new Random();
            _playerTurn = _playerTurn.OrderBy(x => random.Next()).ToList();
            lblTurnIndicator.Text = @"It's Player " + (_playerTurn[0] + 1) + @"'s turn";
            lblPlayerCount.Hide();
            nudPlayerCount.Hide();
            btnPlay.Hide();
            Refresh();            
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            GC.Collect();
            _gameOngoing = false;
            Height = 71;
            Width = 234;
            btnRollDice.Enabled = true;
            btnRollDice.Text = @"Roll Dice
0";
            lblPlayerCount.Show();
            nudPlayerCount.Show();
            btnPlay.Show();
            Refresh();
            foreach (Player player in _p)
            {
                if (player.IsActive) player.Location = 1;
            }
            _playerTurn = new List<int>();
        }

        int _movesLeft;

        Dictionary<int, int> _snakePoint = new Dictionary<int, int> {
            { 25, 5 },
            { 34, 1 },
            { 47, 19 },
            { 65, 52 },
            { 87, 57 },
            { 91, 61 },
            { 99, 69 } };

        Dictionary<int, int> _ladderPoint = new Dictionary<int, int> {
            { 3, 51 },
            { 6, 27 },
            { 20, 70 },
            { 36, 55 },
            { 63, 95 },
            { 68, 98 } };

        bool _hasOverflow;
        private void tmrTurnCounter_Tick(object sender, EventArgs e)
        {
            if (_movesLeft == 0)
            {
                if (_p[_playerTurn[0]].Location == 100)
                {
                    lblTurnIndicator.Text = @"Player " + (_playerTurn[0] + 1) + @" wins";
                    tmrTurnCounter.Stop();
                }
                else if (_snakePoint.ContainsKey(_p[_playerTurn[0]].Location))
                {
                    _p[_playerTurn[0]].Location = _snakePoint[_p[_playerTurn[0]].Location];
                }
                else if (_ladderPoint.ContainsKey(_p[_playerTurn[0]].Location))
                {
                    _p[_playerTurn[0]].Location = _ladderPoint[_p[_playerTurn[0]].Location];
                }
                else
                {
                    tmrTurnCounter.Stop();
                    _playerTurn.Add(_playerTurn[0]);
                    _playerTurn.RemoveAt(0);
                    btnRollDice.Enabled = true;
                    lblTurnIndicator.Text = @"It's Player " + (_playerTurn[0] + 1) + @"'s turn";
                }                
                _hasOverflow = false;
            }
            else
            {
                if (_p[_playerTurn[0]].Location==100 && _movesLeft > 0)
                {
                    _hasOverflow = true;
                }
                _p[_playerTurn[0]].Location += _hasOverflow ? -1 : 1;
                _movesLeft--;
            }
            Invalidate();
        }
        private void btnRollDice_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            _movesLeft = random.Next(1, 7);
            btnRollDice.Text = @"Roll Dice 
" + _movesLeft;
            btnRollDice.Enabled = false;
            lblTurnIndicator.Text = @"Player " + (_playerTurn[0] + 1) + @" is moving";
            tmrTurnCounter.Start();
        }
    }
}
