class Heap<T> where T : IComparable<T>
{
    private List<T> keys = new List<T>();

    public int Count => keys.Count;

    // Get the smallest
    public T Get()
    {
        return keys[0];
    }

    public void Insert(T k)
    {
        keys.Add(k);
        SiftUp(Count - 1);
    }

    public void DeleteSmallest()
    {
        keys[0] = keys[Count - 1];
        keys.RemoveAt(Count - 1);
        if (Count > 0) SiftDown(0);
    }

    private void SiftUp(int k)
    {
        if (keys[Parent(k)].CompareTo(keys[k]) > 0)
        {
            Swap(k, Parent(k));
            SiftUp(Parent(k));
        }
    }

    private void SiftDown(int k)
    {
        int left = LeftChild(k);
        int right = RightChild(k);
        int smallest = k;

        if (left < Count && keys[left].CompareTo(keys[k]) < 0)
        {
            smallest = left;
        }

        if (right < Count && keys[right].CompareTo(keys[k]) < 0)
        {
            smallest = right;
        }

        if (smallest != k)
        {
            Swap(k, smallest);
            SiftDown(smallest);
        }

    }

    private int Parent(int k)
    {
        return (k - 1) / 2;
    }

    private int LeftChild(int k)
    {
        return 2 * k + 1;

    }

    private int RightChild(int k)
    {
        return 2 * k + 2;
    }

    private void Swap(int a, int b)
    {
        T temp = keys[a];
        keys[a] = keys[b];
        keys[b] = temp;
    }
}