namespace Data_Structures.Trees;
public partial class BinaryTree<Tdata> where Tdata : IComparable<Tdata>
{
    class TreeNode
    {
        public Tdata Data;
        public TreeNode Left;
        public TreeNode Right;
        public TreeNode(Tdata _data)
        {
            this.Data = _data;
        }
    }
}
