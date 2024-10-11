int[][][] objecttetris = 
    [
        [[0, 0], [0, 1], [0, 2], [0, 3]], 
        [[0, 0], [1, 1], [0, 1], [1, 0]], 
        [[0, 0], [0, 1], [0, 2], [1, 2]], 
        [[1, 0], [1, 1], [1, 2], [0, 2]]
    ];
int[][] square = [[0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0]];
int[] coord = [1, 0];
int typeobjecttetris = 0;
int speed = 500;
//new Random().Next(square[0].Length)

/*
    Номера типов фигур
    Палка - 0
    Квадрат - 1
    Палка вправо - 2
    Палка влево
*/

string response = "";

bool downfigur(int x, int y, int coordx, int coordy)
{
    for (int i  = 0; i < objecttetris[typeobjecttetris].Length; i++)
    {
        if (objecttetris[typeobjecttetris][i][0] + coordx == x && objecttetris[typeobjecttetris][i][1] + coordy == y)
        {
            return true;
        }
    }

    return false;
}

while (true)
{
    Thread.Sleep(speed);

    if (response != "Finish")
    for (int i = 0; i < square.Length; i++)
    {
        //Thread.Sleep(1000);

        response += "\n|";
        for (int i2 = 0; i2 < square[i].Length; i2++)
        {
            response += downfigur(i2, i, coord[0], coord[1]) || square[i][i2] == 1 ? " / |" : " - |";
        }
    }

    Console.Clear();
    Console.WriteLine(response);

    response = "";
    coord[1] += 1;
    if (square[0][coord[0]] == 1)
    {
        response = "Finish";
    } else if (coord[1] + 4 > square.Length || square[coord[1] + 3][coord[0]] == 1)
    {
        for (int i = 0; i < objecttetris[typeobjecttetris].Length; i++)
        {
            square[coord[1] - i + 2][objecttetris[typeobjecttetris][i][0] + coord[0]] = 1;
        }
        coord[1] = 0;

        coord[0] = new Random().Next(square[coord[1]].Length);
    }

    Thread t = new Thread(delegate () {
        while (true)
        {
            ConsoleKeyInfo click = Console.ReadKey();

            if (ConsoleKey.D == click.Key)
            {
                //переписать
                //if (coord[0] < square[coord[1]].Length - 1 && objecttetris[typeobjecttetris][0][1] + square[coord[1]][coord[0] + 1] == 0 && objecttetris[typeobjecttetris][1][0] + square[coord[1]][coord[0] + 1] == 0 && objecttetris[typeobjecttetris][2][0] + square[coord[1]][coord[0] + 1] == 0 && objecttetris[typeobjecttetris][3][0] + square[coord[1]][coord[0] + 1] == 0)
                //{
                    coord[0] += 1;
                //}
            }
            else if (ConsoleKey.A == click.Key)
            {
                if (coord[0] > 0 && square[coord[1]][coord[0] - 1] == 0)
                {
                    coord[0] -= 1;
                }
            }
        }
    });

    t.Start();

    /*ConsoleKeyInfo click = Console.ReadKey();

    if (ConsoleKey.S == click.Key)
    {
        Console.WriteLine("123");
    }*/
}