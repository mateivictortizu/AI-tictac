using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTac.xo
{
    class Board
    {
        int[,] boardValues;
        int totalMoves;

        public static int DIMENSIUNE_TABLA = 3;

        public const int IN_PROGRESS = -1, EGAL = 0, PLAYER1 = 1, PLAYER2 = 2;

        public Board()
        {
            boardValues = new int[DIMENSIUNE_TABLA, DIMENSIUNE_TABLA];
        }

        public Board(int boardSize)
        {
            boardValues = new int[boardSize, boardSize];
        }

        public Board(int[,] boardValues)
        {
            this.boardValues = boardValues;
        }

        public Board(int[,] boardValues, int totalMoves)
        {
            this.boardValues = boardValues;
            this.totalMoves = totalMoves;
        }

        public Board(Board board)
        {
            int boardLength = (int)Math.Sqrt(board.GetBoardValues().Length);
            this.boardValues = new int[boardLength,boardLength];
            int[,] boardValues = board.GetBoardValues();
            int n = (int) Math.Sqrt(boardValues.Length);
            for (int i = 0; i < n; i++)
            {
                int m = boardValues.GetLength(1);
                for (int j = 0; j < m; j++)
                {
                    this.boardValues[i,j] = boardValues[i,j];
                }
            }
        }

        public void MakeMove(int player, Position p)
        {
            this.totalMoves++;
            boardValues[p.getX(),p.getY()] = player;
        }

        public int[,] GetBoardValues()
        {
            return boardValues;
        }

        public void SetBoardValues(int[,] boardValues)
        {
            this.boardValues = boardValues;
        }

        public int CheckFinish()
        {
            int boardSize = (int) Math.Sqrt(boardValues.Length);
            int maxIndex = boardSize - 1;
            int[] diag1 = new int[boardSize];
            int[] diag2 = new int[boardSize];

            for (int i = 0; i < boardSize; i++)
            {
                int[] row = Enumerable.Range(0, boardValues.GetLength(1)).Select(x => boardValues[i, x]).ToArray(); 
                int[] col = new int[boardSize];
                for (int j = 0; j < boardSize; j++)
                {
                    col[j] = boardValues[j,i];
                }

                int checkRowForWin = CheckForWin(row);
                if (checkRowForWin != 0)
                    return checkRowForWin;

                int checkColForWin = CheckForWin(col);
                if (checkColForWin != 0)
                    return checkColForWin;

                diag1[i] = boardValues[i,i];
                diag2[i] = boardValues[maxIndex - i,i];
            }

            int checkDia1gForWin = CheckForWin(diag1);
            if (checkDia1gForWin != 0)
                return checkDia1gForWin;

            int checkDiag2ForWin = CheckForWin(diag2);
            if (checkDiag2ForWin != 0)
                return checkDiag2ForWin;

            if (GetPozitiiLibere().Count > 0)
                return IN_PROGRESS;
            else
                return EGAL;
        }

        public int CheckForWin(int[] row)
        {
            bool isEqual = true;
            int size = row.Length;
            int previous = row[0];
            for (int i = 0; i < size; i++)
            {
                if (previous != row[i])
                {
                    isEqual = false;
                    break;
                }
                previous = row[i];
            }
            if (isEqual)
                return previous;
            else
                return 0;
        }

        public List<Position> GetPozitiiLibere()
        {
            int size = (int) Math.Sqrt(this.boardValues.Length);
            List<Position> emptyPositions = new List<Position>();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (boardValues[i,j] == 0)
                        emptyPositions.Add(new Position(i, j));
                }
            }
            return emptyPositions;
        }

    }
}
