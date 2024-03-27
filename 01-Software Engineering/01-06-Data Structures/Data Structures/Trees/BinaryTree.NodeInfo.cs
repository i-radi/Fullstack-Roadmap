namespace Data_Structures.Trees;
public partial class BinaryTree<Tdata> where Tdata : IComparable<Tdata>
{
    class NodeInfo
    {
        public TreeNode Node;
        public string Text;
        public int StartPos;
        public int Size { get { return Text.Length; } }
        public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
        public NodeInfo Parent, Left, Right;
    }
}
