using System;
using System.Collections.Generic;
using System.Text;

abstract class Account : iAport
{//CLASSE ABSTRATA PARA *HERANCA*
    private List<Share> Wallet = new List<Share>();//CARTEIRA ATUAL
    protected double balance = 0.0;//SALDO
    protected User owner;//PROPRIETARIO DA CARTEIRA
    public Market market = new Market();//ACOES LISTADAS
    public List<double> notasB3 = new List<double>();//NOTAS ATRIBUIDAS AS ACOES BRASILEIRAS
    public List<double> notasSp500 = new List<double>();//NOTAS ATRIBUIDAS AS ACOES AMERICANAS

    public double conservador;//MEDIA DAS NOTAS CONSERVADORAS
    public double moderado;//MEDIA DAS NOTAS MODERADAS
    public double agressivo;//MEDIA DAS NOTAS AGRESSIVAS

    public Account(User owner)
    {
        this.owner = owner;//DONO
    }

    public void getWallet()//RETORNA A CARTEIRA ATUAL
    {
        for(int i = 0; i < this.Wallet.Count; i++)
        {
            Console.WriteLine("Ticker: {0} | Qtd: {1} |", this.Wallet[i].getTicker(),this.Wallet[i].qtd);
        }
    }

    public string GetOwner()//RETORNA O PROPRIETARIO
    {
        return this.owner.getName();
    }

    virtual public void getBalance() //RETORNA O SALDO
    {
        Console.WriteLine("Seu saldo atual é de: R$ {0}", this.balance);
    }

    protected abstract double Discount(double balance);//METODO ABASTRATO PARA SER IMPLEMENTADO DE ACORDO COM O TIPO DE CONTA *SOBRESCRITA*

    public void Deposit(double balance) //DEPOSITO
    {
        if(balance > 0)
        {
            balance = Discount(balance);
            this.balance += balance;
            //Console.WriteLine("Deposito realizado com sucesso!");
        } else
        {
            Console.WriteLine("Favor informar um valor válido!");
        }
    }

    public void TakeOut() //RETIRADA
    {
        this.balance = 0.0;
        Console.WriteLine("Dinheiro transferido com sucesso!");
    }

    public void TakeOut(bool liquidate)//RETIRADA E VENDA DE TODOS OS ATIVOS
    {
        if (liquidate)
        {
            this.Wallet = new List<Share>();
            this.balance = 0.0;
        }
    }

    public bool AportingQ(int qtd, string ticker)//IMPLEMENTACAO DA INTERFACE
    {
        double price = this.market.getItemB3(ticker);//RETORNA O PRECO DO ATIVO

        if (price > 0)//CASO NAO DE ERRO
        {
            if(this.balance >= price * qtd)//CASO EXISTA SALDO ELE EFETUA A COMPRA
            {
                this.balance -= price * qtd;
                //Console.WriteLine("Aporte efetuado com sucesso!");
                string risco = this.market.getRiscoB3(ticker);
                this.Wallet.Add(new Share(true, ticker, price, risco,qtd));
                return true;
            } else
            {
                Console.WriteLine("Você não possui saldo suficiente!");
            }

        } else
        {//MESMO PROCESSO MAS EXECUTANDO NA BOLSA AMERICANA
            price = this.market.getItemSp500(ticker);
            if(price > 0)
            {
                if (this.balance >= price * qtd)
                {
                    this.balance -= price * qtd;
                    //Console.WriteLine("Aporte efetuado com sucesso!");
                    string risco = this.market.getRiscoSp500(ticker);
                    this.Wallet.Add(new Share(false,ticker,price, risco));
                    return true;
                }
                else
                {
                    Console.WriteLine("Você não possui saldo suficiente!");
                }
            }
            
        }
        return false;
    }


    public bool SouldindQ(int qtd, string ticker)
    {//VENDENDO ACOES
        for (int i = 0; i < this.Wallet.Count; i++)
        {//PERCORRE A CARTEIRA ATUAL
            if (((this.Wallet[i].qtd) - qtd) > 0)
            {
                this.Wallet[i].qtd -= qtd;
                return true;
            } else if ((this.Wallet[i].qtd - qtd) == 0)
            {
                List<Share> wallet = new List<Share>();
                for(int j = 0;j< this.Wallet.Count; j++){
                    if(i != j)
                    {
                        wallet.Add(this.Wallet[j]);
                    }
                }
                this.Wallet = wallet;
                return true;
            } else
            {
                Console.WriteLine("Você não possui o ativo em questão!");
            }
        }
        return false;
    }

    public void avaliaMercado(List<double> notas)//*SOBRECARGA*
    {//METODO QUE FARA O A GESTAO DE RISCO DO USUARIO
        for(int i = 0;i < 5; i++)
        {
            this.notasB3.Add(notas[i]);
        }

        for (int i = 0; i < 5; i++)
        {
            this.notasSp500.Add(notas[i + 5]);
        }

        calcularValores();
    }

    public void avaliaMercado()//*SOBRECARGA*
    {//METODO QUE FARA O A GESTAO DE RISCO DO USUARIO
        bool valid = false;

        for(int i = 0;i < this.market.b3.Count; i++)
        {
            valid = false;
            while (!valid)
            {
                Console.WriteLine("Digite uma nota entre 0 e 5 para o seu nível de aceitação quanto ao risco do fundo:");
                Console.WriteLine("Ticker: {0} | Risco: {1}",this.market.b3[i].getTicker(), this.market.b3[i].risco);
                try
                {
                    double avaliacao = double.Parse(Console.ReadLine());
                    if(avaliacao >= 0 && avaliacao <= 5)
                    {
                        this.notasB3.Add(avaliacao);
                        valid = true;
                    } else
                    {
                        valid = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro! {0}",e);
                    valid = false;
                }
            }
        }

        valid = false;

        for (int i = 0; i < this.market.sp500.Count; i++)
        {
            valid = false;
            while (!valid)
            {
                Console.WriteLine("Digite uma nota entre 0 e 5 para o seu nível de aceitação quanto ao risco do fundo:");
                Console.WriteLine("Ticker: {0} | Risco: {1}", this.market.sp500[i].getTicker(), this.market.sp500[i].risco);
                try
                {
                    double avaliacao = double.Parse(Console.ReadLine());
                    if (avaliacao >= 0 && avaliacao <= 5)
                    {
                        this.notasSp500.Add(avaliacao);
                        valid = true;
                    }
                    else
                    {
                        valid = false;
                    }
                }
                catch (Exception)
                {
                    valid = false;
                }
            }
        }
        calcularValores();
    }
    private void calcularValores()
    {//METODO QUE FARA O CALCULO DAS MEDIAS DAS RESPOSTAS
        int qtdC = 0;
        double somaC = 0;

        int qtdM = 0;
        double somaM = 0;

        int qtdA = 0;
        double somaA = 0;

        for (int j = 0;j < this.market.b3.Count; j++)
        {
            if(this.market.b3[j].risco == "Agressivo")
            {
                qtdA++;
                somaA += this.notasB3[j];
            } else if(this.market.b3[j].risco == "Moderado")
            {
                qtdM++;
                somaM += this.notasB3[j];
            } else
            {
                qtdC++;
                somaC += this.notasB3[j];
            }
        }

        for (int j = 0; j < this.market.sp500.Count; j++)
        {
            if (this.market.sp500[j].risco == "Agressivo")
            {
                qtdA++;
                somaA += this.notasSp500[j];
            }
            else if (this.market.sp500[j].risco == "Moderado")
            {
                qtdM++;
                somaM += this.notasSp500[j];
            }
            else
            {
                qtdC++;
                somaC += this.notasSp500[j];
            }
        }

        this.conservador = somaC / qtdC;
        this.moderado = somaM / qtdM;
        this.agressivo = somaA / qtdA;
    }
}

