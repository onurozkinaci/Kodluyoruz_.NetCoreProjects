using AutoMapper;
using FluentAssertions;
using TestSetup;
using WebApi.Application.DirectorOperations.Commands.CreateDirector;
using WebApi.DbOperations;

namespace Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateDirectorCommandTests(CommonTestFixture fixture)
        {
           _context = fixture.Context;
           _mapper = fixture.Mapper;
        }

        [Fact]
        public void When_FullNameIsAlreadyExists_InvalidOperationException_ShouldBeReturned()
        {
            //Arrange;
            CreateDirectorCommand command = new CreateDirectorCommand(_context,_mapper);
            command.Model = new CreateDirectorModel(){Name = "David", Surname = "Fincher"}; //this name-surname already exists in test db.
            
            //Act & Assert;
            FluentActions.Invoking(()=>command.Handle())
               .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu ad-soyad ile bir kayit zaten mevcut!");
            
        }

        [Fact]
        public void When_FullNameIsNotExist_Director_ShouldBeCreated()
        {
            //Arrange;
            CreateDirectorCommand command = new CreateDirectorCommand(_context,_mapper);
            command.Model = new CreateDirectorModel(){Name = "Onur", Surname = "Ozkn"}; //not exist fullname(name-surname) in test db.
            
            //Act & Assert;
            FluentActions.Invoking(()=>command.Handle()).Invoke();

            //Assert;
            var director = _context.Yonetmenler.SingleOrDefault(x=>x.Name == command.Model.Name && x.Surname == command.Model.Surname);
            director.Should().NotBeNull();
        }
    }
}