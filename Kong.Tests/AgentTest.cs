using Xunit;

namespace Kong.Tests
{
	public class AgentTest
	{
		[Theory]
		[InlineData("Microsoft Edge", "14.14393", "10", "Windows MsEdge Gecko Unknown Unknown",
			"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.79 Safari/537.36 Edge/14.14393")]
		[InlineData("Chrome", "55.0", "10", "Windows Chrome Blink Unknown Unknown",
			"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36")]
		[InlineData("Safari", "9.0", "9.1", "iOS Safari Webkit iPhone Mobile",
			"Mozilla/5.0 (iPhone; CPU iPhone OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1")]
		[InlineData("Safari", "9.0", "9.1", "iOS Safari Webkit iPad Tablet",
			"Mozilla/5.0 (iPad; CPU OS 9_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Version/9.0 Mobile/13B143 Safari/601.1")]
		[InlineData("Chrome", "55.0", "5.1.1", "Android Chrome Blink Unknown Mobile",
			"Mozilla/5.0 (Linux; Android 5.1.1; Nexus 6 Build/LYZ28E) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Mobile Safari/537.36")]
		[InlineData("Chrome", "55.0", "5.0", "Android Chrome Blink Unknown Mobile",
			"Mozilla/5.0 (Linux; Android 5.0; SM-G900P Build/LRX21T) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Mobile Safari/537.36")]
		[InlineData("Chrome", "114.0", "10", "Windows Chrome Blink Unknown Unknown",
			"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36")]
		[InlineData("Firefox", "115.0", "10", "Windows Firefox Gecko Unknown Unknown",
			"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/115.0")]
		[InlineData("Chrome", "114.0", null, "Linux Chrome Blink Unknown Unknown",
			"Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36")]
		[InlineData("Firefox", "115.0", null, "Linux Firefox Gecko Unknown Unknown",
			"Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:109.0) Gecko/20100101 Firefox/115.0")]
		[InlineData("Opera", "100.0", null, "Linux Opera Blink Unknown Unknown",
			"Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36 OPR/100.0.0.0")]
		[InlineData("Microsoft Edge", "114.0", null, "Linux MsEdge Gecko Unknown Unknown",
			"Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36 Edg/114.0.1823.82")]
		[InlineData("Chrome", "114.0", "10", "Android Chrome Blink Unknown Mobile",
			"Mozilla/5.0 (Linux; Android 10; K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Mobile Safari/537.36")]
		[InlineData("Chrome", "114.0", "10", "Android Chrome Blink Unknown Mobile",
			"Mozilla/5.0 (Linux; Android 10) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Mobile Safari/537.36")]
		[InlineData("Firefox", "115.0", null, "Linux Firefox Gecko Unknown Unknown",
			"Mozilla/5.0 (X11; Linux x86_64; rv:109.0) Gecko/20100101 Firefox/115.0")]
		[InlineData("Firefox", "115.0", "10", "Android Firefox Gecko Unknown Mobile",
			"Mozilla/5.0 (Android 10; Mobile; rv:109.0) Gecko/115.0 Firefox/115.0")]
		[InlineData("QupZilla", "7.0.8", "7", "Windows QupZilla Blink Unknown Unknown",
			"Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) QupZilla/7.0.8 Chrome/61.0.3163.140 Safari/537.36")]
		[InlineData("Chrome", "99.0", null, "Windows Chrome Blink Unknown Unknown",
			"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.74 Safari/537.36 Xbox Live Client/2.0.17003.0")]
		[InlineData("UC Browser", "13.9.5.1176", "12", "Android UcBrowser Blink Unknown Mobile",
			"Mozilla/5.0 (Linux; U; Android 12; zh-CN; LSA-AN00 Build/HONORLSA-AN00) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/78.0.3904.108 UCBrowser/13.9.5.1176 Mobile Safari/537.36")]
		[InlineData("Android", "4.0", "4.0.4", "Android Unknown Webkit Unknown Tablet",
			"Mozilla/5.0 (Linux; U; Android 4.0.4; en-us; cm_tenderloin Build/IMM76L; CyanogenMod-9) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Safari/534.30")]
		[InlineData("Sleipnir", "", null, "Unknown Sleipnir Sleipnir Unknown Unknown",
			"Sleipnir/200 CFNetwork/1335.0.3 Darwin/21.6.0")]
		[InlineData("SeaMonkey", "9995", "7", "Windows SeaMonkey Gecko Unknown Unknown",
			"Mozilla/5.0 (Windows NT 6.1; WOW64; rv:38.0) Gecko/20100101 Firefox/38.0 SeaMonkey/9995")]
		[InlineData("Sailfish", "1.0", null, "Android Sailfish Gecko Unknown Mobile",
			"Mozilla/5.0 (Maemo; Linux; U; Jolla; Sailfish; Mobile; rv:31.0) Gecko/31.0 Firefox/31.0 SailfishBrowser/1.0")]
		[InlineData("QupZilla", "7.0.8", "8", "Windows QupZilla Blink Unknown Unknown",
			"Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) QupZilla/7.0.8 Chrome/61.0.3163.140 Safari/537.36")]
		[InlineData("Puffin", "7.7", "7.1.2", "Android Puffin Blink Unknown Mobile",
			"Mozilla/5.0 (Linux; Android 7.1.2; LM-X415S Build/N2G47H; ko-kr) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.139 Mobile Safari/537.36 Puffin/7.7.8.31160AP")]
		[InlineData("PhantomJS", "", null, "Headless Phantom Webkit Unknown Unknown",
			"Mozilla/5.0 (Vodafone/1.0/LG-T505/V10c AppleWebkit/531 Browser/Phantom/V2.0 Widget/LGMW/3.0 MMS/LG-MMS-V1.0/1.2 Java/ASVM/1.1 Profile/MIDP-2.1 Configuration/CLDC-1.1)")]
		[InlineData("Chrome", "98.0", "11", "Android Chrome Blink Unknown Mobile",
			"Mozilla/5.0 (Linux; Android 11; SM-G977B Build/RP1A.200720.012) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/98.0.4758.87 Mobile Safari/537.36 Maxthon/9900")]
		[InlineData("Chrome", "46.0", null, "Linux Chrome Blink ChromeBook Unknown",
			"Chromebook/ Mozilla/5.0 (X11; CrOS armv7l 4537.56.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.86 Safari/537.36")]
		[InlineData("Chrome", "112.0", null, "Linux Chrome Blink ChromeBook Unknown",
			"Mozilla/5.0 (X11; CrOS x86_64 14541.0.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36 [ip:194.218.221.226]")]
		[InlineData("Opera Coast", "5.04", "11.4", "iOS Coast Webkit iPhone Mobile",
			"Mozilla/5.0 (iPhone; CPU iPhone OS 11_4 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Coast/5.04.110603 Mobile/15F79 Safari/7534.48.3")]
		[InlineData("Epiphany", "606.0.0", null, "Linux Epiphany Webkit Unknown Unknown",
			"Mozilla/5.0 (Linux x86_64) AppleWebKit/606.0.0 (KHTML, like Gecko) Version/12.0 Safari/606.0.0 Epiphany/606.0.0")]
		[InlineData("Firefox", "115.0", "13.4", "Mac Firefox Gecko Unknown Unknown",
			"Mozilla/5.0 (Macintosh; Intel Mac OS X 13.4; rv:109.0) Gecko/20100101 Firefox/115.0")]
		[InlineData("Chrome", "113.0", null, "Unknown Chrome Blink Unknown Unknown",
			"Mozilla/5.0 AppleWebKit/537.36 (KHTML, like Gecko; compatible; Googlebot/2.1; +http://www.google.com/bot.html) Chrome/113.0.5672.127 Safari/537.36")]
		[InlineData("Safari", "10.0", "10.3.2", "iOS Safari Webkit iPod Mobile",
			"Mozilla/5.0 (iPod touch; CPU iPhone OS 10_3_2 like Mac OS X) AppleWebKit/603.2.4 (KHTML, like Gecko) Version/10.0 Mobile/14F89 Safari/602.1")]
		[InlineData("K-Meleon", "88.0", "10.9", "Mac KMeleon Gecko Unknown Unknown",
			"Mozilla/5.0 (Macintosh; Intel Mac OS X 10.9; rv:21.0) Gecko/20100101 K-meleon/88.0")]
		public void CheckUserAgent(string name, string ver, string ov, string os, string text)
		{
			var kong = Parser.Parse(text);
			Assert.Equal(name, kong.Name);
			Assert.Equal(ver, kong.Version);
			Assert.Equal(ov, kong.OSVersion);
			var tmp = $"{kong.OS} {kong.Base} {kong.Engine} {kong.Model} {kong.Trait}";
			Assert.Equal(os, tmp);
		}
	}
}