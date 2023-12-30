internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(Add(new int[] { 1, 2, 2, 4, 5, 5 })); // without 'params', важно заметить, тут спокойно
                                                                // можно использовать как с 'params' так и без 
                                                                //or
        Console.WriteLine(Add(1, 2, 2, 4, 5, 5)); // with 'params'

        Console.WriteLine(Add()); // все успешно компилируется, результат - 0
        Console.WriteLine(Add(null)); // все успешно компилируется, результат - 0. Тут кстати код быстрее, так как не выделяется 
                                      // память под массив ибо аргумент null, а не Int32[0] как в предыдущем случае

        Console.WriteLine(new String('-', 32));
        DisplayTypes(new Object(), new Random(), 3, '-', "Привет");
    }

    static Int32 Add(params Int32[] values) // допустимы только int значения
    {
        int sum = 0;

        if (values != null)
        {
            for (int x = 0; x < values.Length; x++)
            {
                sum += values[x];
            }
        }
        return sum;
    }

    private static void DisplayTypes(params Object[] objects) // допустимы любые значения
    {
        if (objects != null)
        {
            foreach (Object o in objects)
            {
                Console.WriteLine(o.GetType());
            }
        }
    }
}

// ключевым словом 'params' ВСЕГДА может быть помечен ТОЛЬКО(именно один) последний(самый правый) аргумент метода

// не следует им часто пользоваться, от него сильно страдает производительность, лучше определять несколько перегруженных
// методов, если их не слишком много