using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistration.Model.ViewModels;

namespace UserRegistration.Service.Interfaces
{
    public interface IRegisterService
    {
        Task<List<RegisterViewModel>> GetRegisterList();
        Task CreateRegister(RegisterViewModel registerViewModel);
        Task<RegisterViewModel> GetRegister(int id);
        Task UpdateRegister(RegisterViewModel registerViewModel);
        Task DeleteRegister(int id);
        Task<List<StateViewModel>> GetStateList();
        Task<List<CityViewModel>> GetCityListByState(int stateId);
        bool Login(string userName, string password);

    }
}
