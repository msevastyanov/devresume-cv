using System.Threading.Tasks;
using DevResume.Domain.Entities;
using DevResume.Domain.Models;
using DevResume.Domain.ViewModels;

namespace DevResume.ServiceLayer.Services
{
    public interface IUserService
    {
        Task<RequestResult<ApplicationUser>> CreateAccount(CreateUser model);
    }
}