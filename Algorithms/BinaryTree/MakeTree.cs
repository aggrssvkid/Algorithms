using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BinaryTree
{
    public class MakeTree
    {
        public static TreeNode MakeBinaryTree(List<TreeNode> arr)
        {
            TreeNode koren = arr[0];
            for (int i = 1; i < arr.Count; i++)
            {
                // po suti iwem mesto dlya vstavki vershini
                var nextNode = koren; // nachinaem poisk s kornya
                var nextNodeIdx = 0; // zapominaem index dlya Parent
                var currentItem = arr[i]; //eto vershina, kotoruyu hotim vstavit
                var currentKey = currentItem.Key;
                while (true)
                {
                    var nextNodeKey = nextNode.Key;
                    if (currentKey <= nextNodeKey)
                    {
                        if (nextNode.Left >= 0)
                        {
                            nextNodeIdx = nextNode.Left;
                            nextNode = arr[nextNode.Left];
                        }
                        else
                        {
                            nextNode.Left = i;
                            currentItem.Parent = nextNodeIdx;
                            break;
                        }
                    }
                    else
                    {
                        if (nextNode.Right >= 0)
                        {
                            nextNodeIdx = nextNode.Right;
                            nextNode = arr[nextNode.Right];

                        }
                        else
                        {
                            nextNode.Right = i;
                            currentItem.Parent = nextNodeIdx;
                            break;
                        }
                    }
                }
            }
            return koren;
        }
    }
}
