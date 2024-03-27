namespace Data_Structures.Trees;
public partial class BinaryTree<Tdata> where Tdata : IComparable<Tdata>
{
    TreeNode Root;

    public void Insert(Tdata _data)
    {
        TreeNode newNode = new TreeNode(_data);
        if (this.Root == null)
        {
            this.Root = newNode;
            return;
        }
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.enqueue(this.Root);
        while (q.hasData())
        {
            TreeNode currentNode = q.dequeue();
            if (currentNode.Left == null)
            {
                currentNode.Left = newNode;
                break;
            }
            else
            {
                q.enqueue(currentNode.Left);
            }

            if (currentNode.Right == null)
            {
                currentNode.Right = newNode;
                break;
            }
            else
            {
                q.enqueue(currentNode.Right);
            }
        }
    }
    public int Height()
    {
        return internalHeight(this.Root);
    }
    int internalHeight(TreeNode node)
    {
        if (node == null) return 0;
        return 1 + Math.Max(
          internalHeight(node.Left),
          internalHeight(node.Right)
          );
    }
    public void PreOrder()
    {
        internalPreOrder(this.Root);
        Console.WriteLine("");
    }
    void internalPreOrder(TreeNode node)
    {
        if (node == null) return;
        Console.Write(node.Data + " -> ");
        internalPreOrder(node.Left);
        internalPreOrder(node.Right);
    }
    public void InOrder()
    {
        internalInOrder(this.Root);
        Console.WriteLine("");
    }
    void internalInOrder(TreeNode node)
    {
        if (node == null) return;
        internalInOrder(node.Left);
        Console.Write(node.Data + " -> ");
        internalInOrder(node.Right);
    }
    public void PostOrder()
    {
        internalPostOrder(this.Root);
        Console.WriteLine("");
    }
    void internalPostOrder(TreeNode node)
    {
        if (node == null) return;
        internalPostOrder(node.Left);
        internalPostOrder(node.Right);
        Console.Write(node.Data + " -> ");
    }
}
