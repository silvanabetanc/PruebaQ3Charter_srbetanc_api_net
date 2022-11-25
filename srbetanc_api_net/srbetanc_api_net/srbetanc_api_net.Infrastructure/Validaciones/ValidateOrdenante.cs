using FluentValidation;
using srbetanc_api_net.Entity;
using srbetanc_api_net.Entity.Services.ServiceName.Entrada;

namespace srbetanc_api_net.Infrastructure.Validaciones
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidateOrdenante : AbstractValidator<EProveedor>
    {
        /// <summary>
        /// 
        /// </summary>
        public ValidateOrdenante()
        {
            RuleFor(eOrdenante => eOrdenante.Ordenante.Identificacion)
                .NotEmpty().WithMessage(EConstantes.IdentificacionDescription).WithErrorCode(EConstantes.IdentificacionErrorCode)
                .WithMessage(EConstantes.IdentificacionDescription).WithErrorCode(EConstantes.IdentificacionErrorCode);

        }
    }
}