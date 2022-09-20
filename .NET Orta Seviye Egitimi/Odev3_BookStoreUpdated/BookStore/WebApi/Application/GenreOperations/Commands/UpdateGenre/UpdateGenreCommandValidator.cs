using System;
using System.Linq;
using FluentValidation;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator:AbstractValidator<UpdateGenreCommand>
    {
       public UpdateGenreCommandValidator()
       {
         RuleFor(command => command.Model.Name).MinimumLength(4).When(x=> x.Model.Name.Trim() != string.Empty);
         //sadece IsActive statusu guncellenmek istenirse isim bos da gonderilebilir,
         //UpdateGenreCommand class'inda bu kontrolu default deger gonderimini kontrol eden
         //ternary if ile sagladik.
         RuleFor(command => command.GenreId).GreaterThan(0);
       }
    }
}