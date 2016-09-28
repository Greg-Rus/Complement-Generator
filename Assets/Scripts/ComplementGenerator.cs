using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;

public class ComplementGenerator : MonoBehaviour {
    public TextAsset adverbs;
    public TextAsset adjectives;
    public TextAsset descriptions;
    public TextAsset nouns;
    public Text complimentTextBox;

    private string[] adverbList;
    private string[] adjectiveList;
    private string[] descriptionList;
    private string[] nounList;
    private char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
    private HashSet<char> vowelSet;
    // Use this for initialization
    void Start() {  
        adverbList = adverbs.text.Split('\n');
        adjectiveList = adjectives.text.Split('\n');
        descriptionList = descriptions.text.Split('\n');
        nounList = nouns.text.Split('\n');
        MakeListsLowerCase();
        vowelSet = new HashSet<char>(vowels);
    }

    private void MakeListsLowerCase()
    {
        LowerAll(adverbList);
        LowerAll(adjectiveList);
        LowerAll(descriptionList);
        LowerAll(nounList);
    }

    public void OnComplimentButtonPress()
    {
        complimentTextBox.text = GenerateCompliment();
    }

    private string GenerateCompliment()
    {
        StringBuilder compliment = new StringBuilder();
        compliment.Append("You are ");
        string startWord = FindRandomWordInList(adverbList);
        if (vowelSet.Contains(startWord[0]))
        {
            compliment.Append("an ");
        }
        else
        {
            compliment.Append("a ");
        }
        compliment.Append(startWord);
        compliment.Append(" ");
        compliment.Append(FindRandomWordInList(adjectiveList));
        compliment.Append(" ");
        compliment.Append(FindRandomWordInList(descriptionList));
        compliment.Append(" of ");
        compliment.Append(FindRandomWordInList(nounList));
        compliment.Append("!");
        return compliment.ToString();
    }

    private string FindRandomWordInList(string[] words)
    {
        int wordIndex = UnityEngine.Random.Range(0, words.Length);
        return words[wordIndex];
    }

    private void LowerAll(string[] list)
    {
        for (int i = 0; i < list.Length; ++i)
        {
            list[i] = list[i].ToLower();
        }
    }

    private string ToLowerCase(string line)
    {
        return line.ToLower();
    }
}
