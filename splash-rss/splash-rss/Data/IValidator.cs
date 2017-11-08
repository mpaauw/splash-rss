using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using splash_rss.Model;

namespace splash_rss.Data
{
    /// <summary>
    /// Confirms whether or not a user-submitted feed contains RSS data.
    /// </summary>
    public interface IValidator
    {
        bool ValidateFeed(Feed item);
    }
}
