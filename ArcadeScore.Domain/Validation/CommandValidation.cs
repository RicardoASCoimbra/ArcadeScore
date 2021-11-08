using ArcadeScore.Domain.Core.Commands;
using FluentValidation;

namespace ArcadeScore.Domain.Validation
{
    public class CommandValidation<T> : AbstractValidator<T> where T : Command
    {
    }
}
