using AutoMapper;
using WebApi.Application.ActorOperations.Commands.CreateActor;
using WebApi.Application.ActorOperations.Commands.UpdateActor;
using WebApi.Application.ActorOperations.Queries.GetActors;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.Application.DirectorOperations.Commands.CreateDirector;
using WebApi.Application.DirectorOperations.Commands.UpdateDirector;
using WebApi.Application.DirectorOperations.Queries.GetDirectors;
using WebApi.Application.FilmOperations.Commands.CreateFilm;
using WebApi.Application.FilmOperations.Commands.UpdateFilm;
using WebApi.Application.FilmOperations.Queries.GetFilms;
using WebApi.Application.OrderOperations.Commands.CreateOrder;
using WebApi.Application.OrderOperations.Queries.GetOrders;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile:Profile
    {
       public MappingProfile()
       {
          //--Film--;
          CreateMap<Film,MovieVM>()
          .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
          .ForMember(dest => dest.Yonetmen, opt => opt.MapFrom(src => src.Yonetmen.Name + " " 
          + src.Yonetmen.Surname));
          CreateMap<CreateFilmModel,Film>();
          CreateMap<UpdateFilmModel,Film>();

         //--Customer--;
         CreateMap<CreateCustomerModel,Customer>();

         //---Oyuncu/Actor--;
         CreateMap<Oyuncu,ActorVM>();
         CreateMap<CreateActorModel,Oyuncu>();
         CreateMap<UpdateActorModel,Oyuncu>();

         //--Yonetmen-Director--;
         CreateMap<CreateDirectorModel,Yonetmen>();
         CreateMap<UpdateDirectorModel,Yonetmen>();
         CreateMap<Yonetmen,DirectorVM>();

         //--Siparislerim-Order--;
         CreateMap<CreateOrderModel,Siparislerim>();
         CreateMap<Siparislerim,OrderVM>()
         .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.Name + " " + src.Customer.Surname))
         .ForMember(dest => dest.Film, opt => opt.MapFrom(src => src.Film.Name));
         //.ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.IsActive));

       }
    }
}