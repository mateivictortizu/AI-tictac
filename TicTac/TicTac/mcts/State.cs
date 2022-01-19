using System;
using System.Collections.Generic;

using TicTac.xo;

namespace TicTac.mcts
{
    class State
    {
        private Board board;
        private int playerNr, visitCount;
        private double winScore;

        public State()
        {
            board = new Board();
        }

        public State(State state)
        {
            this.board = new Board(state.GetBoard());
            this.playerNr = state.getPlayerNr();
            this.visitCount = state.getVisitCount();
            this.winScore = state.getWinScore();
        }

        public State(Board board)
        {
            this.board = new Board(board);
        }

        public Board GetBoard()
        {
            return board;
        }

        public void SetBoard(Board board)
        {
            this.board = board;
        }

        public int getPlayerNr()
        {
            return playerNr;
        }

        public void setPlayerNr(int playerNr)
        {
            this.playerNr = playerNr;
        }

        public int getOpponent()
        {
            return 3 - playerNr;
        }

        public int getVisitCount()
        {
            return visitCount;
        }

        public void setVisitCount(int visitCount)
        {
            this.visitCount = visitCount;
        }

        public double getWinScore()
        {
            return winScore;
        }

        public void setWinScore(double winScore)
        {
            this.winScore = winScore;
        }

        public List<State> getAllPosiblStates()
        {
            List<State> stariPosibile = new List<State>();
            List<Position> mutariDisponibile = this.board.GetPozitiiLibere();
            foreach(Position p in mutariDisponibile) {
                State newState = new State(this.board);
                newState.setPlayerNr(this.getOpponent());
                newState.GetBoard().MakeMove(newState.getPlayerNr(), p);
                stariPosibile.Add(newState);
            };
            return stariPosibile;
        }

        public void incrementVisit()
        {
            this.visitCount = this.visitCount + 1;
        }

        public void addScore(double score)
        {
            if (this.winScore != double.MinValue)
                this.winScore += score;
        }

        public void RandomPlay()
        {
            List<Position> availablePositions = this.board.GetPozitiiLibere();
            this.board.MakeMove(this.playerNr, availablePositions[(int)(new Random().Next(0, 1) * availablePositions.Count)]);
        }

        public void TogglePlayer()
        {
            this.playerNr = 3 - this.playerNr;
        }
    }
}
