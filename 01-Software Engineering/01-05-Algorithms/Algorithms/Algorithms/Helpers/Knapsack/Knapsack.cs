namespace Algorithms.Helpers.Knapsack
{
    public class Knapsack
    {
        public int MaxCapacity { get; }
        public int CurrentCapacity { get; private set; }
        public float TotalValue { get; private set; }
        public List<Item> Items { get; private set; }

        public Knapsack(int maxCapacity)
        {
            MaxCapacity = maxCapacity;
            CurrentCapacity = 0;
            TotalValue = 0;
            Items = new List<Item>();
        }

        public bool CanAddItem(Item newItem)
        {
            return CurrentCapacity + newItem.Weight <= MaxCapacity;
        }

        public void AddItem(Item newItem)
        {
            if (CanAddItem(newItem))
            {
                Items.Add(newItem);
                CurrentCapacity += newItem.Weight;
                TotalValue += newItem.Value;
            }
        }

        public override string ToString()
        {
            return $"Capacity: {CurrentCapacity}\nTotal value: {TotalValue}";
        }
    }

    public class Item
    {
        public string Name { get; }
        public float Value { get; }
        public int Weight { get; }
        public float Ratio { get; }

        public Item(float value, int weight, string name)
        {
            Name = name;
            Value = value;
            Weight = weight;
            Ratio = value / weight;
        }
    }

    public class KnapsackSolver
    {
        public static Knapsack SolveFractionalKnapsack(int[] values, int[] weights, int maxCapacity)
        {
            List<Item> items = new List<Item>();

            for (int i = 0; i < values.Length; i++)
            {
                Item newItem = new Item(values[i], weights[i], "#" + i.ToString());
                items.Add(newItem);
            }

            items.Sort((x, y) => y.Ratio.CompareTo(x.Ratio));

            Knapsack bag = new Knapsack(maxCapacity);
            foreach (var item in items)
            {
                if (bag.CanAddItem(item))
                {
                    bag.AddItem(item);
                }
            }

            return bag;
        }
    }
}
