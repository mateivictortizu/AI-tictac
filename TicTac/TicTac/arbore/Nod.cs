using System;
using System.Collections.Generic;

using TicTac.mcts;

namespace TicTac.arbore
{
    public enum PlayerType { None, Computer, Om };
    class Nod
    {
        public State state;
        public Nod parinte;
        public List<Nod> frunze;

        public Nod()
        {
            this.state = new State();
            this.frunze = new List<Nod>();
        }

        public Nod(State state)
        {
            this.state = state;
            frunze = new List<Nod>();
        }

        public Nod(State state, Nod parinte, List<Nod> copii)
        {
            this.state = state;
            this.parinte = parinte;
            this.frunze = copii;
        }

        public Nod(Nod nod)
        {
            this.frunze = new List<Nod>();
            this.state = new State(nod.getState());
            if (nod.getParinte() != null)
            {
                this.parinte = nod.getParinte();
            }
            List<Nod> frunze = nod.getChildArray();
            foreach(Nod frunza in frunze)
            {
                this.frunze.Add(new Nod(frunza));
            }
        }

        public State getState() { return state; }

        public void setState(State state)
        {
            this.state = state;
        }

        public Nod getParinte() { return parinte; }

        public void setParinte(Nod parent) { this.parinte = parent; }

        public List<Nod> getChildArray() { return frunze; }

        public void setChildArray(List<Nod> childArray) { this.frunze = childArray; }

        public Nod getRandomChildNode()
        {
            int noOfPossibleMoves = this.frunze.Count;
            int selectRandom = (int)(new Random().Next(0,1) * noOfPossibleMoves);
            return this.frunze[selectRandom];
        }


        public Nod getChildWithMaxScore()
        {
            Nod max = null;
            foreach( Nod c in frunze)
            {
                if(max==null)
                {
                    max = c;
                }
                else
                {
                    if(c.getState().getVisitCount()>max.getState().getVisitCount())
                    {
                        max = c;
                    }
                }
            }
            return max;
        }
    }
}
