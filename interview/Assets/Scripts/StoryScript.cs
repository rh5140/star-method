using Ink.Runtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Reference: https://videlais.com/2019/07/09/unity-ink-part-3-building-an-interface/

public class StoryScript : MonoBehaviour
{
    [SerializeField] TextAsset inkJson;
    [SerializeField] TextMeshProUGUI textUi;
    [SerializeField] Transform choicesTransform;
    [SerializeField] GameObject choiceButtonPrefab;
    [SerializeField] GameObject nextButton;
    [SerializeField] Expander expander;
    
    Story story;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        story = new Story(inkJson.text);
        BindFunctions();
        UpdateStory();
    }

    void BindFunctions()
    {
        story.BindExternalFunction ("generateString", (string source) => {
            GenerateString(source);
        });
        story.BindExternalFunction ("changeColor", (string color) => {
            ChangeColor(color);
        });
    }

    public void UpdateStory()
    {
        if (story.canContinue)
        {
            nextButton.SetActive(true);
            textUi.text = story.Continue();
        }
        else
        {
            nextButton.SetActive(false);
            foreach (Choice choice in story.currentChoices)
            {
                GameObject newButton = Instantiate(choiceButtonPrefab, choicesTransform);
                newButton.GetComponentInChildren<TextMeshProUGUI>().text = choice.text;
                newButton.GetComponent<Button>().onClick.AddListener(delegate {
                    OnClickChoiceButton(choice);
                });
            }
        }
    }

    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        ClearChoices();
        UpdateStory();
    }

    void ClearChoices()
    {
        for (int i = choicesTransform.childCount - 1; i >= 0; i--)
        {
            Destroy(choicesTransform.GetChild(i).gameObject);
        }
    }

    void GenerateString(string source)
    {
        ChangeColor("black");
        string newString = expander.Expand(source);
        story.variablesState["variable_string"] = newString;
    }

    void ChangeColor(string colorName)
    {
        switch (colorName)
        {
            case "white":
                textUi.color = Color.white;
                break;
            case "black":
                textUi.color = Color.black;
                break;
        }
    }
}
