using AutoMapper;
using System.Linq;
using VeggieSwappyServer.Business.Dto;
using VeggieSwappyServer.Business.MappedModels;
using VeggieSwappyServer.Data.Entities;

namespace VeggieSwappyServer.Business
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Resource, ResourceDto>().ReverseMap();
            CreateMap<CurrentTradeProposal, TradeProposalModel>().ReverseMap();
            CreateMap<RejectedTradeProposal, TradeProposalModel>().ReverseMap();

            CreateMap<ProposedTradeItem, TradeItemDto>()
                .ForMember(d => d.ResourceId, x => x.MapFrom(y => y.Resource.Id))
                .ForMember(d => d.ResourceName, x => x.MapFrom(y => y.Resource.Name))
                .ForMember(d => d.ResourceImageUrl, x => x.MapFrom(y => y.Resource.ImageUrl))               
                .ReverseMap();

            CreateMap<UserTradeItem, TradeItemDto>()                
                .ForMember(d => d.ResourceId, x => x.MapFrom(y => y.Resource.Id))
                .ForMember(d => d.ResourceName, x => x.MapFrom(y => y.Resource.Name))
                .ForMember(d => d.ResourceImageUrl, x => x.MapFrom(y => y.Resource.ImageUrl))               
                .ReverseMap();

            CreateMap<Trade, TradeDto>()                
                .ForMember(d => d.ProposingUserId, x => x.MapFrom(y => y.CurrentTradeProposal.ProposingUserId))

                .ForMember(d => d.User1_Id, x => x.MapFrom(y => y.User1Id))
                .ForMember(d => d.User1_FirstName, x => x.MapFrom(y => y.Users[0].FirstName))
                .ForMember(d => d.User1_LastName, x => x.MapFrom(y => y.Users[0].LastName))

                .ForMember(d => d.User2_Id, x => x.MapFrom(y => y.User2Id))
                .ForMember(d => d.User2_FirstName, x => x.MapFrom(y => y.Users[1].FirstName))
                .ForMember(d => d.User2_LastName, x => x.MapFrom(y => y.Users[1].LastName))

                .ForMember(d => d.TradeItemsUser1, x => x.MapFrom(y => y.Users[0].UserTradeItems))
                .ForMember(d => d.TradeItemsUser2, x => x.MapFrom(y => y.Users[1].UserTradeItems))

                .ForMember(d => d.ProposedTradeItemsUser1, x => x.MapFrom(y => y.CurrentTradeProposal.ProposedTradeItems.Where(x => x.UserId == y.Users[0].Id)))
                .ForMember(d => d.ProposedTradeItemsUser2, x => x.MapFrom(y => y.CurrentTradeProposal.ProposedTradeItems.Where(x => x.UserId == y.Users[1].Id)))
                .ReverseMap();


            CreateMap<CurrentTradeProposal, RejectedTradeProposal>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Trade, TradeHistoryDto>()                
                .ForMember(d => d.User1_Id, x => x.MapFrom(y => y.User1Id))
                .ForMember(d => d.User1_FirstName, x => x.MapFrom(y => y.Users[0].FirstName))
                .ForMember(d => d.User1_LastName, x => x.MapFrom(y => y.Users[0].LastName))
                .ForMember(d => d.User2_Id, x => x.MapFrom(y => y.User2Id))
                .ForMember(d => d.User2_FirstName, x => x.MapFrom(y => y.Users[1].FirstName))
                .ForMember(d => d.User2_LastName, x => x.MapFrom(y => y.Users[1].LastName))
                .ForMember(d => d.TimesRejected, x => x.MapFrom(y => y.RejectedTradeProposals.Count))
                .ForMember(d => d.TradeStatus, x => x.MapFrom(y => y.TradeStatus.ToString()))
                .ReverseMap();

            CreateMap<User, UserDto>()
                .ForMember(d => d.AddressID, x => x.MapFrom(y => y.Address.Id))
                .ForMember(d => d.AddressPostalCode, x => x.MapFrom(y => y.Address.PostalCode))
                .ForMember(d => d.AddressStreetName, x => x.MapFrom(y => y.Address.StreetName))
                .ForMember(d => d.AddressStreetNumber, x => x.MapFrom(y => y.Address.StreetNumber))                
                .ReverseMap();

            CreateMap<UserTradeItem, UserTradeItemDto>()
            .ForMember(d => d.Id, x => x.MapFrom(y => y.Id))
            .ForMember(d => d.UserId, x => x.MapFrom(y => y.UserId))
            .ForMember(d => d.UserFirstName, x => x.MapFrom(y => y.User.FirstName))
            .ForMember(d => d.UserLastName, x => x.MapFrom(y => y.User.LastName))
            .ForMember(d => d.UserPostalCode, x => x.MapFrom(y => y.User.Address.PostalCode))
            .ForMember(d => d.ResourceId, x => x.MapFrom(y => y.ResourceId))
            .ForMember(d => d.ResourceName, x => x.MapFrom(y => y.Resource.Name))
            .ForMember(d => d.ResourceImageUrl, x => x.MapFrom(y => y.Resource.ImageUrl))
            .ForMember(d => d.Amount, x => x.MapFrom(y => y.Amount));

        }
    }
}
