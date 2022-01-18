using System;
using System.Collections.Generic;
using TicTac.arbore;
using TicTac.xo;

namespace TicTac.mcts
{
    class MonteCarloTreeSearch
    {
        private static int WIN_SCORE = 10;
        private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private int level, opponent;

        public MonteCarloTreeSearch()
        {
            this.level = 3;
        }

        public int getLevel()
        {
            return level;
        }

        public void setLevel(int level)
        {
            this.level = level;
        }

        public int getMillisForCurrentLevel()
        {
            return 2 * (this.level - 1) + 1;
        }

        public Board findNextMove(Board board, int playerNo)
        {
            long start = (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
            long end = start + 60 * getMillisForCurrentLevel();

            opponent = 3 - playerNo;
            Arbore tree = new Arbore();
            Nod rootNode = tree.getRadacina();
            rootNode.getState().setBoard(board);
            rootNode.getState().setPlayerNr(opponent);

            while ((long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds < end)
            {
                Nod promisingNode = selectNodSansa(rootNode);
                if (promisingNode.getState().getBoard().CheckFinish() == Board.IN_PROGRESS)
                    expandeazaNod(promisingNode);

                Nod nodeToExplore = promisingNode;
                if (promisingNode.getChildArray().Count > 0)
                {
                    nodeToExplore = promisingNode.getRandomChildNode();
                }
                int playoutResult = simulateRandomPlayout(nodeToExplore);

                backPropogation(nodeToExplore, playoutResult);
            }

            Nod winnerNode = rootNode.getChildWithMaxScore();
            tree.setRoot(winnerNode);
            return winnerNode.getState().getBoard();
        }

        public Nod selectNodSansa(Nod rootNode)
        {
            Nod node = rootNode;
            while (node.getChildArray().Count != 0)
            {
                node = UCT.findNodMaxim(node);
            }
            return node;
        }

        public void expandeazaNod(Nod node)
        {
            List<State> stariPosibile = node.getState().getAllPosiblStates();
            foreach(State state in stariPosibile) {
                Nod newNode = new Nod(state);
                newNode.setParinte(node);
                newNode.getState().setPlayerNr(node.getState().getOpponent());
                node.getChildArray().Add(newNode);
            };
        }

        public void backPropogation(Nod nodExplorat, int playerNr)
        {
            Nod aux = nodExplorat;
            while (aux != null)
            {
                aux.getState().incrementVisit();
                if (aux.getState().getPlayerNo() == playerNr)
                    aux.getState().addScore(WIN_SCORE);
                aux = aux.getParinte();
            }
        }

        public int simulateRandomPlayout(Nod node)
        {
            Nod nodAux = new Nod(node);
            State stateAux = nodAux.getState();
            int boardStatus = stateAux.getBoard().CheckFinish();

            if (boardStatus == opponent)
            {
                nodAux.getParinte().getState().setWinScore(double.MinValue);
                return boardStatus;
            }
            while (boardStatus == Board.IN_PROGRESS)
            {
                stateAux.togglePlayer();
                stateAux.randomPlay();
                boardStatus = stateAux.getBoard().CheckFinish();
            }

            return boardStatus;
        }

    }

}
