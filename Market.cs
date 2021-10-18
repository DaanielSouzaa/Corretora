using System;
using System.Collections.Generic;
using System.Text;

class Market
{//INSERCAO DAS ACOES DO MERCADO
    public List<Share> b3 = new List<Share>();
    public List<Share> sp500 = new List<Share>();

    public Market()
    {
        Share irdm = new Share(true, "IRDM11", 114.00,"Agressivo");
        Share urpr = new Share(true, "URPR11", 119.49, "Agressivo");
        Share hglg = new Share(true, "HGLG11", 156,"Conservador");
        Share mxrf = new Share(true, "MXRF11", 10.06, "Moderado");
        Share btlg = new Share(true, "BTLG11", 109,"Conservador");

        Share ivv = new Share(false, "IVV", 460,"Moderado");
        Share gld = new Share(false, "GLD", 165.33,"Conservador");
        Share slv = new Share(false, "SLV", 21.58, "Conservador");
        Share amt = new Share(false, "AMT", 269.33,"Agressivo");
        Share dlr = new Share(false, "DLR", 147.54,"Agressivo");

        this.b3.Add(irdm);
        this.b3.Add(urpr);
        this.b3.Add(hglg);
        this.b3.Add(mxrf);
        this.b3.Add(btlg);
        this.sp500.Add(ivv);
        this.sp500.Add(gld);
        this.sp500.Add(slv);
        this.sp500.Add(amt);
        this.sp500.Add(dlr);
    }

    public double getItemB3(string ticker)
    {//RETORNA O PRECO DO ATIVO NA B3
        for(int i = 0;i< this.b3.Count; i++)
        {
            if(b3[i].getTicker() == ticker)
            {
                return b3[i].getPrice();
            }
        }

        return -1;
    }

    public string getRiscoB3(string ticker)
    {//RETORNA O RISCO DO ATIVO NA B3
        for (int i = 0; i < this.b3.Count; i++)
        {
            if (b3[i].getTicker() == ticker)
            {
                return this.b3[i].risco;
            }
        }

        return "N/A";
    }

    public string getRiscoSp500(string ticker)
    {//RETORNA O RISCO DO ATIVO NA SP500
        for (int i = 0; i < this.sp500.Count; i++)
        {
            if (sp500[i].getTicker() == ticker)
            {
                return this.sp500[i].risco;
            }
        }

        return "N/A";
    }

    public double getItemSp500(string ticker)
    {//RETORNA O PRECO DO ATIVO NA SP500
        for (int i = 0; i < this.sp500.Count; i++)
        {
            if (sp500[i].getTicker() == ticker)
            {
                return sp500[i].getPrice();
            }
        }

        return -1;
    }

    public Market(List<Share> shares)
    {//CRIACAO DO MERCADO
        for(int i = 0;i < shares.Count; i++)
        {
            if (shares[i].getType())
            {
                if (this.b3.IndexOf(shares[i]) < 0)
                {
                    this.b3.Add(shares[i]);
                    Console.WriteLine("Ação cadastrada na b3 com sucesso!");
                } else
                {
                    Console.WriteLine("Já existe uma ação listada na b3 com esse ticker!");
                }
            } else
            {
                if(this.sp500.IndexOf(shares[i]) < 0)
                {
                    this.sp500.Add(shares[i]);
                    Console.WriteLine("Ação cadastrada no sp500 com sucesso!");
                } else
                {
                    Console.WriteLine("Já existe uma ação listada na sp500 com esse ticker!");
                }
            }
        }
    }

    public Market(Share share)
    {//CRIACAO DO MERCADO
        if (share.getType())
        {
            if (this.b3.IndexOf(share) < 0)
            {
                this.b3.Add(share);
            }
            else
            {
                Console.WriteLine("Já existe uma ação listada na b3 com esse ticker!");
            }
        }
        else
        {
            if (this.sp500.IndexOf(share) < 0) {
                this.sp500.Add(share);                    
            } else
            {
                Console.WriteLine("Já existe uma ação listada na b3 com esse ticker!");
            }
        }
    }

    public void getSp500()
    {//EXIBE ACOES LISTADAS EM BOLSA
        Console.WriteLine("------- SP&500 -------");
        for(int i = 0; i < this.sp500.Count; i++)
        {
            Console.WriteLine("Ticker:{0} | Cotação: USD {1} |",this.sp500[i].getTicker(),this.sp500[i].getPrice());
        }
    }

    public void getB3()
    {//EXIBE ACOES LISTADAS EM BOLSA
        Console.WriteLine("------- B3 -------");
        for (int i = 0; i < this.b3.Count; i++)
        {
            Console.WriteLine("Ticker:{0} | Cotação: R$ {1} | ", this.b3[i].getTicker(),this.b3[i].getPrice());
        }
    }
}

