using System.Collections.Generic;
using UnityEngine;

public class ParseTsv : MonoBehaviour
{
    [SerializeField] TextAsset tsv;
    public Dictionary<string, List<string>> rules;

    void Awake()
    {
        PopulateDictionary();
    }

    void PopulateDictionary()
    {
        rules = new Dictionary<string, List<string>>();
        string[] lines = tsv.text.Split('\n');
        string[] columnHeaders = lines[0].Split('\t');
        foreach (string header in columnHeaders)
        {
            rules[header] = new List<string>();
        }

        for (int i = 1; i < lines.Length; i++)
        {
            string[] row = lines[i].Split('\t');
            for (int j = 0; j < row.Length; j++)
            {
                rules[columnHeaders[j]].Add(row[j]);
            }
        }
    }
}
