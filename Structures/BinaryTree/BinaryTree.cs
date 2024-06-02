using System.Collections.Generic;

namespace Piligrimm.Structures;

public class BinaryTree<T>
{
    private List<int> _hashCodes;
    private BinaryTreeNode<T>? _mainNode;

    public int Count => _hashCodes.Count;
    public BinaryTreeNode<T>? MainNode => _mainNode;

    public BinaryTree()
    {
        _hashCodes = new();
    }

    public BinaryTree(T[] values) : this()
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
            _mainNode = new() { Value = value };
        else
        {
            BinaryTreeNode<T>? side;
            while (current is not null)
            {
                var isRight = value.GetHashCode() > current.Value.GetHashCode();
                side = isRight ? current.RightNode : current.LeftNode;

                if (side is null)
                {
                    if (isRight)
                        current.RightNode = new BinaryTreeNode<T> { Value = value };
                    else
                        current.LeftNode = new BinaryTreeNode<T> { Value = value };
                    break;
                }

                current = side;
            }
        }

        _hashCodes.Add(value.GetHashCode());
    }

    public bool Remove(T value)
    {
        if (value is null)
            return false;


        var current = _mainNode;
        if (current is not null || current.Value.GetHashCode() == value.GetHashCode())
            _mainNode = null;
        else
        {
            BinaryTreeNode<T>? side;
            while (current is not null)
            {
                var isRight = value.GetHashCode() > current.Value.GetHashCode();
                side = isRight ? current.RightNode : current.LeftNode;

                if (side is null)
                {
                    if (isRight)
                        current.RightNode = null;
                    else
                        current.LeftNode = null;
                    break;
                }

                current = side;
            }
        }

        return false;
    }

    public bool Contants(T value)
    {
        if (value is null)
            return false;

        BinaryTreeNode<T>? current = null;
        while (current is not null)
        {
            current = current is null
                ? _mainNode
                : value.GetHashCode() > current.Value.GetHashCode()
                    ? current.RightNode
                    : current.LeftNode;

            if (value.GetHashCode() == current.Value.GetHashCode())
            {
                _hashCodes.Remove(value.GetHashCode());
                return true;
            }
        }

        return false;
    }

    private void Recreate()
    {
        var hashCodes = _hashCodes.ToArray();
        Array.Sort(hashCodes);

        if (hashCodes[hashCodes.Length / 2] == _mainNode.Value.GetHashCode())
            return;

        _mainNode = null;
    }
}