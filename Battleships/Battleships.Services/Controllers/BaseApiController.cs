namespace Battleships.Services.Controllers
{
    using System.Web.Http;

    using Battleships.Data;

    public abstract class BaseApiController : ApiController
    {
        private IBattleshipsData data;

        protected BaseApiController()
            : this(new BattleshipsData(new ApplicationDbContext()))
        {

        }

        protected BaseApiController(IBattleshipsData data)
        {
            this.data = data;
        }

        protected IBattleshipsData Data
        {
            get { return this.data; }
        }
    }
}