namespace AutoFacSample
{
    public interface IServiceLevel
    {
        string GetLevelByLetter(string letter);
    }

    public interface IRepositoryLevel
    {
        string GetLevelByLetter(string letter);
    }

    public class RepositoryLevel : IRepositoryLevel
    {
        public string GetLevelByLetter(string letter)
        {
            if (letter == "A")
            {
                return "L06";
            }

            if (letter == "B")
            {
                return "L10";
            }

            return null;
        }
    }

    public class ServiceLevel : IServiceLevel
    {
        private readonly IRepositoryLevel _repositoryLevel;

        public ServiceLevel(IRepositoryLevel repositoryLevel)
        {
            _repositoryLevel = repositoryLevel;
        }

        public string GetLevelByLetter(string letter)
        {
            return _repositoryLevel.GetLevelByLetter(letter);
        }
    }
}
