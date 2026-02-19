using System.Collections.Generic;
using UnityEngine;

public class Expander : MonoBehaviour
{
    ParseTsv parser;
    Dictionary<string, List<string>> rules;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        parser = GetComponent<ParseTsv>();
    }

    void Start()
    {
        // POSSIBLE RACE CONDITION...
        rules = parser.rules;
    }

    // From class reference material

    public void Test(string symbol)
    {
        Debug.Log(Expand(symbol));
    }

    public string Expand(string symbol, int depth = 10)
    {
        // fix later but it misses symbols at the end of a rule
        if (depth > 500) // Need to identify better stopping condition
        {
            return "";
        }

        if (!rules.ContainsKey(symbol))
        {
            return symbol;
        }

        string rule = RandomStringFromList(rules[symbol]);

        foreach (var key in rules.Keys)
        {
            string token = "{" + key + "}";
            if (rule.Contains(token))
            {
                rule = rule.Replace(token, Expand(key, depth + 1));
            }
        }
        return rule;
    }

    string RandomStringFromList(List<string> values)
    {
        int rand = Random.Range(0, values.Count);
        return values[rand];
    }
}
