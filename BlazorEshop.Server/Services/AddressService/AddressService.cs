
using BlazorEshop.Shared.DTO;

namespace BlazorEshop.Server.Services.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly BlazoreshopDbContex _context;
        private readonly IAuthService _authService;

        public AddressService(BlazoreshopDbContex context, IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }
        public async Task<ServiceResponseDTO<Address>> AddOrUpdateAddress(Address address)
        {
            var response = new ServiceResponseDTO<Address>();
            var dbAddress = (await GetAddress()).Data;
            if (dbAddress == null)
            {
                address.UserId = _authService.GetUserId();
                _context.Addresses.Add(address);
                response.Data = address;
            }
            else
            {
                dbAddress.FirstName = address.FirstName;
                dbAddress.LastName = address.LastName;
                dbAddress.State = address.State;
                dbAddress.Country = address.Country;
                dbAddress.City = address.City;
                dbAddress.Zip = address.Zip;
                dbAddress.Street = address.Street;
                response.Data = dbAddress;
            }

            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<ServiceResponseDTO<Address>> GetAddress()
        {
            int userId = _authService.GetUserId();
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.UserId == userId);
            return new ServiceResponseDTO<Address> { Data = address };
        }
    }
}
