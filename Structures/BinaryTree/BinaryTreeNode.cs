namespace Piligrimm.Structures;

public class BinaryTreeNode<T>
{
    public BinaryTreeNode<T>? LeftNode { get; internal set; }
    public BinaryTreeNode<T>? RightNode { get; internal set; }

    public T Value { get; internal init; }
}