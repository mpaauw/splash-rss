using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace splash_rss.Interface
{
    public interface IConsoleManager
    {
        /// <summary>
        /// Includes presentation and navigation elements which enable top-level browsing of a Feed's SyndicationItem objects.
        /// </summary>
        /// <param name="data">A List of all SyndicationItems retrieved from a Feed.</param>
        /// <param name="cursorPosition">The starting cursor position relative to the list of items being presented to the console.</param>
        void NavigateTopics(List<SyndicationItem> data, int cursorPosition);

        /// <summary>
        /// Prints a list of SyndicationItem objects to the console.
        /// </summary>
        /// <param name="data">A list of all SynidcationItem objects to be printed to the console.</param>
        void PrintTopics(List<SyndicationItem> data);

        /// <summary>
        /// Prints various unsanitized HTML data from a SyndicationItem object to the console.
        /// </summary>
        /// <param name="datum">The SyndicationItem object from which to retrieve printable HTML.</param>
        void PrintTopicData(SyndicationItem datum);

        /// <summary>
        /// Maximizes the console window automatically to fit the executing machine's screen area.
        /// </summary>
        void MaximizeConsoleWindow();
    }
}
