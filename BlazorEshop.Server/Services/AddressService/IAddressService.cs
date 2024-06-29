using BlazorEshop.Shared.DTO;

namespace BlazorEshop.Server.Services.AddressService
{
    public interface IAddressService
    {
        Task<ServiceResponseDTO<Address>> GetAddress();
        Task<ServiceResponseDTO<Address>> AddOrUpdateAddress(Address address);
    }
}
