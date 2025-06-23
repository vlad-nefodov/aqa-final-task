namespace Business.Abstractions
{
    public abstract class PageConfiguration
    {
        private static string? _baseUrl;
        private static ILocatorProvider? _locatorProvider;

        public static string BaseUrl
        {
            get => _baseUrl ?? throw new InvalidOperationException("BaseUrl is not set.");
            set => _baseUrl = value?.TrimEnd('/');
        }

        public static ILocatorProvider LocatorProvider
        {
            get => _locatorProvider ?? throw new InvalidOperationException("LocatorProvider is not set.");
            set => _locatorProvider = value;
        }

        public static ILogger? Logger { get; set; }
    }
}
