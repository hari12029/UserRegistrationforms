using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UserRegistration.Model;
using UserRegistration.Model.ViewModels;
using UserRegistration.Service.Interfaces;

namespace UserRegistrationforms.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpGet("GetRegister")]
        public async Task<ApiResponseModel> GetRegister()
        {
            return new ApiResponseModel(await _registerService.GetRegisterList());
        }

        [HttpGet("GetAllStates")]
        public async Task<ApiResponseModel> GetAllStates()
        {
            return new ApiResponseModel(await _registerService.GetStateList());
        }

        [HttpGet("GetAllCitiesByState")]
        public async Task<ApiResponseModel> GetAllCitiesByState(int id)
        {
            return new ApiResponseModel(await _registerService.GetCityListByState(id));
        }

        [HttpGet]
        public async Task<ApiResponseModel> GetRegisterById(int id)
        {
            var register = await _registerService.GetRegister(id);
            if (register == null)
                return new ApiResponseModel("Register not found!");
            return new ApiResponseModel(register);
        }

        [HttpPost("CreateRegister")]
        public async Task<ApiResponseModel> CreateRegister(RegisterViewModel registerViewModel)
        {
            try
            {
                await _registerService.CreateRegister(registerViewModel);
                return new ApiResponseModel("Created a new Register sucessfully");
            }
            catch (Exception ex)
            {
                return new ApiResponseModel(ex);
            }
        }

        [HttpPost("UpdateRegister")]
        public async Task<ApiResponseModel> UpdateRegister(RegisterViewModel registerViewModel)
        {

            try
            {
                await _registerService.UpdateRegister(registerViewModel);
                return new ApiResponseModel("Register Updated Successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponseModel(ex);
            }
        }
   
        [HttpDelete]
        public async Task<ApiResponseModel> DeleteRegister(int id)
        {

            try
            {
                await _registerService.DeleteRegister(id);
                return new ApiResponseModel("Register Deleted Successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponseModel(ex);
            }
        }
    }
}
