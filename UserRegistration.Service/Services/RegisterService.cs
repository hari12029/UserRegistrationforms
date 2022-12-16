using System;
using System.Collections.Generic;
using System.Linq;
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
            IEnumerable<City> cityList = await _cityRepository.GetAll(x => x.StateId == stateId);
            var cityViewModel = cityList.Select(x => new CityViewModel
            {
                Id = x.Id,
                CityName = x.CityName,
                StateId = x.StateId
            });
            return cityViewModel.ToList();
        }

        public async Task<List<RegisterViewModel>> GetRegisterList()
        {
            IEnumerable<Register> registerList = await _registerRepository.GetAll(x=> x.Gender, y=> y.State, z=>z.City);

            var registerViewModel = registerList.Select(x => new RegisterViewModel
            {
                Id = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Dob = x.Dob?.ToString("yyyy/MM/dd"),
                Email = x.Email,
                Password = x.Password,
                Mobile = x.Mobile,
                Gender = x.Gender.Name,
                State = x.State.StateName,
                City = x.City.CityName,
                //GenderId = x.GenderId,
                //StateId = x.StateId,
                //CityId = x.CityId
               
            });

            return registerViewModel.ToList();

        }
        public async Task CreateRegister(RegisterViewModel registerViewModel)
        {
            Register register = new()
            {
                Firstname = registerViewModel.Firstname,
                Lastname = registerViewModel.Lastname,
                Dob = Convert.ToDateTime(registerViewModel.Dob),
                Email = registerViewModel.Email,
                Password = registerViewModel.Password,
                Mobile = registerViewModel.Mobile,
                GenderId = registerViewModel.GenderId,
                StateId = registerViewModel.StateId,
                CityId = registerViewModel.CityId
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
                Dob = register.Dob?.ToString("yyyy/MM/dd"),
                Email = register.Email,
                Password = register.Password,
                GenderId = register.GenderId,
                Mobile = register.Mobile,
                StateId = register.StateId,
                CityId = register.CityId
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
                register.Email = registerViewModel.Email;
                register.Dob = Convert.ToDateTime(registerViewModel.Dob);
                register.GenderId = registerViewModel.GenderId;
                register.Mobile = registerViewModel.Mobile;
                register.StateId = registerViewModel.StateId;
                register.CityId = registerViewModel.CityId;
            }

            await _registerRepository.Update(register);
        }
        public async Task DeleteRegister(int id)
        {
            await _registerRepository.Delete(id);

        }

        public bool Login(string userName, string password)
        {
            bool isExist = true;
            Register register = _registerRepository.GetAll(x => x.Email == userName && x.Password == password).GetAwaiter().GetResult().FirstOrDefault();
            if(register == null)
            {
                isExist = false;
            }

            return isExist;
        }

    }
}
