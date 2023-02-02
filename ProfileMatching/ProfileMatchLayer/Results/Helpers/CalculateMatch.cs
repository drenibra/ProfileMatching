using System.Linq;

namespace ProfileMatching.ProfileMatchLayer.Results.Helpers
{
    public class CalculateMatch
    {
        public int CountSimilarities(string jobRequirements, string skills)
        {
            string[] jobReqs = jobRequirements.Split(" ");
            string[] applicantSkills = skills.Split(" ");
            var similarities = jobReqs.Intersect(applicantSkills).ToList();
            return similarities.Count;
        }
        public double GetPercentage(int number, string jobRequirements)
        {
            try
            {
                string[] jobReqs = jobRequirements.Split(" ");
                int length = jobReqs.Length;
                double result = ((double)number / length) * 100;
                return result;
            }catch(Exception)
            {
                return 0;
            }
        }
    }
}
