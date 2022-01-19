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

        public static double calculUpperConf(int totalVisit, double nodeWinScore, int nodeVisit)
        {
            if (nodeVisit == 0)
            {
                return double.MaxValue;
            }
            return (nodeWinScore / (double)nodeVisit) + 1.41 * Math.Sqrt(Math.Log(totalVisit) / (double)nodeVisit);
        }

        public static Nod findNodMaxim(Nod node)
        {
            int parentVisit = node.getState().getVisitCount();
            Nod max = null;
            foreach (Nod c in node.getFrunze())
            {
                if (max == null)
                {
                    max = c;
                }
                else
                {
                    if (calculUpperConf(parentVisit, c.getState().getWinScore(), c.getState().getVisitCount()) > calculUpperConf(parentVisit, max.getState().getWinScore(), max.getState().getVisitCount()))
                    {
                        max = c;
                    }
                }
            }
            return max;
        }

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

        public int getTimeoutLevel()
        {
            return 2 * (this.level - 1) + 1;
        }

        public Board findNextMove(Board board, int playerNr)
        {
            long start = (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
            long end = start + 10 * getTimeoutLevel();

            opponent = 3 - playerNr;
            Arbore tree = new Arbore();
            Nod rootNode = tree.getRadacina();
            rootNode.getState().SetBoard(board);
            rootNode.getState().setPlayerNr(opponent);

            while ((long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds < end)
            {
                Nod promisingNode = selectNodSansa(rootNode);
                if (promisingNode.getState().GetBoard().CheckFinish() == Board.IN_PROGRESS)
                    expandeazaNod(promisingNode);

                Nod nodExplorat = promisingNode;
                if (promisingNode.getFrunze().Count > 0)
                {
                    nodExplorat = promisingNode.getFrunzaRandom();
                }
                int rezultat = simuleazaJoc(nodExplorat);

                backPropogation(nodExplorat, rezultat);
            }

            Nod nodAles = rootNode.getFrunzaMax();
            tree.setRadacina(nodAles);
            return nodAles.getState().GetBoard();
        }

        public Nod selectNodSansa(Nod rootNode)
        {
            Nod node = rootNode;
            while (node.getFrunze().Count != 0)
            {
                node = MonteCarloTreeSearch.findNodMaxim(node);
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
                node.getFrunze().Add(newNode);
            };
        }

        public void backPropogation(Nod nodExplorat, int playerNr)
        {
            Nod aux = nodExplorat;
            while (aux != null)
            {
                aux.getState().incrementVisit();
                if (aux.getState().getPlayerNr() == playerNr)
                    aux.getState().addScore(WIN_SCORE);
                aux = aux.getParinte();
            }
        }

        public int simuleazaJoc(Nod node)
        {
            Nod nodAux = new Nod(node);
            State stateAux = nodAux.getState();
            int boardStatus = stateAux.GetBoard().CheckFinish();

            if (boardStatus == opponent)
            {
                nodAux.getParinte().getState().setWinScore(double.MinValue);
                return boardStatus;
            }
            while (boardStatus == Board.IN_PROGRESS)
            {
                stateAux.TogglePlayer();
                stateAux.RandomPlay();
                boardStatus = stateAux.GetBoard().CheckFinish();
            }

            return boardStatus;
        }

    }

}
