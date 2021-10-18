using System;
using System.Collections.Generic;
using System.Text;


class Share
{//CLASSE DE ATIVOS DA BOLSA
    private bool national;
    private string ticker;
    private double price;
    public int qtd = 0;
    public string risco;
    public double avaliacao = 0;

    public Share(bool national, string ticker, double price,string risco,int qtd)
    {
        this.national = national;
        this.ticker = ticker;
        this.price = price;
        this.risco = risco;
        this.qtd += qtd;
    }

    public Share(bool national, string ticker, double price, string risco)
    {
        this.national = national;
        this.ticker = ticker;
        this.price = price;
        this.risco = risco;
        this.qtd += 0;
    }

    public double getPrice()
    {
        return this.price;
    }

    public string getTicker()
    {
        return this.ticker;
    }

    public bool getType()
    {
        return this.national;
    }
}

