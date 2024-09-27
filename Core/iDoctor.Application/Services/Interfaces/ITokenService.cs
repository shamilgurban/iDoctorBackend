using iDoctor.Application.Dtos.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDoctor.Application.Services.Interfaces
{
    public interface ITokenService
    {
        TokenDto GenerateJwtToken(TokenCreateDto request);
    }
}
