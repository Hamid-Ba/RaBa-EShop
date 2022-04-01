using Application.UserAgg.AddAddress;
using Application.UserAgg.DeleteAddress;
using Application.UserAgg.EditAddress;
using Framework.Application;
using Query.UserAgg.DTOs;

namespace Presentation.Facade.UserAgg.UserAddress
{
    public interface IUserAddressFacade
	{
        #region Command
        Task<OperationResult> Add(AddAddressCommand command);
        Task<OperationResult> Edit(EditAddressCommand command);
        Task<OperationResult> Delete(DeleteAddressCommand command);
        #endregion

        #region Query
        Task<List<UserAddressDto>> GetAllBy(long userId);
        #endregion
    }
}