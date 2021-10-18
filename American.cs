using System;
using System.Collections.Generic;
using System.Text;


class American : Account
{//CLASSE DE CONTA AMERICANA
    public American(User owner) : base(owner)
    {
    }

    override public void getBalance()
    {
        Console.WriteLine("Seu saldo atual é de: U$ {0}", this.balance);
    }

    protected override double Discount(double balance)
    {
        return balance * 0.95;
    }
}

