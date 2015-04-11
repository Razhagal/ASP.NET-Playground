namespace Battleships.Services.Controllers
{
    using System.Web.Http;

    using Battleships.Data;

    public abstract class BaseApiController : ApiController
    {
        private IBattleshipsData data;

        public BaseApiController(IBattleshipsData data)
        {
            this.data = data;
        }

        public IBattleshipsData Data
        {
            get { return this.data; }
        }
    }
}