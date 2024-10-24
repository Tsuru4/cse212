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

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data) //This check will prevent duplicates
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value == Data)
            return true;
        else
        {
            if (value < Data)
                {
                if (Left is null)
                    return false;
                return Left.Contains(value);
                }
            else
                {
                if (Right is null)
                    return false;
                return Right.Contains(value);
                }
        }
    }

    public int GetHeight()
    {
        int leftHeight = 0;
        int rightHeight = 0;
        if (!(Left is null))
        {
            leftHeight = Left.GetHeight();
        }
        if (!(Right is null))
        {
            rightHeight = Right.GetHeight();
        }

        if (leftHeight > rightHeight)
            return 1 + leftHeight;
        return 1 + rightHeight;
    }
}