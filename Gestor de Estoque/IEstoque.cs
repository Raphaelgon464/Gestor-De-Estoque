﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gestor_de_Estoque
{

    internal interface IEstoque
    {
        void Exibir();
        void AdiconarEntrada();
        void AdicionarSaida();

    }
}
