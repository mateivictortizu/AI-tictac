﻿namespace TicTac.arbore
{
    class Arbore
    {
        Nod radacina;

        public Arbore()
        {
            radacina = new Nod();
        }

        public Arbore(Nod radacina)
        {
            this.radacina = radacina;
        }

        public Nod getRadacina()
        {
            return radacina;
        }

        public void setRadacina(Nod radacina)
        {
            this.radacina = radacina;
        }

        public void addFrunza(Nod parinte, Nod frunza)
        {
            parinte.getFrunze().Add(frunza);
        }

    }
}
