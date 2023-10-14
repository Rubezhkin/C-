struct Domino
{
    public int n1, n2;
};

class laba3
{
    public static void Main(String[] args)
    {
        string str;
        string[] str2;
        Console.Write("Введите количество доминошек: ");
        int N = Convert.ToInt32(Console.ReadLine());
        Domino[] domino = new Domino[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write("Введите значения " + (i + 1) + " доминошки: ");
            str = Console.ReadLine();
            str2 = str.Split(' ');
            domino[i].n1 = Convert.ToInt32(str2[0]);
            domino[i].n2 = Convert.ToInt32(str2[1]);
            if (domino[i].n1 > domino[i].n2)
                (domino[i].n1, domino[i].n2) = (domino[i].n2, domino[i].n1);     
        }

        Console.WriteLine("Результат: " + func(domino));
    }
    public static int func(Domino[] domino)
    {
        Dictionary<Domino,int> dict = new Dictionary<Domino, int>();
        foreach (Domino dom in domino)
        {
            if (!dict.ContainsKey(dom))
                dict.Add(dom, 1);
            else
                dict[dom]++;
        }
        int res = 0;
        foreach (var dom in dict)
            if (dom.Value != 1)
                res += dom.Value;
        
        return res;
    }
}