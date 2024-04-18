using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        task1();
        task2();
        static void task1()
        {
            object[,] arr = new object[4, 3]
            {
              {10, 10, "white"},
              {11, 10, "white"},
              {12, 12, "white"},
              {13, 13, "white"}
            };
            for (int i = 0; i < 4; i++)
            {
                Rectangle r = new Rectangle(Convert.ToInt32(arr[i, 0]), 
                Convert.ToInt32(arr[i, 1]), arr[i,2].ToString());
              Console.WriteLine("Side A: " + r.GetSideA());
              Console.WriteLine("Side B: " + r.GetSideB());
              Console.WriteLine("Area: " + r.CalcArea());
              Console.WriteLine("Perimeter: " + r.CalcPerimeter());
              Console.WriteLine("Is Square: " + r.IsSquare());
              Console.WriteLine("-------");

              // Додані властивості
              Console.WriteLine("Value of side A using index 0: " + r[0]);
              Console.WriteLine("Value of side B using index 1: " + r[1]);
              Console.WriteLine("Color using index 2: " + r[2]);
              Console.WriteLine("-------");

              // Перевантажені операції ++ та --
              Console.WriteLine("Incrementing sides:");
              Console.WriteLine("Before increment: A=" + r.GetSideA() + ", B=" + r.GetSideB());
              ++r;
              Console.WriteLine("After increment: A=" + r.GetSideA() + ", B=" + r.GetSideB());
              Console.WriteLine("-------");

              Console.WriteLine("Decrementing sides:");
              Console.WriteLine("Before decrement: A=" + r.GetSideA() + ", B=" + r.GetSideB());
              --r;
              Console.WriteLine("After decrement: A=" + r.GetSideA() + ", B=" + r.GetSideB());
              Console.WriteLine("-------");

              // Перевантажені сталі true і false
              Console.WriteLine("Is Square? " + r.IsSquare());
              Console.WriteLine("Is Rectangle? " + !r.IsSquare());
              Console.WriteLine("-------");

              // Перевантажена операція *
              Console.WriteLine("Multiplying sides by 2:");
              Console.WriteLine("Before multiplication: A=" + r.GetSideA() + ", B=" + r.GetSideB());
              r = r * 2;
              Console.WriteLine("After multiplication: A=" + r.GetSideA() + ", B=" + r.GetSideB());
              Console.WriteLine("-------");

              // Перетворення типу Rectangle в string та навпаки
              string rectString = (string)r;
              Console.WriteLine("Rectangle as string: " + rectString);
              // Rectangle rectFromString = (Rectangle)rectString;
              // Console.WriteLine("String converted back to Rectangle: A=" + rectFromString.GetSideA() + ", B=" + rectFromString.GetSideB() + ", Color=" + rectFromString[2]);
            }
        }
        static void task2()
        {
            List<List<object>> dynamicArray = new List<List<object>>();
            dynamicArray.Add(new List<object>() { "Joe", 26, "01.01.01", "employee" });
            dynamicArray.Add(new List<object>() { "Tom", 35, "02.01.99", "head", 1 });
            dynamicArray.Add(new List<object>() { "John", 24, "03.01.01", "engeneer", 2, "engineFix"});
            dynamicArray.Add(new List<object>() { "Mark", 44, "11.11.97", "admin", 3, 12345678 });

            for (int i = 0; i < dynamicArray.Count; i++)
            {
                switch (dynamicArray[i][3])
                {
                    case "employee":
                        Worker w = new Worker(dynamicArray[i][0].ToString(), Convert.ToInt32(dynamicArray[i][1]), dynamicArray[i][2].ToString(), dynamicArray[i][3].ToString());
                        w.Show();
                  Console.WriteLine("------");
                        break;
                    case "head":
                        Worker h = new Worker(dynamicArray[i][0].ToString(), Convert.ToInt32(dynamicArray[i][1]), dynamicArray[i][2].ToString(), dynamicArray[i][3].ToString());
                        h.Show();
                  Console.WriteLine("------");
                        break;
                    case "engeneer":
                      Engeneer e = new Engeneer(dynamicArray[i][0].ToString(), Convert.ToInt32(dynamicArray[i][1]), dynamicArray[i][2].ToString(), dynamicArray[i][3].ToString(), Convert.ToInt32(dynamicArray[i][4]), dynamicArray[i][5].ToString());
                        e.Show();
                  Console.WriteLine("------");
                        break;
                case "admin":
                  Admin a = new Admin(dynamicArray[i][0].ToString(), Convert.ToInt32(dynamicArray[i][1]), dynamicArray[i][2].ToString(), dynamicArray[i][3].ToString(), Convert.ToInt32(dynamicArray[i][4]), Convert.ToInt32(dynamicArray[i][5]));
                  a.Show();
                  Console.WriteLine("------");
                  break;
                }
            }
        }
        VectorShort vec = new VectorShort(3, 5);

        VectorShort.DisplayTaskDescription(vec);

        Console.ReadLine();
    }
}

public class Rectangle
{
    private int a;
    private int b;
    private string c;

    public Rectangle(int a, int b, string c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    // Індексатор
    public object this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return a;
                case 1: return b;
                case 2: return c;
                default: throw new IndexOutOfRangeException("Invalid index. Valid indices are 0, 1, and 2.");
            }
        }
    }

    // Перевантаження операцій ++ та --
    public static Rectangle operator ++(Rectangle rect)
    {
        rect.a++;
        rect.b++;
        return rect;
    }

    public static Rectangle operator --(Rectangle rect)
    {
        rect.a--;
        rect.b--;
        return rect;
    }

    // Перевантаження сталих true і false
    public static bool operator true(Rectangle rect)
    {
        return rect.IsSquare();
    }

    public static bool operator false(Rectangle rect)
    {
        return !rect.IsSquare();
    }

    // Перевантаження операції *
    public static Rectangle operator *(Rectangle rect, int scalar)
    {
        rect.a *= scalar;
        rect.b *= scalar;
        return rect;
    }

    // Перетворення типу Rectangle в string
    public static explicit operator string(Rectangle rect)
    {
        return $"Rectangle with sides a={rect.a}, b={rect.b}, and color {rect.c}";
    }

    // Перетворення string в Rectangle
    // public static explicit operator Rectangle(string str)
    // {
    //     string[] parts = str.Split(',');
    //     if (parts.Length != 3)
    //         throw new FormatException("Invalid format for converting string to Rectangle.");

    //     int a = int.Parse(parts[0]);
    //     int b = int.Parse(parts[1]);
    //     string c = parts[2].Trim();

    //     return new Rectangle(a, b, c);
    // }

    public int GetSideA()
    {
        return a;
    }

    public int GetSideB()
    {
        return b;
    }

    public int CalcArea()
    {
        return a * b;
    }

    public int CalcPerimeter()
    {
        return (a + b) * 2;
    }

    public bool IsSquare()
    {
        return a == b;
    }
}



public class Worker
{
    public string name { get; set; }
    public int age { get; set; }
    public string birth { get; set; }
    public string Level { get; set; }
    public Worker(string n, int a, string b, string l)
    {
        this.name = n;
        this.age = a;
        this.birth = b;
        this.Level = l;
    }

    public virtual void Show()
    {
        Console.WriteLine(name);
        Console.WriteLine(age);
        Console.WriteLine(birth);
        Console.WriteLine(Level);
    }
}

public class HeadWorker : Worker
{
    public int privilageLvl { get; set; }
    public HeadWorker(string n, int a, string b, string l, int p) 
  : base(n, a, b, l)
    {
        this.privilageLvl = p;
    }
    public override void Show()
    {
        base.Show();
        Console.WriteLine(privilageLvl);
    }
}
public class Engeneer : HeadWorker
{
    public string skill { get; set; }
    public Engeneer(string n, int a, string b, string l, 
      int p, string skill) : base(n, a, b, l, p)
    {
        this.skill = skill;
    }
    public override void Show()
    {
        base.Show();
        Console.WriteLine(skill);
    }
}
public class Admin : HeadWorker
{
    public int accesKey { get; set; }
    public Admin(string n, int a, string b, string l, 
      int p, int ak) : base(n, a, b, l, p)
    {
        this.accesKey = ak;
    }
    public override void Show()
    {
        base.Show();
        Console.WriteLine(accesKey);
    }
}
class VectorShort
{
    private short[] ShortArray;
    private uint n;
    private int codeError;
    private static uint num_v;

    public VectorShort()
    {
        ShortArray = new short[1];
        n = 1;
        codeError = 0;
        num_v++;
    }

    public VectorShort(uint size)
    {
        ShortArray = new short[size];
        n = size;
        codeError = 0;
        num_v++;
    }

    public VectorShort(uint size, short initValue)
    {
        ShortArray = new short[size];
        for (int i = 0; i < size; i++)
        {
            ShortArray[i] = initValue;
        }
        n = size;
        codeError = 0;
        num_v++;
    }

    ~VectorShort()
    {
        Console.WriteLine("Destructor called");
    }

    public void InputElements()
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter element {0}: ", i + 1);
            ShortArray[i] = Convert.ToInt16(Console.ReadLine());
        }
    }

    public void DisplayElements()
    {
        Console.WriteLine("Vector elements:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(ShortArray[i] + " ");
        }
        Console.WriteLine();
    }

    public void AssignElements(short value)
    {
        for (int i = 0; i < n; i++)
        {
            ShortArray[i] = value;
        }
    }

    public static uint CountVectors()
    {
        return num_v;
    }

    public uint Size
    {
        get { return n; }
    }

    public int ErrorCode
    {
        get { return codeError; }
        set { codeError = value; }
    }

    public short this[int index]
    {
        get
        {
            if (index < 0 || index >= n)
            {
                codeError = -10;
                return 0;
            }
            else
            {
                codeError = 0;
                return ShortArray[index];
            }
        }
        set
        {
            if (index < 0 || index >= n)
            {
                codeError = -10;
            }
            else
            {
                codeError = 0;
                ShortArray[index] = value;
            }
        }
    }

    public static VectorShort operator ++(VectorShort vec)
    {
        for (int i = 0; i < vec.Size; i++)
        {
            vec[i]++;
        }
        return vec;
    }

    public static VectorShort operator --(VectorShort vec)
    {
        for (int i = 0; i < vec.Size; i++)
        {
            vec[i]--;
        }
        return vec;
    }

    public static bool operator true(VectorShort vec)
    {
        return vec.Size != 0 && Array.TrueForAll(vec.ShortArray, x => x != 0);
    }

    public static bool operator false(VectorShort vec)
    {
        return vec.Size == 0 || Array.TrueForAll(vec.ShortArray, x => x == 0);
    }

    public static bool operator !(VectorShort vec)
    {
        return vec.Size != 0 && Array.TrueForAll(vec.ShortArray, x => x != 0);
    }

    public static VectorShort operator ~(VectorShort vec)
    {
        for (int i = 0; i < vec.Size; i++)
        {
            vec[i] = (short)~vec[i];
        }
        return vec;
    }

    public static VectorShort operator +(VectorShort vec1, VectorShort vec2)
    {
        uint maxSize = Math.Max(vec1.Size, vec2.Size);
        VectorShort result = new VectorShort(maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            short val1 = (i < vec1.Size) ? vec1[i] : (short)0;
            short val2 = (i < vec2.Size) ? vec2[i] : (short)0;
            result[i] = (short)(val1 + val2);
        }

        return result;
    }

    public static VectorShort operator +(VectorShort vec, short scalar)
    {
        VectorShort result = new VectorShort(vec.Size);

        for (int i = 0; i < vec.Size; i++)
        {
            result[i] = (short)(vec[i] + scalar);
        }

        return result;
    }

    public static VectorShort operator -(VectorShort vec1, VectorShort vec2)
    {
        uint maxSize = Math.Max(vec1.Size, vec2.Size);
        VectorShort result = new VectorShort(maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            short val1 = (i < vec1.Size) ? vec1[i] : (short)0;
            short val2 = (i < vec2.Size) ? vec2[i] : (short)0;
            result[i] = (short)(val1 - val2);
        }

        return result;
    }

    public static VectorShort operator -(VectorShort vec, short scalar)
    {
        VectorShort result = new VectorShort(vec.Size);

        for (int i = 0; i < vec.Size; i++)
        {
            result[i] = (short)(vec[i] - scalar);
        }

        return result;
    }

    public static VectorShort operator *(VectorShort vec1, VectorShort vec2)
    {
        uint maxSize = Math.Max(vec1.Size, vec2.Size);
        VectorShort result = new VectorShort(maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            short val1 = (i < vec1.Size) ? vec1[i] : (short)0;
            short val2 = (i < vec2.Size) ? vec2[i] : (short)0;
            result[i] = (short)(val1 * val2);
        }

        return result;
    }

    public static VectorShort operator *(VectorShort vec, short scalar)
    {
        VectorShort result = new VectorShort(vec.Size);

        for (int i = 0; i < vec.Size; i++)
        {
            result[i] = (short)(vec[i] * scalar);
        }

        return result;
    }

    public static VectorShort operator /(VectorShort vec1, VectorShort vec2)
    {
        uint maxSize = Math.Max(vec1.Size, vec2.Size);
        VectorShort result = new VectorShort(maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            short val1 = (i < vec1.Size) ? vec1[i] : (short)0;
            short val2 = (i < vec2.Size && vec2[i] != 0) ? vec2[i] : (short)1;
            result[i] = (short)(val1 / val2);
        }

        return result;
    }

    public static VectorShort operator /(VectorShort vec, short scalar)
    {
        VectorShort result = new VectorShort(vec.Size);

        for (int i = 0; i < vec.Size; i++)
        {
            if (scalar != 0)
                result[i] = (short)(vec[i] / scalar);
            else
                result[i] = 0;
        }

        return result;
    }

    public static VectorShort operator %(VectorShort vec1, VectorShort vec2)
    {
        uint maxSize = Math.Max(vec1.Size, vec2.Size);
        VectorShort result = new VectorShort(maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            short val1 = (i < vec1.Size) ? vec1[i] : (short)0;
            short val2 = (i < vec2.Size && vec2[i] != 0) ? vec2[i] : (short)1;
            result[i] = (short)(val1 % val2);
        }

        return result;
    }

    public static VectorShort operator %(VectorShort vec, short scalar)
    {
        VectorShort result = new VectorShort(vec.Size);

        for (int i = 0; i < vec.Size; i++)
        {
            if (scalar != 0)
                result[i] = (short)(vec[i] % scalar);
            else
                result[i] = 0;
        }

        return result;
    }

    public static VectorShort operator |(VectorShort vec1, VectorShort vec2)
    {
        uint maxSize = Math.Max(vec1.Size, vec2.Size);
        VectorShort result = new VectorShort(maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            short val1 = (i < vec1.Size) ? vec1[i] : (short)0;
            short val2 = (i < vec2.Size) ? vec2[i] : (short)0;
            result[i] = (short)(val1 | val2);
        }

        return result;
    }

    public static VectorShort operator |(VectorShort vec, short scalar)
    {
        VectorShort result = new VectorShort(vec.Size);

        for (int i = 0; i < vec.Size; i++)
        {
            result[i] = (short)(vec[i] | scalar);
        }

        return result;
    }

    public static VectorShort operator ^(VectorShort vec1, VectorShort vec2)
    {
        uint maxSize = Math.Max(vec1.Size, vec2.Size);
        VectorShort result = new VectorShort(maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            short val1 = (i < vec1.Size) ? vec1[i] : (short)0;
            short val2 = (i < vec2.Size) ? vec2[i] : (short)0;
            result[i] = (short)(val1 ^ val2);
        }

        return result;
    }

    public static VectorShort operator ^(VectorShort vec, short scalar)
    {
        VectorShort result = new VectorShort(vec.Size);

        for (int i = 0; i < vec.Size; i++)
        {
            result[i] = (short)(vec[i] ^ scalar);
        }

        return result;
    }

    public static VectorShort operator &(VectorShort vec1, VectorShort vec2)
    {
        uint maxSize = Math.Max(vec1.Size, vec2.Size);
        VectorShort result = new VectorShort(maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            short val1 = (i < vec1.Size) ? vec1[i] : (short)0;
            short val2 = (i < vec2.Size) ? vec2[i] : (short)0;
            result[i] = (short)(val1 & val2);
        }

        return result;
    }

    public static VectorShort operator &(VectorShort vec, short scalar)
    {
        VectorShort result = new VectorShort(vec.Size);

        for (int i = 0; i < vec.Size; i++)
        {
            result[i] = (short)(vec[i] & scalar);
        }

        return result;
    }

    public static VectorShort operator >>(VectorShort vec, short shift)
    {
        VectorShort result = new VectorShort(vec.Size);

        for (int i = 0; i < vec.Size; i++)
        {
            result[i] = (short)(vec[i] >> shift);
        }

        return result;
    }

    public static VectorShort operator <<(VectorShort vec, short shift)
    {
        VectorShort result = new VectorShort(vec.Size);

        for (int i = 0; i < vec.Size; i++)
        {
            result[i] = (short)(vec[i] << shift);
        }

        return result;
    }

    public static bool operator ==(VectorShort vec1, VectorShort vec2)
    {
        if (ReferenceEquals(vec1, vec2))
            return true;
        if (vec1 is null || vec2 is null)
            return false;

        if (vec1.Size != vec2.Size)
            return false;

        for (int i = 0; i < vec1.Size; i++)
        {
            if (vec1[i] != vec2[i])
                return false;
        }

        return true;
    }

    public static bool operator !=(VectorShort vec1, VectorShort vec2)
    {
        return !(vec1 == vec2);
    }

    public static bool operator >(VectorShort vec1, VectorShort vec2)
    {
        if (vec1.Size != vec2.Size)
            return false;

        for (int i = 0; i < vec1.Size; i++)
        {
            if (vec1[i] <= vec2[i])
                return false;
        }

        return true;
    }

    public static bool operator <(VectorShort vec1, VectorShort vec2)
    {
        if (vec1.Size != vec2.Size)
            return false;

        for (int i = 0; i < vec1.Size; i++)
        {
            if (vec1[i] >= vec2[i])
                return false;
        }

        return true;
    }

    public static bool operator >=(VectorShort vec1, VectorShort vec2)
    {
        if (vec1.Size != vec2.Size)
            return false;

        for (int i = 0; i < vec1.Size; i++)
        {
            if (vec1[i] < vec2[i])
                return false;
        }

        return true;
    }

    public static bool operator <=(VectorShort vec1, VectorShort vec2)
    {
        if (vec1.Size != vec2.Size)
            return false;

        for (int i = 0; i < vec1.Size; i++)
        {
            if (vec1[i] > vec2[i])
                return false;
        }

        return true;
    }

  public static void DisplayTaskDescription(VectorShort vec)
  {
      Console.WriteLine("Vector task description:");
      Console.WriteLine("1. The vector with {0} elements is created.", vec.Size);
      Console.WriteLine("2. The elements of the vector are initialized with the value of 3.");
      vec.AssignElements(3);
      Console.WriteLine("   Initialized Vector:");
      vec.DisplayElements();
      Console.WriteLine("3. All elements of the vector are incremented by 2.");
      vec++;
      Console.WriteLine("   Vector after increment:");
      vec.DisplayElements();
      Console.WriteLine("4. The number of vectors of this type is: {0}", VectorShort.CountVectors());
  }

}
