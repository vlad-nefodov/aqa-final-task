using Business.Abstractions;

namespace Core.Adapters
{
    public class LocatorProvider : ILocatorProvider
    {
        public Locator Id(string idToFind)
        {
            return new Locator(LocatorType.Id, idToFind);
        }

        public Locator Name(string nameToFind)
        {
            return new Locator(LocatorType.Name, nameToFind);
        }

        public Locator XPath(string xpathToFind)
        {
            return new Locator(LocatorType.XPath, xpathToFind);
        }
    }
}
