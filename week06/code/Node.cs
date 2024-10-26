public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        if ( value == Data)
        {
            return;
        }
        else
        {
            if (value < Data)
            {
                // Insert to the left
                if (Left is null)
                    Left = new Node(value);
                else
                    Left.Insert(value);
            }
            else
            {
                // Insert to the right
                if (Right is null)
                    Right = new Node(value);
                else
                    Right.Insert(value);
            }
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if ( value == Data)
        {
            return true;
        }
        else
        {
            if (value < Data)
            {
                // Contains to the left
                if (Left != null)
                   return Left.Contains(value);
                else
                    return false;
            }
            else
            {
                // Contains to the right
                if (Right != null)
                    return Right.Contains(value);
                else
                    return false;
            }
        }
    }

    public int GetHeight()
    {
        

        if (Right is null && Left is null)
        {
            return 1;
        }
        else
        {
            int rightSide = Right?.GetHeight() ?? 0;
            int leftSide = Left?.GetHeight() ?? 0;

            return 1 + int.Max(leftSide, rightSide);
        }
        
    }
}