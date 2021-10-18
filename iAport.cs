using System;
using System.Collections.Generic;
using System.Text;

interface iAport
{ //INTERFACE
  bool AportingQ(int qtd,string ticker);

  bool SouldindQ(int qtd, string ticker);
}
