using System;
using System.Collections.Generic;
using System.Text;

class Brazilian : Account
{//CLASSE DE CONTA BRASILEIRA
    public Brazilian(User owner) : base(owner)
    {
    }

    protected override double Discount(double balance)
    {
        return balance * 0.99;
    }
}
