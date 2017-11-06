using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splash_rss
{
    /// <summary>
    /// Confirms whether or not a user-submitted feed contains RSS data.
    /// </summary>
    public interface IValidator
    {
        bool ValidateFeed(Feed item);
    }
}
