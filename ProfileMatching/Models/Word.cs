namespace ProfileMatching.Models
{
    public class Word:Document
    {
        public string LastUpdated { get; set; }

        public override void Update()
        {
            this.LastUpdated = DateTime.Now.ToString("d");
        }
    }
}
