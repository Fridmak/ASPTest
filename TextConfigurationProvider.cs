namespace EMPTYASP
{
    public class TextConfigurationProvider : ConfigurationProvider
    {
        public string FilePath { get; set; }
        public TextConfigurationProvider(string filePath)
        {
            FilePath = filePath;
        }

        public override void Load()
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            using (StreamReader textReader = new StreamReader(FilePath))
            {
                string? line;
                while ((line = textReader.ReadLine()) != null)
                {
                    string key = line.Trim();
                    string? value = textReader.ReadLine() ?? "";
                    data.Add(key, value);
                }
            }
            Data = data;
        }
    }
}
