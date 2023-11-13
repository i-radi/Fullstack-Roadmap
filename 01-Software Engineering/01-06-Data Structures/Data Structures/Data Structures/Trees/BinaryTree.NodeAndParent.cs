namespace Data_Structures.Trees;
public partial class BinaryTree<Tdata> where Tdata : IComparable<Tdata>
{
    class NodeAndParent
    {
        public TreeNode Node;
        public TreeNode Parent;
        public bool isLeft;
    }
}
