using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public List<Tree> Children { get; set; }

    public bool IsLeaf => Children.Count == 0;
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        records = records.OrderBy(q => q.RecordId);

        List<Tree> trees = new List<Tree>(); //Cria uma lista de tree's
        int previousRecordId = 0;

        foreach (var record in records)
        {
            Tree t = new Tree { Children = new List<Tree>(), Id = record.RecordId, ParentId = record.ParentId }; //Cria uma tree com os dados de record
            trees.Add(t); //Adiciona a tree t na lista de tree's

            ValidateTree(previousRecordId, t);
            ++previousRecordId;
        }
        if (trees.Count != 0)
        {
            for (int i = 1; i < trees.Count; i++)
            {
                Tree t = trees.First(x => x.Id == i);
                Tree parent = trees.First(x => x.Id == t.ParentId);
                parent.Children.Add(t);
            }
            return trees.First(t => t.Id == 0);
        }
        throw new ArgumentException(); //Se tree é vazio dá erro
    }

    private static void ValidateTree(int previousRecordId, Tree t)
    {
        if ((t.Id != 0 || t.ParentId != 0) && (t.ParentId >= t.Id || t.Id != previousRecordId)) //Testa se é o root
        {
            throw new ArgumentException();
        }
    }
}