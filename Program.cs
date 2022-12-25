

using System.Text;

char[][] grid = new char[9][];

// 0 1 2 , 3 4 5 (+3) , 6 7 8 (+3)


grid[0] = new char[] { '.', '.', '.', '.', '2', '.', '.', '9', '.' };
grid[1] = new char[] { '.', '.', '.', '.', '6', '.', '.', '.', '.' };
grid[2] = new char[] { '7', '1', '.', '.', '7', '5', '.', '.', '.' };
grid[3] = new char[] { '.', '7', '.', '.', '.', '.', '.', '.', '.' };
grid[4] = new char[] { '.', '.', '.', '.', '8', '3', '.', '.', '.' };
grid[5] = new char[] { '.', '.', '8', '.', '.', '7', '.', '6', '.' };
grid[6] = new char[] { '.', '.', '.', '.', '.', '2', '.', '.', '.' };
grid[7] = new char[] { '.', '1', '.', '2', '.', '.', '.', '.', '.' };
grid[8] = new char[] { '.', '2', '.', '.', '3', '.', '.', '.', '.' };

var result = solution(grid);

Console.WriteLine(result);

bool solution(char[][] grid)
{
    bool res = true;

    Dictionary<char, char> dictRow = new Dictionary<char, char>();
    Dictionary<char, char> dictCol = new Dictionary<char, char>();
    Dictionary<char, char> dictCell = new Dictionary<char, char>();

    for (int i = 0; i < grid.Length; i++)
    {
        dictRow = new Dictionary<char, char>();
        dictCol = new Dictionary<char, char>();

        for (int j = 0; j < grid.Length; j++)
        {
            var iterationChar = grid[i][j];

            if(iterationChar != '.')
            {
                var tryAdd = dictRow.TryAdd(iterationChar,iterationChar);
                if (!tryAdd)
                {
                    res = false;

                    return res;
                }
            }

            var iterationCharCol = grid[j][i];

            if (iterationCharCol != '.')
            {
                var tryAdd = dictCol.TryAdd(iterationCharCol, iterationCharCol);
                if (!tryAdd)
                {
                    res = false;

                    return res;
                }
            }
        }

    }

    for (int i = 0; i < 3; i++)
    {
        int bayesRow = i * 3;

        for (int j = 0; j < 3; j++)
        {
            dictCell = new Dictionary<char, char>();

            int bayesCol = j * 3;

            for (int z = 0; z < 3; z++)
            {
                for (int x = 0; x < 3; x++)
                {
                    var iterationCharCol = grid[z+bayesRow][x+bayesCol];

                    if (iterationCharCol != '.')
                    {
                        var tryAdd = dictCell.TryAdd(iterationCharCol, iterationCharCol);
                        if (!tryAdd)
                        {
                            res = false;

                            return res;
                        }
                    }

                }
            }
          
        }
    }

    

    return res;

}
