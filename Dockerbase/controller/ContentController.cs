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
    }
}
