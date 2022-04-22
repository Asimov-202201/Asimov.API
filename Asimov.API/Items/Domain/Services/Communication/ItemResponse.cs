using Asimov.API.Items.Domain.Models;
using Asimov.API.Shared.Domain.Services.Communication;

namespace Asimov.API.Items.Domain.Services.Communication
{
    public class ItemResponse : BaseResponse<Item>
    {
        public ItemResponse(string message) : base(message)
        {
        }

        public ItemResponse(Item resource) : base(resource)
        {
        }
    }
}