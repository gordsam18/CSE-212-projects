using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // initiatialize the pairSet as a HashSet 
        HashSet<string> pairSet = new HashSet<string>();

        // Initialize the result array to hold the origianal and symmetric (reveresed) pairs 
        List<string> result = new List<string>();

        foreach (string pair in words) 
        {
            // Take each pair and it to a reveresed array 
            string symmetricPair = new string(pair.Reverse().ToArray()); 

            // Check to see if each reverese pair has a matching set and also tcheck if pair is  the same as symmetric pair
            if (pairSet.Contains(symmetricPair) && pair != symmetricPair )
            {
                // add matching pair to list 
                string pairs = string.Compare(pair, symmetricPair) < 0 ? $"{pair} & {symmetricPair}" : $"{symmetricPair} & {pair}";

                result.Add(pairs);
                Console.WriteLine(pairs);


                // remove the matching pairs from the set 
                pairSet.Remove(pair);
                pairSet.Remove(symmetricPair);

            }
            
        }
        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');

            // Make sure the line has enough fields
            if (fields.Length > 3)
            {
                var degree = fields[3].Trim();  // Get the 4th column (index 3) and remove any extra whitespace

                // Update the count in the dictionary
                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Normalize the words to lowercase and replace speaces 
        word1 = word1.ToLower().Replace(" ", "");
        word2 = word2.ToLower().Replace(" ", "");

        // The keys in the dictionary will be characters, and the values will be the frequency of those characters.
        
        // check to see if matching length strings 
        if (word1.Length != word2.Length)
        {
            return false;
        }
        // Check to see if the strings are already anagrams
        if (word1 == word2)
        {
            return true;
        }

        // Count the frequency of each character in both words by using a dictionary
        // Create dictionaries to store character frequencies
        Dictionary<char, int> anagram1 = new Dictionary<char, int>();
        Dictionary<char, int> anagram2 = new Dictionary<char, int>();

        foreach (char c in word1) 
        {
            if (anagram1.ContainsKey(c))
            {
                anagram1[c]++;
            }
            else 
            {
                anagram1[c] = 1;
            }
        }

        foreach (char c in word2)
        {
            if (anagram2.ContainsKey(c))
            {
                anagram2[c]++;
            }
            else
            {
                anagram2[c] = 1; 
            }
        }

        // Compare frequencies
        foreach (var pair in anagram1)
        {
            if (!anagram2.ContainsKey(pair.Key) || anagram2[pair.Key] != pair.Value)
                return false;
        }
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
  public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        if (featureCollection == null || featureCollection.Features == null)
        {
            return Array.Empty<string>();
        }

        var earthquakeSummaries = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            var place = feature?.Properties?.Place ?? "Unknown location";
            var magnitude = feature?.Properties?.Mag;

            string magnitudeString = magnitude.HasValue 
                ? $"{magnitude.Value:0.0}" 
                : "Not available";
            earthquakeSummaries.Add($"Location: {place} - Mag {magnitudeString}");
        }
        return earthquakeSummaries.ToArray();
    }
}