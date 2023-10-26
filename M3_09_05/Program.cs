namespace M3_09_05;

class Program
{
    public enum RectColor
    {
        red, blue, yellow, white, pink
    }
    public class Rectangle : IEquatable<Rectangle>
    {
        public RectColor Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Area => Height * Width;

        public bool Equals(Rectangle other) => (Height, Width, Color) == (other.Height, other.Width, other.Color);
        public override int GetHashCode() => (Width, Height, Color).GetHashCode();  //Needed to implement as part of IEquatable
        public override bool Equals(object obj) => Equals(obj as Rectangle); //Needed to implement as part of IEquatable

        public override string ToString() => $"{Color} rectangle with height: {Height:N2}, width: {Width:N2} and area: {Area:N2}";
    }

    static void Main(string[] args)
    {
        //HashSet<T>
        HashSet<RectColor> hs1 = new HashSet<RectColor>();
        hs1.Add(RectColor.red);
        hs1.Add(RectColor.yellow);
        hs1.Add(RectColor.red);
        hs1.Add(RectColor.blue);
        hs1.Add(RectColor.white);
        hs1.Add(RectColor.pink);
        hs1.Add(RectColor.red);
        hs1.Add(RectColor.white);

        //Convert to list and write out. Only unique RectColors
        foreach (var item in hs1.ToList())
        {
            Console.WriteLine(item);
        }

        //HashSet use IEqutable and GetHashCode(), so any object implementing IEqutable and GetHashCode() can be used
        HashSet<Rectangle> hs2 = new HashSet<Rectangle>() {
                new Rectangle(){ Color = RectColor.pink, Height = 45, Width =15 },
                new Rectangle(){ Color = RectColor.red, Height = 10, Width = 20 },
                new Rectangle(){ Color = RectColor.pink, Height = 45, Width =15 },
                new Rectangle(){ Color = RectColor.red, Height = 10, Width = 20 },
                new Rectangle(){ Color = RectColor.blue, Height = 10, Width = 20 }};

        //Convert to list and write out. Only unique Rectangles
        Console.WriteLine();
        foreach (var item in hs2.ToList())
        {
            Console.WriteLine(item);
        }
    }
}

