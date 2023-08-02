namespace OtherTests;

public struct Point
{
    private float _x;
    private float _y;

    public Point()
    {
        _x = 0f;
        _y = 0f;

    }

    public Point(float x, float y)
    {
        this._x = x;
        this._y = y;
    }

    // + to go right
    // - to go left
    public void MoveRight(float right)
    {
        _x += right;
    }

    // + to go up
    // - to go down
    public void MoveUp(float up)
    {
        _y += up;
    }


    public void Display()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"Point: x => {_x} , y => {_y}";
    }
}