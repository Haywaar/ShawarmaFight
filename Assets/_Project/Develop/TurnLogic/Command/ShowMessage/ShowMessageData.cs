using System.Collections.Generic;

public class ShowMessageData : CommandData
{
    public List<string> Sentences;

    public ShowMessageData(List<string> sentences)
    {
        Sentences = sentences;
    }
}