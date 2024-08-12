class Rules
{

    private short width;
    private short height;
    public bool[,,] List;
    public void SetValues(short width, short height)
    {
        this.width = height;
        this.height = width;
        Remakefeld();
    }
    public void Remakefeld()
    {
        List = MakingFeld();
    }
    public bool[,,] MakingFeld()
    {
        bool[,,] List = new bool[width, height, 2];
        Random rnd = new Random();
        Console.WriteLine(width + " " + height);
        for (int y = 0; y <= height - 1; y++)
        {
            for (int x = 0; x <= width - 1; x++)
            {
                if (rnd.Next(0, 3) == 1)
                {
                    List[x, y, 1] = true;
                    List[x, y, 0] = true;
                }
                    

                else
                {
                    List[x, y, 1] = false;
                    List[x, y, 0] = false;
                }
            }
        }
        return List;

    }
    public void next()
    {
        Clear_Boarders();
        CheckRules();
        Update();
    }
    public void reverse(int x, int y)
    {
        if (List[x, y, 1] == false)
        {
            List[x, y, 1] = true;
        }
        else List[x, y, 1] = false;
    }

    public byte CheckNeighbour(int x, int y)
    {
        byte count = 0;
        if (List[x + 1, y + 1, 0] == true) count++;
        if (List[x + 1, y, 0] == true) count++;
        if (List[x + 1, y - 1, 0] == true) count++;
        if (List[x, y - 1, 0] == true) count++;
        if (List[x - 1, y - 1, 0] == true) count++;
        if (List[x - 1, y, 0] == true) count++;
        if (List[x - 1, y + 1, 0] == true) count++;
        if (List[x, y + 1, 0] == true) count++;
        return count;

    }
    public void Clear()
    {
        for (int y = 0; y <= height - 1; y++)
        {
            for (int x = 0; x <= width - 1; x++)
            {
                List[x, y, 1] = false;
                List[x, y, 0] = false;
            }
        }
    }
    public void CheckRules()
    {
        short neighbour = 0;
        for (int y = 1; y < height - 1; y++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                neighbour = CheckNeighbour(x, y);
                if (List[x, y, 0] == false)
                {
                    if (neighbour == 3)
                        List[x, y, 1] = true;
                }
                else
                        if (neighbour == 2 || neighbour == 3)
                {
                    List[x, y, 1] = true;
                }
                else List[x, y, 1] = false;
            }
        }
    }
    public void Clear_Boarders() // ������� ������
    {
        for (int x = 1; x < width; x++)
        {
            List[x, 0, 1] = false;
        }
        for (int y = 0; y < height; y++)
        {
            List[0, y, 1] = false;
        }
        for (int x = 0; x < width; x++)
        {
            List[x, height - 1, 1] = false;
        }
        for (int y = 0; y < height; y++)
        {
            List[width - 1, y, 1] = false;
        }
    }
    public void Update()
    {
        for (int y = 0; y <= height - 1; y++)
        {
            for (int x = 0; x <= width - 1; x++)
            {
                List[x, y, 0] = List[x, y, 1];
            }
        }
    }
}
