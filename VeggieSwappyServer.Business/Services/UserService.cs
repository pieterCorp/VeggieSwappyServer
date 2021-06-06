using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwappyServer.Business.Dto;
using VeggieSwappyServer.Data.Entities;
using VeggieSwappyServer.Data.Repositories;

namespace VeggieSwappyServer.Business.Services
{
    public class UserService : GenericService<User, UserDto>, IUserService
    {
        private IUserRepo _userRepo;
        public UserService(IGenericRepo<User> genericRepo, IMapper mapper, IUserRepo userRepo)
            : base(genericRepo, mapper)
        {
            _userRepo = userRepo;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            return _mapper.Map<IEnumerable<UserDto>>(await _userRepo.GetUsersAsync());
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            return _mapper.Map<UserDto>(await _userRepo.GetUserByIdAsync(id));
        }
        public async Task<UserWithTradeItemsDto> GetUserWithTradeItemsAsync(int id)
        {
            User user = await _userRepo.GetUserByIdAsync(id);
            UserDto userDto = _mapper.Map<UserDto>(user);
            List<TradeItemDto> userTradeItems = new();
            foreach (var tradeItem in user.UserTradeItems)
            {
                TradeItemDto tradeItemDto = _mapper.Map<TradeItemDto>(tradeItem);
                userTradeItems.Add(tradeItemDto);
            }
            UserWithTradeItemsDto userWithTradeItemsDto = new()
            {
                User = userDto,
                TradeItems = userTradeItems
            };
            return userWithTradeItemsDto;
        }
        public async Task<bool> UpdateUserAsync(UserDto model)
        {
            User user = _mapper.Map<User>(model);
            user.Address = new Address
            {
                Id = model.AddressID,
                PostalCode = model.AddressPostalCode,
                StreetName = model.AddressStreetName,
                StreetNumber = model.AddressStreetNumber
            };
            await _userRepo.UpdateUserAsync(user);
            return true;
        }
        public async Task<IEnumerable<UserTradeItemDto>> GetAllUserTradeItemssAsync()
        {
            List<UserTradeItemDto> userTradeitemDtos = new();
            List<UserTradeItem> userTradeItems = (List<UserTradeItem>)await _userRepo.GetAllUserTradeItemsAsync();

            foreach (var userTradeItem in userTradeItems)
            {
                var uti = _mapper.Map<UserTradeItemDto>(userTradeItem);
                userTradeitemDtos.Add(uti);
            }

            return userTradeitemDtos;
        }
    }
}
