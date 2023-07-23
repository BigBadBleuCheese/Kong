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
			Windows,
			Mac,
			Headless
		}

		public enum Engine
		{
			Unknown = 0,
			Blink,
			Gecko,
			Webkit,
			Sleipnir
		}

		public enum Model
		{
			Unknown = 0,
			iPhone,
			iPad,
			iPod,
			ChromeBook
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
			Safari,
			KMeleon,
			SeaMonkey,
			UcBrowser,
			Sailfish,
			QupZilla,
			Phantom,
			Sleipnir,
			Coast,
			Epiphany,
			Puffin
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
					if (_browser.Sleipnir) return Engine.Sleipnir;
					return Engine.Unknown;
				}
			}

			public Model Model
			{
				get
				{
					if (_browser.iPod) return Model.iPod;
					if (_browser.iPad) return Model.iPad;
					if (_browser.iPhone) return Model.iPhone;
					if (_browser.ChromeBook) return Model.ChromeBook;
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
					if (_browser.KMeleon) return Base.KMeleon;
					if (_browser.SeaMonkey) return Base.SeaMonkey;
					if (_browser.UcBrowser) return Base.UcBrowser;
					if (_browser.Sailfish) return Base.Sailfish;
					if (_browser.QupZilla) return Base.QupZilla;
					if (_browser.Phantom) return Base.Phantom;
					if (_browser.Sleipnir) return Base.Sleipnir;
					if (_browser.Coast) return Base.Coast;
					if (_browser.Epiphany) return Base.Epiphany;
					if (_browser.Puffin) return Base.Puffin;
					return Base.Unknown;
				}
			}

			public OS OS
			{
				get
				{
					if (_browser.Sailfish || _browser.Android) return OS.Android;
					if (_browser.iOS) return OS.iOS;
					if (_browser.ChromeOS || _browser.Linux) return OS.Linux;
					if (_browser.Xbox || _browser.Windows) return OS.Windows;
					if (_browser.Mac) return OS.Mac;
					if (_browser.Phantom) return OS.Headless;
					return OS.Unknown;
				}
			}
		}
	}
}