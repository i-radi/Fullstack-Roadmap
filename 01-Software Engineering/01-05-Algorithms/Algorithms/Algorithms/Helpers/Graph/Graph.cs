namespace Algorithms.Helpers.Graph;

public class Graph
{
    private int last_index = 0;
    public Vertex[] Vertices;

    public Graph(string[] names)
    {
        Vertices = new Vertex[names.Length];
        foreach (string name in names)
        {
            this.Vertices[last_index] = new Vertex();
            this.Vertices[last_index].Name = name;
            last_index++;
        }
    }
    public void AddEdges(int vertexIndex, int[] targets)
    {
        this.Vertices[vertexIndex].VertexLinks = new Edge[targets.Length];
        for (int i = 0; i < targets.Length; i++)
        {
            this.Vertices[vertexIndex].VertexLinks[i] =
              new Edge(this.Vertices[vertexIndex],
                       this.Vertices[targets[i]]);
        }
    }
    public List<string> BFS()
    {
        Console.WriteLine("BFS From Graph Class;");
        int v = Vertices.Length;
        Queue<Vertex> q = new Queue<Vertex>(v);
        q.Enqueue(this.Vertices[0]);
        this.Vertices[0].Visited = true;

        List<string> bfsPath = new List<string> { this.Vertices[0].Name };

        while (q.Count > 0)
        {
            Vertex current_vertex = q.Dequeue();
            Edge[] destinations = current_vertex.VertexLinks;
            for (int i = 0; i < destinations.Length; i++)
            {
                if (destinations[i].Target.Visited == false)
                {
                    q.Enqueue(destinations[i].Target);
                    destinations[i].Target.Visited = true;
                    bfsPath.Add(destinations[i].Target.Name);
                }
            }
        }

        RestoreVertices();
        return bfsPath;
    }
    public List<string> DFS()
    {
        Console.WriteLine("DFS From Graph Class;");
        List<string> dfsPath = DFSRecursion(this.Vertices[0]);
        RestoreVertices();
        return dfsPath;
    }
    private List<string> DFSRecursion(Vertex current_vertex)
    {
        current_vertex.Visited = true;
        List<string> path = new List<string> { current_vertex.Name };
        Edge[] destinations = current_vertex.VertexLinks;
        for (int i = 0; i < destinations.Length; i++)
        {
            if (destinations[i].Target.Visited == false)
            {
                List<string> subpath = DFSRecursion(destinations[i].Target);
                path.AddRange(subpath);
            }
        }
        return path;
    }
    public void RestoreVertices()
    {
        foreach (Vertex v in this.Vertices)
        {
            v.Visited = false;
        }
    }
}
