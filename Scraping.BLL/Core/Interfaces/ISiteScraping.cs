using Scraping.BLL.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scraping.BLL.Core.Interfaces
{
    public interface ISiteScraping
    {
        Task<SiteDetails> getSiteDetails(string url);
    }
}
