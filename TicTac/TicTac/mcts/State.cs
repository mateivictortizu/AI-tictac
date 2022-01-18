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
            this.board = new Board(state.getBoard());
            this.playerNr = state.getPlayerNo();
            this.visitCount = state.getVisitCount();
            this.winScore = state.getWinScore();
        }

        public State(Board board)
        {
            this.board = new Board(board);
        }

        public Board getBoard()
        {
            return board;
        }

        public void setBoard(Board board)
        {
            this.board = board;
        }

        public int getPlayerNo()
        {
            return playerNr;
        }

        public void setPlayerNr(int playerNo)
        {
            this.playerNr = playerNo;
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
            List<State> possibleStates = new List<State>();
            List<Position> availablePositions = this.board.getEmptyPositions();
            foreach(Position p in availablePositions) {
                State newState = new State(this.board);
                newState.setPlayerNr(3 - this.playerNr);
                newState.getBoard().MakeMove(newState.getPlayerNo(), p);
                possibleStates.Add(newState);
            };
            return possibleStates;
        }

        public void incrementVisit()
        {
            this.visitCount++;
        }

        public void addScore(double score)
        {
            if (this.winScore != double.MinValue)
                this.winScore += score;
        }

        public void randomPlay()
        {
            List<Position> availablePositions = this.board.getEmptyPositions();
            int totalPossibilities = availablePositions.Count;
            int selectRandom = (int)(new Random().Next(0,1) * totalPossibilities);
            this.board.MakeMove(this.playerNr, availablePositions[selectRandom]);
        }

        public void togglePlayer()
        {
            this.playerNr = 3 - this.playerNr;
        }
    }
}
