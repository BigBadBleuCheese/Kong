// ReSharper disable InconsistentNaming
namespace Kong
{
	public static class Parser
	{
		public static Parsed Parse(string text)
		{
			var browser = new Browser(text);
			return new Parsed(browser);
		}

		public enum OS
		{
			Unknown = 0
		}

		public sealed class Parsed
		{
			private readonly Browser _browser;

			public Parsed(Browser browser)
			{
				_browser = browser;
			}

			public string Name => _browser.Name;
			public string Version => _browser.Version;

			public OS OS
			{
				get { return OS.Unknown; }
			}
		}
	}
}