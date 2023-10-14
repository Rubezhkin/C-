public class Stack<T>
{
    private Node<T> head;

    public Node<T> top()
    { 
        return head; 
    }
    public Stack<T> tail()
    {
        Stack<T> St = new Stack<T>();
        St.head = head.next;
        return St;
    }
    public void Push(T value)
    {
        Node<T> newNode = new Node<T>();
        newNode.Value = value;
        newNode.next = head;
        head = newNode;
    }

    public T Pop()
    {
        if (head == null)
            throw new InvalidOperationException("Стэк пуст");

        T value = head.Value;
        head = head.next;
        return value;
    }

    public class Node<T>
    {
        public T Value;
        public Node<T> next;
    }
}

public class Tasc
{
    public static void Main(string[] args)
    {
        Stack<int> stack = new Stack<int>();
        for(int i = 0; i < 5; i++) 
            stack.Push(i);
        int mode;
        Console.WriteLine("1)верхнее значение\n2)хвост\n3)удалить\n4)добавить\n0)выйти");
        mode = Convert.ToInt32(Console.ReadLine());
        while (mode != 0)
        {
            switch (mode)
            {
                case 1:
                    Console.WriteLine(stack.top().Value);
                    break;
                case 2:
                    Stack<int> st = stack.tail();
                    while (st.top() != null) Console.Write(st.Pop() + " ");
                    Console.WriteLine("\n");
                    break;
                case 3:
                    try
                    { stack.Pop(); }
                    catch (Exception ex)
                    { Console.WriteLine(ex.Message); }
                    break;
                case 4:
                    Console.WriteLine("Введите значение");
                    stack.Push(Convert.ToInt32(Console.ReadLine()));
                    break;
            }
            mode = Convert.ToInt32(Console.ReadLine());
        }
    }
}