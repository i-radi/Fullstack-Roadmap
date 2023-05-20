// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

#region Data Structrue

int[] arr1D = new int[] { 1, 2, 3 };
int[,] arr2D = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
int[][] JaggedArr = new int[2][] {new int[] { 1, 2, 3, 4 }
                                 ,new int[] { 4, 5, 6 } };
Console.WriteLine($"{arr1D.Length} , {arr2D.GetLength(0)} , {JaggedArr.Length}");

var ReadOnlyArray = Array.AsReadOnly(arr1D);

var Index = Array.BinarySearch(arr1D,7);//return negative number
Console.WriteLine(Index);

Array.Clear(arr1D, 0, arr1D.Length);

int[] sourceArr = {1,2,3,4,5,6,7 };
int[] destinationArr = new int[10];
Array.ConstrainedCopy(sourceArr, 2, destinationArr,5,2);

var arrList = new LinkedList<int>();
arrList.AddLast(5);
arrList.AddFirst(4);

HashSet<int> set = new HashSet<int>();
set.Add(1);

Dictionary<string,int> dic = new Dictionary<string,int>();//Hashtable
dic.Add("ID", 250);

SortedDictionary<string, int> sortedDic = new SortedDictionary<string, int>();
SortedList<string, int> sortedList = new SortedList<string, int>();
SortedSet<int> sortedSet = new SortedSet<int>();

Queue<int> Qlist = new Queue<int>();//FIFO
Qlist.Enqueue(1);
Qlist.Enqueue(2);
Qlist.Enqueue(3);
Qlist.Dequeue();

Stack<int> Slist = new Stack<int>();//LIFO
Slist.Push(1);
Slist.Pop();
Slist.Clear();

#endregion 

