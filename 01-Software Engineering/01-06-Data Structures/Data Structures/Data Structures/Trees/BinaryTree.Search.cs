namespace Data_Structures.Trees
{
    public partial class BinaryTree<Tdata> where Tdata : IComparable<Tdata>
    {
        public void Balance()
        {
            List<Tdata> nodes = new List<Tdata>();
            InOrderToArray(this.Root, nodes);
            this.Root = RecursiveBalance(0, nodes.Count - 1, nodes);
        }
        public void BsDelete(Tdata _data)
        {
            NodeAndParent nodeAndParentInfo = this.FindNodeAndParent(_data);
            if (nodeAndParentInfo.Node == null) return;

            if (nodeAndParentInfo.Node.Left != null && nodeAndParentInfo.Node.Right != null)
            {
                BSDelete_Has_Childs(nodeAndParentInfo.Node);
            }
            else if (nodeAndParentInfo.Node.Left != null ^ nodeAndParentInfo.Node.Right != null)
            {
                BSDelete_Has_One_Child(nodeAndParentInfo.Node);
            }
            else
            {
                BSDelete_leaf(nodeAndParentInfo);
            }

        }
        public void BSInsert(Tdata _data)
        {
            TreeNode newNode = new TreeNode(_data);
            if (this.Root == null)
            {
                this.Root = newNode;
                return;
            }
            TreeNode currentNode = this.Root;
            while (currentNode != null)
            {
                if (currentNode.Data.CompareTo(_data) > 0) // currentNode.Data > data
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = newNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Left;
                    }
                }
                else
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = newNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.Right;
                    }
                }
            }
        }
        public bool IsExsit(Tdata _data)
        {
            return BSFind(_data) != null;
        }
        void BSDelete_Has_Childs(TreeNode nodeToDelete)
        {
            TreeNode currentNode = nodeToDelete.Right;
            TreeNode parent = null;
            while (currentNode.Left != null)
            {
                parent = currentNode;
                currentNode = currentNode.Left;
            }
            if (parent != null)
            {
                parent.Left = currentNode.Right;
            }
            else
            {
                nodeToDelete.Right = currentNode.Right;
            }

            nodeToDelete.Data = currentNode.Data;

        }
        void BSDelete_Has_One_Child(TreeNode nodeToDelete)
        {
            TreeNode nodeToReplace = null;
            if (nodeToDelete.Left != null)
            {
                nodeToReplace = nodeToDelete.Left;
            }
            else
            {
                nodeToReplace = nodeToDelete.Right;
            }
            nodeToDelete.Data = nodeToReplace.Data;
            nodeToDelete.Left = nodeToReplace.Left;
            nodeToDelete.Right = nodeToReplace.Right;
        }
        void BSDelete_leaf(NodeAndParent nodeAndParentInfo)
        {
            if (nodeAndParentInfo.Parent == null)
            {
                this.Root = null;
            }
            else
            {
                if (nodeAndParentInfo.isLeft)
                {
                    nodeAndParentInfo.Parent.Left = null;
                }
                else
                {
                    nodeAndParentInfo.Parent.Right = null;
                }
            }

        }
        TreeNode BSFind(Tdata _data)
        {
            TreeNode currentNode = this.Root;
            while (currentNode != null)
            {
                if (currentNode.Data.CompareTo(_data) == 0)
                {
                    return currentNode;
                }
                else if (currentNode.Data.CompareTo(_data) > 0)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }
            return null;
        }
        NodeAndParent FindNodeAndParent(Tdata _data)
        {
            TreeNode currentNode = this.Root;
            TreeNode Parent = null;
            NodeAndParent nodeAndParentInfo = null;
            bool left = false;
            while (currentNode != null)
            {
                if (currentNode.Data.CompareTo(_data) == 0)
                {
                    nodeAndParentInfo = new NodeAndParent() { Node = currentNode, Parent = Parent, isLeft = left };
                    break;
                }
                else if (currentNode.Data.CompareTo(_data) > 0)
                {
                    Parent = currentNode;
                    left = true;
                    currentNode = currentNode.Left;
                }
                else
                {
                    Parent = currentNode;
                    left = false;
                    currentNode = currentNode.Right;
                }
            }
            return nodeAndParentInfo;
        }
        void InOrderToArray(TreeNode node, List<Tdata> nodes)
        {
            if (node == null) return;
            InOrderToArray(node.Left, nodes);
            nodes.Add(node.Data);
            InOrderToArray(node.Right, nodes);
        }
        TreeNode RecursiveBalance(int start, int end, List<Tdata> nodes)
        {
            if (start > end) return null;
            int mid = (start + end) / 2;
            TreeNode newNode = new TreeNode(nodes[mid]);
            newNode.Left = RecursiveBalance(start, mid - 1, nodes);
            newNode.Right = RecursiveBalance(mid + 1, end, nodes);
            return newNode;
        }
    }
}