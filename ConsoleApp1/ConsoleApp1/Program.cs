using System;
using System.Linq.Expressions;

public abstract class Figure
{
    abstract public float getSquare();
    abstract public float getPerimetr();
}

public class Circle : Figure
{
    private float radius;
    public float Radius { get { return this.radius; } private set { this.radius = value; } }
    public Circle(float radius)
    {
        if (radius <= 0)
            throw new Exception("Радиус должен быть больше 0");
        else
        {
            this.radius = radius;
           // this.Radius = radius; плохо
        }
    }
    public override float getSquare()
    { return  radius * radius * (float) Math.PI; }
    public override float getPerimetr()
    { return 2 * radius * (float)Math.PI; }
}

public class Rectangle : Figure
{
    private float a, b;
    public Rectangle(float a, float b)
    {
        if (a <= 0 || b <= 0)
            throw new Exception("Одна из длин стороны отрицательная или равна 0");
        else
        {
            this.a = a;
            this.b = b;
        }
    }
    public override float getSquare()
    { return a * b; }
    public override float getPerimetr()
    { return 2 * (a + b); }
}

public class Square : Figure
{
    float a;
    public Square(float a)
    {
        if (a <= 0)
            throw new Exception("длина стороны отрицательная или равна 0");
        else
            this.a = a;
    }
    public override float getSquare()
    { return a * a; }
    public override float getPerimetr()
    { return 4*a; }
}

public class Triangle : Figure
{
    float a, b, c;
    public Triangle(float a, float b, float c)
    {
        if (a > b + c || b > a + c || c > a + b || a <= 0 || b <= 0 || c <= 0)
            throw new Exception("Одна из сторон превышает длины двух остальных или имеет отрицательную или нулевую длину");
        else
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }
    public override float getSquare()
    {
        float p = this.getPerimetr() / 2;
        return  (float) Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
    public override float getPerimetr()
    { return a+b+c; }
}
public class Laba0
{
    public static void Main(string[] args)
    {
        int figure;
        do
        {
            Console.WriteLine("Введите, какую фигуру вы хотите\n1)Круг\n2)Прямоугольник\n3)Квадрат\n4)Треугольник\n0)Выйти\n");
            figure = Convert.ToInt32(Console.ReadLine());
            switch (figure)
            {
                case 1:
                    Console.Write("Введите радиус: ");
                    int Rad = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        Circle Fig = new Circle(Rad);
                        Console.WriteLine($"Площадь: {Fig.getSquare()}\nПериметр: {Fig.getPerimetr()}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 2:
                    Console.WriteLine("Введите длину и ширину: ");
                    int a = Convert.ToInt32(Console.ReadLine());
                    int b = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        Rectangle Fig = new Rectangle(a, b);
                        Console.WriteLine($"Площадь: {Fig.getSquare()}\nПериметр: {Fig.getPerimetr()}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 3:
                    Console.WriteLine("Введите длину: ");
                    int sqA = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        Square Fig = new Square(sqA);
                        Console.WriteLine($"Площадь: {Fig.getSquare()}\nПериметр: {Fig.getPerimetr()}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 4:
                    Console.WriteLine("Введите стороны треугольника");
                    int recA = Convert.ToInt32(Console.ReadLine());
                    int recB = Convert.ToInt32(Console.ReadLine());
                    int recC = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        Triangle Fig = new Triangle(recA,recB,recC);
                        Console.WriteLine($"Площадь: {Fig.getSquare()}\nПериметр: {Fig.getPerimetr()}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                default:
                    break;     
            }
        } while (figure != 0);
    }
}