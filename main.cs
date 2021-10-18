using System;
using System.Collections.Generic;

class Program
  {
    static void Main(string[] args)
    {//EXECUCAO DOS TESTE
        User conservador = new User("cons", "12345678");
        User moderado = new User("mod", "12345678");
        User arrojado = new User("arroj", "12345678");
        User novo = new User("novo", "12345678");
        //USUARIOS PARA TESTE

        Brazilian consBrazilian = new Brazilian(conservador);
        Brazilian modBrazilian = new Brazilian(moderado);
        Brazilian arrojBrazilian = new Brazilian(arrojado);
        Brazilian novoBrazilian = new Brazilian(novo);
        //CRIACAO SOMENTE DAS CARTEIRAS BRASILEIRAS PARA EXECUCAO DOS TESTES

        List<double> notasCons = new List<double>();
        List<double> notasMod = new List<double>();
        List<double> notasArroj = new List<double>();
        //LISTAS DE NOTAS QUE SERÃO ATRIBUIDAS

        notasCons.Add(0);
        notasCons.Add(0);
        notasCons.Add(5);
        notasCons.Add(3);
        notasCons.Add(5);
        notasCons.Add(3);
        notasCons.Add(5);
        notasCons.Add(5);
        notasCons.Add(0);
        notasCons.Add(0);
        //ATRIBUICAO DE NOTAS
        notasMod.Add(2);
        notasMod.Add(2);
        notasMod.Add(3);
        notasMod.Add(5);
        notasMod.Add(3);
        notasMod.Add(5);
        notasMod.Add(3);
        notasMod.Add(3);
        notasMod.Add(2);
        notasMod.Add(1);
        //ATRIBUICAO DE NOTAS
        notasArroj.Add(5);
        notasArroj.Add(5);
        notasArroj.Add(1);
        notasArroj.Add(2);
        notasArroj.Add(1);
        notasArroj.Add(3);
        notasArroj.Add(1);
        notasArroj.Add(1);
        notasArroj.Add(5);
        notasArroj.Add(5);
        //ATRIBUICAO DE NOTAS

        consBrazilian.avaliaMercado(notasCons);
        modBrazilian.avaliaMercado(notasMod);
        arrojBrazilian.avaliaMercado(notasArroj);
        //CALCULO DAS MEDIAS


        consBrazilian.Deposit(1500);
        modBrazilian.Deposit(1500);
        arrojBrazilian.Deposit(1500);
        //DEPOSITO

        consBrazilian.AportingQ(3, "HGLG11");
        consBrazilian.AportingQ(20, "MXRF11");
        consBrazilian.AportingQ(3, "BTLG11");
        //COMPRAS DE ACOES

        modBrazilian.AportingQ(50, "MXRF11");
        modBrazilian.AportingQ(2, "BTLG11");
        modBrazilian.AportingQ(1, "URPR11");
        //COMPRAS DE ACOES

        arrojBrazilian.AportingQ(20, "MXRF11");
        arrojBrazilian.AportingQ(2, "IRDM11");
        arrojBrazilian.AportingQ(3, "URPR11");
        //COMPRAS DE ACOES

        //Console.WriteLine();
        //
        //Console.WriteLine("Usuário: {3} | Médias [ Agressivo: {0}| Moderado: {1}| Conservador: {2} ]",consBrazilian.agressivo, consBrazilian.moderado,consBrazilian.conservador, consBrazilian.GetOwner());
        //Console.WriteLine("Usuário: {3} | Médias [ Agressivo: {0}| Moderado: {1}| Conservador: {2} ]", modBrazilian.agressivo, modBrazilian.moderado, modBrazilian.conservador, modBrazilian.GetOwner());
        //Console.WriteLine("Usuário: {3} | Médias [ Agressivo: {0}| Moderado: {1}| Conservador: {2} ]", arrojBrazilian.agressivo, arrojBrazilian.moderado, arrojBrazilian.conservador, arrojBrazilian.GetOwner());
        //Console.WriteLine();

        novoBrazilian.avaliaMercado();//CALCULO DE MEDIAS DO NOVO USUARIOS

        //Console.WriteLine("Usuário: {3} | Médias [ Agressivo: {0}| Moderado: {1}| Conservador: {2} ]", novoBrazilian.agressivo, novoBrazilian.moderado, novoBrazilian.conservador, novoBrazilian.GetOwner());

        double deConservador = Math.Sqrt(Math.Pow((consBrazilian.agressivo - novoBrazilian.agressivo),2) + Math.Pow((consBrazilian.moderado - novoBrazilian.moderado), 2) + Math.Pow((consBrazilian.conservador - novoBrazilian.conservador), 2));
        //CALCULO DAS DISTANCIAS EUCLIDIANAS

        double deModerado = Math.Sqrt(Math.Pow((modBrazilian.agressivo - novoBrazilian.agressivo), 2) + Math.Pow((modBrazilian.moderado - novoBrazilian.moderado), 2) + Math.Pow((modBrazilian.conservador - novoBrazilian.conservador), 2));
        //CALCULO DAS DISTANCIAS EUCLIDIANAS

        double deArrojado = Math.Sqrt(Math.Pow((arrojBrazilian.agressivo - novoBrazilian.agressivo), 2) + Math.Pow((arrojBrazilian.moderado - novoBrazilian.moderado), 2) + Math.Pow((arrojBrazilian.conservador - novoBrazilian.conservador), 2));
        //CALCULO DAS DISTANCIAS EUCLIDIANAS

        //Console.WriteLine("a{0} | m{1} | c{2}",deArrojado, deModerado, deConservador);

        if(deConservador <= deModerado && deConservador < deArrojado)//VALIDACAO DE PERFIL
        {
            Console.WriteLine("Você é conservador! Temos uma indicação de carteira para os seus primeiros R$ 1.500,00");
            consBrazilian.getWallet();
        } else if (deModerado <= deArrojado && deModerado < deConservador)
        {
            Console.WriteLine("Você é moderado! Temos uma indicação de carteira para os seus primeiros R$ 1.500,00");
            modBrazilian.getWallet();
        } else
        {
            Console.WriteLine("Seu perfil é agressivo! Temos uma indicação de carteira para os seus primeiros R$ 1.500,00");
            arrojBrazilian.getWallet();
        }
    }
}

