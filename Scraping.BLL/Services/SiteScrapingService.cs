using HtmlAgilityPack;
using Scraping.BLL.Core.Interfaces;
using Scraping.BLL.Core.Models;
using ScrapySharp.Html;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraping.BLL.Services
{
    public class SiteScrapingService : BrowserFactory, ISiteScraping
    {
        public async Task<SiteDetails> getSiteDetails(string url)
        {
            SiteDetails details = new SiteDetails();
            WebPage page = await getWebPage(url);
            details.Title = getTitle(page);
            details.SiteName = page.AbsoluteUrl.ToString();
            details.Hyperlinks = getHyperLinks(page);
            return details;
        }

        private async Task<WebPage> getWebPage(string url)
        {
            return await _browser.NavigateToPageAsync(new Uri(url));
        }

        //get page title
        private string getTitle(WebPage page)
        {
            HtmlNode title = page.Html.SelectSingleNode("//title");
            if (title != null)
                return title.InnerText;
            return "";
        }

        //get page hyperlinks
        private List<string> getHyperLinks(WebPage page)
        {
            List<string> hyperLinks = new List<string>();
            var links = page.Html.SelectNodes("//a[@href]").ToList();
            foreach (var link in links)
            {
                if (link.Attributes["href"].Value.Contains(page.AbsoluteUrl.Authority))
                {
                    hyperLinks.Add(link.Attributes["href"].Value);
                }
            }
            return hyperLinks;
        }

        //get page hyperlinks
        private List<string> getSocialMediaLinks(WebPage page)
        {
            List<string> hyperLinks = new List<string>();
            var links = page.Html.SelectNodes("//a[@href]").ToList();
            foreach (var link in links)
            {
                if (link.Attributes["href"].Value.Contains(page.AbsoluteUrl.Authority))
                {
                    hyperLinks.Add(link.Attributes["href"].Value);
                }
            }
            return hyperLinks;
        }

        //get page hyperlinks
        private string getScreenShot(WebPage page)
        {
            string _path = ConfigurationManager.GetSection("assets").ToString();
            _path = $"{_path}{Guid.NewGuid()}";
           page.SaveSnapshot(_path);
            return _path;
        }
    }
}
