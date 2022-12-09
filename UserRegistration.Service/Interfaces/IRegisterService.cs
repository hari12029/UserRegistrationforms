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
        public Task<List<RegisterViewModel>> GetRegisterList();
        public Task CreateRegister(RegisterViewModel registerViewModel);
        public Task<RegisterViewModel> GetRegister(int id);
        public Task UpdateRegister(RegisterViewModel registerViewModel);
        public Task DeleteRegister(int id);
        public Task<List<StateViewModel>> GetStateList();
        public Task<List<CityViewModel>> GetCityListByState(int stateId);
    }
}
