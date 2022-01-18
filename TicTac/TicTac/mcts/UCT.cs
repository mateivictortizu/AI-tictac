using System;
using TicTac.arbore;

namespace TicTac.mcts
{
    class UCT
    {
        public static double uctValue(int totalVisit, double nodeWinScore, int nodeVisit)
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
            foreach(Nod c in node.getChildArray())
            {
                if (max == null)
                {
                    max = c;
                }
                else
                {
                    if (uctValue(parentVisit, c.getState().getWinScore(), c.getState().getVisitCount()) > uctValue(parentVisit, max.getState().getWinScore(), max.getState().getVisitCount()))
                    {
                        max = c;
                    }
                }
            }
            return max;
        }
    }
}
