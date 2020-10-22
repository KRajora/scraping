using Microsoft.AspNetCore.Mvc;
using Scraping.BLL.Core.Interfaces;
using Scraping.BLL.Core.Models;
using Scraping.BLL.Services;
using System.Threading.Tasks;

namespace Scraping.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrapeController : ControllerBase
    {
        private readonly ISiteScraping _siteScrapingService;
        public ScrapeController(ISiteScraping siteScrapingService)
        {
            _siteScrapingService = siteScrapingService;
        }

        /// <summary>
        /// Get scrape details of give site
        /// </summary>
        /// <param name="url">target site</param>
        /// <returns></returns>
        [HttpGet("GetSiteScrapeDetails")]
        public async Task<JsonResult> GetSiteScrapeDetails(string url)
        {
            return new JsonResult(await _siteScrapingService.getSiteDetails(url));
        }
    }
}