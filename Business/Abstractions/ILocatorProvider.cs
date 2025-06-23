namespace Business.Abstractions
{
    public interface ILocatorProvider
    {
        public Locator Id(string idToFind);

        public Locator Name(string nameToFind);

        public Locator XPath(string xpathToFind);
    }
}
