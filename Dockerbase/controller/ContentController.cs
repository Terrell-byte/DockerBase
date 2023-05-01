using DockerBase.model;
using System.Data;

namespace DockerBase.controller
{
    internal class ContentController
    {
        private ContentModel _model;

        public ContentController()
        {
            _model = new ContentModel();
        }

        public DataTable DatabaseInfo(string password, string port)
        {
            return _model.GetContent(password, port);
        }
        public DataTable GetRecentEntries(string password, string port)
        {
            // Get all the entries in the database
            DataTable allEntries = _model.GetContent(password, port);

            // If there are no entries, return an empty DataTable
            if (allEntries.Rows.Count == 0)
            {
                return new DataTable();
            }

            // Sort the entries by the date_added column in descending order
            DataView sortedView = allEntries.DefaultView;
            sortedView.Sort = "date_added DESC";
            DataTable sortedTable = sortedView.ToTable();

            // Select the username and date_added columns from the sorted DataTable
            var selectedEntries = sortedTable.AsEnumerable()
                .Take(8)
                .Select(row => new { Username = row.Field<string>("username"), DateAdded = row.Field<DateTime>("date_added") });

            // Convert the selected entries into a collection of DataRow objects
            DataTable recentEntries = new DataTable();
            recentEntries.Columns.Add("Username", typeof(string));
            recentEntries.Columns.Add("DateAdded", typeof(DateTime));
            foreach (var entry in selectedEntries)
            {
                recentEntries.Rows.Add(entry.Username, entry.DateAdded);
            }

            return recentEntries;
        }


    }
}
