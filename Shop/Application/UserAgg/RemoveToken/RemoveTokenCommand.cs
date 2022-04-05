using System;
using Framework.Application;

namespace Application.UserAgg.RemoveToken
{
    public class RemoveTokenCommand : IBaseCommand
	{
        public long UserId { get; set; }
		public long TokenId { get; set; }

        public RemoveTokenCommand(long userId, long tokenId)
        {
            UserId = userId;
            TokenId = tokenId;
        }
	}
}