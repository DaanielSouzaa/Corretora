using System;
using System.Collections.Generic;
using System.Text;


class User
{//CLASSE DE USUARIOS DA CORRETORA
    private string fullname;
    private string passwd;
    // public Account american;
    // public Account brazilian;

    public User(string fullname, string passwd)
    {
        if(passwd.Length > 7)
        {
            this.fullname = fullname;
            this.passwd = passwd;
            //Console.WriteLine("Usuário criado com sucesso!");
            //this.american = new American();
            //this.brazilian = new Brazilian();
        } else
        {
            bool valid = false;
            while (valid == false)
            {
                Console.WriteLine("A senha possui menos de 7 caractéres, por questões de segurança, escolha uma nova!");
                try
                {
                    passwd = Console.ReadLine();
                    if (passwd.Length > 7)
                    {
                        valid = true;
                        Console.WriteLine("Usuário criado com sucesso!");
                        //this.american = new American();
                        //this.brazilian = new Brazilian();
                    }
                } catch (Exception)
                {
                    valid = false;
                }
            }
        }
    }

    public string getName()
    {
        return this.fullname;
    }

    protected void ChangePasswd()
    {
        Console.WriteLine("Digite uma senha com mais de 8 caractéres: ");
        string passwd = Console.ReadLine();
        validPassWd(passwd);
    }

    protected void ChangePasswd(string passwd)
    {
        validPassWd(passwd);
    }

    private bool validPassWd(string passwd)
    {
        if (passwd.Length > 7)
        {
            this.passwd = passwd;
            //Console.WriteLine("Usuário criado com sucesso!");
            return true;
        }
        else
        {
            bool valid = false;
            while (valid == false)
            {
                Console.WriteLine("A senha possui menos de 7 caractéres, por questões de segurança, escolha uma nova!");
                try
                {
                    passwd = Console.ReadLine();
                    if (passwd.Length > 7)
                    {
                        valid = true;
                        //Console.WriteLine("Usuário criado com sucesso!");
                    }
                }
                catch (Exception)
                {
                    valid = false;
                }
            }
        }
        return false;
    }
}

