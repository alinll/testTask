int[] hedgehogs = [RedHedgehogs(), GreenHedgehogs(), BlueHedgehogs()];
int targetColor = Color();

Console.WriteLine(MinMeetings(hedgehogs, targetColor));


static int AskCountHedgehogs()
{
    do
    {
        try
        {
            int count = Convert.ToInt32(Console.ReadLine());
            if (count >= 0)
            {
                return count;
            }
            else
            {
                Console.WriteLine("The number of hedgehogs must be a number >= 0. Please, enter a correct number");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    } while (true);
}
static int RedHedgehogs()
{
    Console.WriteLine("How many are red hedgehogs?");
    return AskCountHedgehogs();
}

static int GreenHedgehogs()
{
    Console.WriteLine("How many are green hedgehogs?");
    return AskCountHedgehogs();
}

static int BlueHedgehogs()
{
    Console.WriteLine("How many are blue hedgehogs?");
    return AskCountHedgehogs();
}

static int Color()
{
    do
    {
        try
        {
            Console.WriteLine("Which color hedgehogs want to choose. Enter 0 if they want be red, 1 if green, 2 if blue.");
            int color;
            do
            {
                color = Convert.ToInt32(Console.ReadLine());
                if (color >= 0 && color <= 2)
                {
                    return color;
                }
                else
                {
                    Console.WriteLine("The number must be >= 0 and <= 2. Please, enter number again.");
                }
            } while (true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    } while (true);
}

static int MinMeetings(int[] hedgehogs, int targetColor)
{
    int red = 0;
    int green = 1;
    int blue = 2;
    int total = hedgehogs[red] + hedgehogs[green] + hedgehogs[blue];

    if (hedgehogs[targetColor] == total)
    {
        return 0;
    }

    int nonZero = 0;
    foreach (int h in hedgehogs)
    {
        if (h > 0)
        {
            nonZero++;
        }
    }
    if (nonZero == 1)
    {
        return -1;
    }

    var visited = new HashSet<(int, int, int)>();
    var queue = new Queue<(int r, int g, int b, int steps)>();
    queue.Enqueue((hedgehogs[red], hedgehogs[green], hedgehogs[blue], 0));
    visited.Add((hedgehogs[red], hedgehogs[green], hedgehogs[blue]));

    while (queue.Count > 0)
    {
        var (r, g, b, steps) = queue.Dequeue();
        if ((targetColor == red && r == total) ||
            (targetColor == green && g == total) ||
            (targetColor == blue && b == total))
        {
            return steps;
        }

        if (r > 0 && g > 0)
        {
            TryAdd(r - 1, g - 1, b + 2);
        }
        if (g > 0 && b > 0)
        {
            TryAdd(r + 2, g - 1, b - 1);
        }
        if (r > 0 && b > 0)
        {
            TryAdd(r - 1, g + 2, b - 1);
        }

        void TryAdd(int nr, int ng, int nb)
        {
            var state = (nr, ng, nb);
            if (!visited.Contains(state))
            {
                visited.Add(state);
                queue.Enqueue((nr, ng, nb, steps + 1));
            }
        }
    }

    return -1;
}