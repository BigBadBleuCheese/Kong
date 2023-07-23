// ReSharper disable InconsistentNaming
using System;

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
			Unknown = 0,
			Android,
			iOS,
			Linux,
			Windows
		}

		public enum Engine
		{
			Unknown = 0,
			Blink,
			Gecko,
			Webkit
		}

		public enum Model
		{
			Unknown = 0,
			iPhone,
			iPad
		}

		[Flags]
		public enum Trait
		{
			Unknown = 0,
			Mobile = 1,
			Tablet = 2
		}

		public enum Base
		{
			Unknown = 0,
			Chrome,
			Firefox,
			MsEdge,
			Opera,
			Safari
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
			public string OSVersion => _browser.OSVersion;

			public Engine Engine
			{
				get
				{
					if (_browser.Blink) return Engine.Blink;
					if (_browser.Gecko) return Engine.Gecko;
					if (_browser.Webkit) return Engine.Webkit;
					return Engine.Unknown;
				}
			}

			public Model Model
			{
				get
				{
					if (_browser.iPhone) return Model.iPhone;
					if (_browser.iPad) return Model.iPad;
					return Model.Unknown;
				}
			}

			public Trait Trait
			{
				get
				{
					var current = Trait.Unknown;
					if (_browser.Mobile) current |= Trait.Mobile;
					if (_browser.Tablet) current |= Trait.Tablet;
					return current;
				}
			}

			public Base Base
			{
				get
				{
					if (_browser.Chrome) return Base.Chrome;
					if (_browser.Firefox) return Base.Firefox;
					if (_browser.MsEdge) return Base.MsEdge;
					if (_browser.Opera) return Base.Opera;
					if (_browser.Safari) return Base.Safari;
					return Base.Unknown;
				}
			}

			public OS OS
			{
				get
				{
					if (_browser.Android) return OS.Android;
					if (_browser.iOS) return OS.iOS;
					if (_browser.Linux) return OS.Linux;
					if (_browser.Windows) return OS.Windows;
					return OS.Unknown;
				}
			}
		}
	}
}