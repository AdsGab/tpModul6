public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;
    Random rnd = new Random();

    public SayaTubeVideo(string s) {
        this.id = rnd.Next(10000,100000);
        this.title = s;
        this.playCount = 0;
    }
    public void IncreasePlayCount(int i) {
        this.playCount = this.playCount + i;
    }
    public void PrintVideoDetails() {
        Console.WriteLine("Judul video: " + this.title);
        Console.WriteLine("ID Video: " + this.id);
        Console.WriteLine("PlayCount video: " + this.playCount);
    }
}

class porgram
{
    static void Main(String[] args)
    {
        SayaTubeVideo video1 = new SayaTubeVideo("Tutorial Design By Contract - Gabrielle");
        video1.PrintVideoDetails();
    }
}