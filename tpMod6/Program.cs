using System;
using System.Diagnostics;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;
    private const int MAX_PLAY_COUNT = 10000000;
    private Random rnd = new Random();

    public SayaTubeVideo(string s)
    {
        Debug.Assert(s.Length <= 100 && s != null, "Precondition failed: Judul video harus memiliki panjang maksimal 100 karakter dan tidak boleh null");

        this.id = rnd.Next(10000, 100000);
        this.title = s;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        try
        {
            checked
            {
                if (count <= 0)
                {
                    throw new ArgumentException("Count harus lebih besar dari nol.");
                }
                if (this.playCount + count > MAX_PLAY_COUNT)
                {
                    throw new OverflowException("Jumlah penambahan play count melebihi batas maksimal.");
                }
                this.playCount += count;
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Overflow exception: " + ex.Message);
            this.playCount = MAX_PLAY_COUNT; 
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Argument exception: " + ex.Message);
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Judul video: " + this.title);
        Console.WriteLine("ID Video: " + this.id);
        Console.WriteLine("PlayCount video: " + this.playCount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        SayaTubeVideo video1 = new SayaTubeVideo("Tutorial Design By Contract - Gabrielle");
        video1.PrintVideoDetails();

        for (int i = 0; i < 3; i++)
        {
            video1.IncreasePlayCount(800000000);
        }

        video1.PrintVideoDetails();

        try
        {
            video1.IncreasePlayCount(int.MaxValue);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Overflow exception handled in Main method: " + ex.Message);
        }

        video1.PrintVideoDetails();

        SayaTubeVideo video2 = new SayaTubeVideo("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
            "a");
    }
}
