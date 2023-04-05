using System.Collections;
using System.Collections.Generic;

namespace treeOrder
{
    public class Program
    {
        static void Main(string[] args)
        {
 // Create the binary tree
        TreeNode root = new TreeNode(3,
            new TreeNode(9,new TreeNode(5)),
            new TreeNode(20,
                new TreeNode(15),
                new TreeNode(7)
            )
        );

        // Call the LevelOrder method to get the level order traversal
        var levelOrder = LevelOrder(root);

        // Print the level order traversal to the console
        Console.WriteLine("Level Order Traversal:");
        foreach (var level in levelOrder)
        {
            Console.Write("[");
            foreach (var val in level)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine("]");
        }
            

        }
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            // we will store result in result list
            var order = new List<IList<int>>();
            Queue<TreeNode> level = new Queue<TreeNode>();
            // take the tree from a particular level starting by root 
            // size(0) = 1
            level.Enqueue(root);
            // null case
            if (root == null)
                return order;

            while (level.Count > 0)
            {
                int size = level.Count; // <- size(0) = 1 then 2, 4, 8, ...
                var currentNodes = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    // get the root
                    var node = level.Dequeue();
                    // get root value (int)
                    currentNodes.Add(node.val);
                    // get (Enqueue) children if not null (size doubles at each level)
                    if (node.left != null)
                        level.Enqueue(node.left);
                    if (node.right != null)
                        level.Enqueue(node.right);
                }
                order.Add(currentNodes);
            }
            return order;
        }

    }
}