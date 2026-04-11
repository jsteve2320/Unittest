using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//ZADANYA 1
public class Container<T> where T: IComparable<T>
{
    private List<T> _items = new List<T>();

    public void Add(T item)
    {
        _items.Add(item);
    }
    public T GetMax()
    {
        if(_items.Count == 0)
        throw new InvalidOperationException("Nothing in the list.");

        T max = _items[0];
        for(int i = 1; i < _items; i++)
        {
            if(_items [i].CompareTo(max) > 0)
            max = _items[i];            
        }
        return max;
    }

    public void Sort()
    {
        _items.Sort();
    }
}

//ZADANYA 2 

public class ClickEventArgs : EventArgs
{
    public int TotalClicks { get; set; }
    public DateTime LastClickTime { get; set; }
}

public class MyButton
{
    private int _clickCount = 0;
    public event EventHandler<ClickEventArgs> Click;

    public void OnClick()
    {
        _clickCount++;
        Click?.Invoke(this, new ClickEventArgs
        {
            TotalClicks = _clickCount,
            LastClickTime = DateTime.Now
        });
    }
}

class Program1
{
    static void Main()
    {
        MyButton boton = new MyButton();
        boton.Click += (sender, e) =>
        {
            Console.WriteLine($"Button pressed!! Total of clicks: {e.TotalClicks}, Time: {e.LastClickTime}");
        };

        boton.OnClick();
        System.Threading.Thread.Sleep(1000);
        boton.OnClick();
        boton.OnClick();
        
    }
}


//ZADANYA 3

class Program2
{
    static void Main()
    {
        string [] Lines = 
        {
            "Ana; Math; 5",
            "Luis; Math; 4",
            "Ana; Programming; 5",
            "Luis; Programming; 3",
            "Carlos; Programming; 4",
            "Marian; Math; 3"
        };

        File.WriteAllLines("grades.txt", Lines);
        var FileLines = File.ReadAllLines("Grades.txt");
        var data = FileLines.Select(line =>
        {
           var parts = line.Split(';');
           return new
           {
               Student = parts[0],
               Subject = parts[1],
               Note = int.Parse(parts[2])
           };
        }).ToList();
    }
}