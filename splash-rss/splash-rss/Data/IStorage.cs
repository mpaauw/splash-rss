using System.Collections.Generic;
using splash_rss.Model;

namespace splash_rss.Data
{
    public interface IStorage
    {
        /// <summary>
        /// Loads objects from JSON storage file and serializes them into readable/writable code objects.
        /// </summary>
        void LoadStorage();

        /// <summary>
        /// Writes all code objects currently placed in storage into local data file using JSON serialization.
        /// </summary>
        void SaveStorage();

        /// <summary>
        /// Retrieves all storage data.
        /// </summary>
        /// <returns>List of Feed objects.</returns>
        List<Feed> GetStorage();

        /// <summary>
        /// Inserts a new Feed item to local storage.
        /// </summary>
        /// <param name="item">Feed item to be inserted.</param>
        void AddStorageItem(Feed item);
    }
}
