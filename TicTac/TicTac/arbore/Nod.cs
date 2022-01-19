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
            List<Nod> frunze = nod.getFrunze();
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

        public List<Nod> getFrunze() { return frunze; }

        public void setFrunze(List<Nod> leafs) { this.frunze = leafs; }

        public Nod getFrunzaRandom()
        {
            int nrMutari = this.frunze.Count;
            int indexRandom = (int)(new Random().Next(0,1) * nrMutari);
            return this.frunze[indexRandom];
        }


        public Nod getFrunzaMax()
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
