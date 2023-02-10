using System;
using System.Collections.Concurrent;
using System.Reflection.Emit;
using System.Runtime.Remoting.Services;

// CODED BY KATHLEEN FORGIARINI DA SILVA
// 2023-02-07
// LAB 3.5 Working with Console C# creating class Calc
class Calc
{
    private double num1;
    private double num2;

    // Default constructor
    public Calc()
    {
        this.num1 = 0;
        this.num2 = 0;
    }

    // Overloaded constructor with two arguments
    public Calc(double n1, double n2)
    {
        this.num1 = n1;
        this.num2 = n2;
    }

    // Properties for num1 and num2
    public double Num1
    {
        get { 
            return num1; 
        }
        set { 
            num1 = value;
        }
    }

    public double Num2
    {
        get
        {
            return num2;
        }
        set
        {
            num2 = value;
        }
    }

    // Method for addition
    public double Add()
    {
        return num1 + num2;
    }

    // Method for subtraction
    public double Sub()
    {
        return num1 - num2;
    }

    // Method for multiplication
    public double Mul()
    {
        return num1 * num2;
    }

    // Method for division
    public double Div()
    {
        return Math.Round(num1 / num2, 4);
    }

    // Method to display results
    public void Display()
    {
        Console.WriteLine("==========================Results==========================");
        Console.WriteLine("{0} + {1} = {2}", num1, num2, Add());
        Console.WriteLine("{0} - {1} = {2}", num1, num2, Sub());
        Console.WriteLine("{0} * {1} = {2}", num1, num2, Mul());
        Console.WriteLine("{0} / {1} = {2}", num1, num2, Div());
        Console.WriteLine("===========================================================\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Default constructor with default values
        Calc obj0 = new Calc();
        Console.WriteLine("Default Constructor using default values");
        Console.WriteLine("number1={0}, number2={1}, res={2}, info={3}", obj0.Num1, obj0.Num2, obj0.Add(), "( NaN = not a number)");

        Calc obj1 = new Calc();

        // Getting values from the user

        enter1:
        try
        {
            Console.WriteLine("Please enter the first number:");
            obj1.Num1 = double.Parse(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
            goto enter1;
        }

        enter2:
        try
        {
            Console.WriteLine("Please enter the second number:");
            obj1.Num2 = double.Parse(Console.ReadLine());
            if (obj1.Num2 == 0)
            {
                goto enter2;
            } else
            {
                Console.WriteLine("\nYour numbers are: {0} & {1} \n", obj1.Num1, obj1.Num2);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
            goto enter2;
        }


        obj1.Display();

        // Constructor with two arguments
        Console.WriteLine("\nConstructor with two arguments for number1=9 and number2=3 (private variables)," +
            "\n using Properties (set=write; get=read) Number1=9 and Number2=3\n");
        Calc obj2 = new Calc(9, 3);
        Console.WriteLine("\nYour numbers are: {0} & {1} \n", obj2.Num1, obj2.Num2);

        obj2.Display();

        Console.ReadKey();
    }
}
