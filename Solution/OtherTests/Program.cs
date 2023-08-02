var point = new Point();
point.Display();
point.MoveRight(2);
point.MoveUp(4);
point.Display();

struct Point
{
    private float x;
    private float y;

    public Point()
    {
        x = 0f;
        y = 0f;

    }

    public Point(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    // + to go right
    // - to go left
    public void MoveRight(float right)
    {
        x += right;
    }

    // + to go up
    // - to go down
    public void MoveUp(float up)
    {
        y += up;
    }


    public void Display()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"Point: x => {x} , y => {y}";
    }
}