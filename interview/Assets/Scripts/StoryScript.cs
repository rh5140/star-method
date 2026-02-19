using Ink.Runtime;
using TMPro;
using UnityEngine;

public class StoryScript : MonoBehaviour
{
    [SerializeField] TextAsset inkJson;
    [SerializeField] TextMeshProUGUI textUi;
    Story _story;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _story = new Story(inkJson.text);

        string newText = _story.Continue();

        textUi.text = newText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
