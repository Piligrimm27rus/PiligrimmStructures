using Piligrimm.Structures.Extentions;

namespace Piligrimm.Structures;

public class BinaryTree<T>
{
    private BinaryTreeNode<T> _mainNode;
    private int _count = 0;

    public int Count => _count;
    public BinaryTreeNode<T> MainNode => _mainNode;

    public BinaryTree() { }

    public BinaryTree(T[] values)
    {
        foreach (var value in values)
            Add(value);
    }

    public void Add(T value)
    {
        if (value is null)
            throw new ArgumentNullException(nameof(value), "Value of node can't be null");

        var current = _mainNode;
        if (current is null)
            _mainNode = new BinaryTreeNode<T> { Value = value };
        else
        {
            BinaryTreeNode<T>? side;
            while (current != null)
            {
                var index = value.IsGreaterThan(current.Value);

                side = index == 1
                    ? current.RightNode
                    : current.LeftNode;

                if (side is null)
                {
                    AddNodeByIndex(value, current, index);
                    break;
                }

                current = side;
            }
        }

        _count++;
    }

    private void AddNodeByIndex(T value, BinaryTreeNode<T> node, int index)
    {
        if (index == 1)
            node.RightNode = new BinaryTreeNode<T> { Value = value };
        else if (index == -1 || index == 0)
            node.LeftNode = new BinaryTreeNode<T> { Value = value };
    }
}