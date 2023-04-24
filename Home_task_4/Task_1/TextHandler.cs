using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1
{
    internal class TextHandler
    {
        private static readonly string[] endingPunctuationMarks = { ".", "!", "?", "...." };

        public string[] SearchStrings(string[] text)
        {
            List<string> sentences = new List<string>();
            int index = 0;

            while (index < text.Length)
            {
                CreateSentence(text, ref index, sentences);
            }

            return sentences.Where(item => item.Contains('(') && item.Contains(')')).ToArray();
        }
//можна простіше.
        private void CreateSentence(string[] text, ref int index, List<string> sentences)
        {
            string[] parts = text[index].Split(endingPunctuationMarks, StringSplitOptions.RemoveEmptyEntries);

            parts = AddSentencesWithEllipsis(text, parts, index);

            if (sentences.Count != 0 && sentences.Last().Contains(parts.First()))
                sentences.AddRange(parts.Skip(1));
            else
                sentences.AddRange(parts);

            int id = index;
            if (!endingPunctuationMarks.Any(x => text[id].EndsWith(x)) && index + 1 < text.Length)
            {
                index++;
                parts = text[index].Split(endingPunctuationMarks, StringSplitOptions.RemoveEmptyEntries);

                parts = AddSentencesWithEllipsis(text, parts, index);

                sentences[sentences.Count - 1] += " " + parts.First();
            }
            else
            {
                index++;
            }
        }

        private string[] AddSentencesWithEllipsis(string[] text, string[] parts, int index)
        {
            if (text[index].Contains("..."))
            {
                if (parts.Length == 2)
                {
                    parts[0] = string.Join("... ", parts);
                    parts = RemoveElement(parts, 1);
                }
                else
                {
                    for (int i = 0; i < parts.Length - 1; i++)
                    {
                        string chekingSentence = parts[i] + "..." + parts[i + 1];
                        if (text[index].Contains(chekingSentence))
                        {
                            parts[i] = parts[i] + "..." + parts[i + 1];
                            parts = RemoveElement(parts, i + 1);
                            i--;

                        }
                    }
                }

            }
            return parts;
        }

        private string[] RemoveElement(string[] strings, int indexToRemove)
        {
            string[] newStrings = new string[strings.Length - 1];
            Array.Copy(strings, 0, newStrings, 0, indexToRemove);
            Array.Copy(strings, indexToRemove + 1, newStrings, indexToRemove, strings.Length - indexToRemove - 1);
            return newStrings;
        }
    }
}
