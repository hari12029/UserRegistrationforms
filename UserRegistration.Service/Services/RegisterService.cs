using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistration.Model.ViewModels;
using UserRegistration.Repository.Database;
using UserRegistration.Repository.Repository;
using UserRegistration.Service.Interfaces;

namespace UserRegistration.Service.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IRepository<Register> _registerRepository;
        private readonly IRepository<State> _stateRepository;
        private readonly IRepository<City> _cityRepository;

        public RegisterService(IRepository<Register> registerRepository, IRepository<State> stateRepository, IRepository<City> cityRepository)
        {
            _registerRepository = registerRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
        }

        public async Task<List<StateViewModel>> GetStateList()
        {
            IEnumerable<State> stateList = await _stateRepository.GetAll();
            var stateViewModel = stateList.Select(x => new StateViewModel
            {
                Id = x.Id,
                StateName = x.StateName
            });
            return stateViewModel.ToList();
        }

        public async Task<List<CityViewModel>> GetCityListByState(int stateId)
        {
            IEnumerable<City> cityList = await _cityRepository.GetAll(x => stateId);
            var cityViewModel = cityList.Select(x => new CityViewModel
            {
                Id = x.Id,
                CityName = x.CityName
            });
            return cityViewModel.ToList();
        }

        public async Task<List<RegisterViewModel>> GetRegisterList()
        {
            IEnumerable<Register> registerList = await _registerRepository.GetAll();

            var registerViewModel = registerList.Select(x => new RegisterViewModel
            {
                Id = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                City = x.City,
                ConfirmPassword = x.ConfirmPassword,
                Dob = x.Dob,
                Email = x.Email,
                Password = x.Password,
                Mobile = x.Mobile,
                Gender = x.Gender,
                State = x.State,
            });

            return registerViewModel.ToList();

        }
        public async Task CreateRegister(RegisterViewModel registerViewModel)
        {
            Register register = new()
            {
                Firstname = registerViewModel.Firstname,
                Lastname = registerViewModel.Lastname,
                City = registerViewModel.City,
                ConfirmPassword = registerViewModel.ConfirmPassword,
                Dob = registerViewModel.Dob,
                Email = registerViewModel.Email,
                Password = registerViewModel.Password,
                Mobile = registerViewModel.Mobile,
                Gender = registerViewModel.Gender,
                State = registerViewModel.State,
               
            };

            await _registerRepository.Add(register);
        }
        public async Task<RegisterViewModel> GetRegister(int id)
        {
            Register register = _registerRepository.GetById(id).GetAwaiter().GetResult(); ;

            RegisterViewModel registerViewModel = new()
            {
                Id = register.Id,
                Firstname = register.Firstname,
                Lastname = register.Lastname,
                City = register.City,
                ConfirmPassword = register.ConfirmPassword,
                Dob = register.Dob,
                Email = register.Email,
                Password = register.Password,
                Mobile = register.Mobile,
                Gender = register.Gender,
                State = register.State,
            };

            return registerViewModel;
        }
        public async Task UpdateRegister(RegisterViewModel registerViewModel)
        {
            Register register = _registerRepository.GetById(registerViewModel.Id).GetAwaiter().GetResult(); ;
            if(register != null)
            {
                register.Firstname = registerViewModel.Firstname;
                register.Lastname = registerViewModel.Lastname;
                register.Mobile = registerViewModel.Mobile;
                register.Password = registerViewModel.Password;
                register.ConfirmPassword = registerViewModel.ConfirmPassword;
                register.City = registerViewModel.City;
                register.Email = registerViewModel.Email;
                register.State = registerViewModel.State;
                register.Dob = registerViewModel.Dob;
                register.Gender = registerViewModel.Gender;
            }

            await _registerRepository.Update(register);
        }
        public async Task DeleteRegister(int id)
        {
            await _registerRepository.Delete(id);

        }
    }
}
