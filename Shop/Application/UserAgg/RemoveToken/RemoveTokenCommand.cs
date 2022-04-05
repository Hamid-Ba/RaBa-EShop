using System;
using Framework.Application;

namespace Application.UserAgg.RemoveToken
{
    public class RemoveTokenCommand : IBaseCommand
	{
        public long UserId { get;private set; }
		public long TokenId { get;private set; }

        public RemoveTokenCommand(long userId, long tokenId)
        {
            UserId = userId;
            TokenId = tokenId;
        }
	}
}