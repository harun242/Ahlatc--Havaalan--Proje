using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WS.Business.CustomExceptions;
using WS.Business.Interfaces;
using WS.DataAccess.Interfaces;
using WS.Model.Dtos.Employee;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class EmployeeBs : IEmployeeBs
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;

        public EmployeeBs(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

      

        public async Task<ApiResponse<EmployeeGetDto>> GetByIdAsync(int employeeId, params string[] includeList)
        {
            if (employeeId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var employee = await _repo.GetByIdAsync(employeeId, includeList);

            if (employee == null)
                throw new NotFoundException("bu id li ürün bulunamadı");

            var dto = _mapper.Map<EmployeeGetDto>(employee);

            return ApiResponse<EmployeeGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetEmailAsync(string email, params string[] includeList)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeeAsync(params string[] includeList)
        {
            // IsActive eklemesi
            var employees = await _repo.GetAllAsync(p => p.IsActive == true, includeList: includeList);

            if (employees.Count > 0)
            {
                var returnList = _mapper.Map<List<EmployeeGetDto>>(employees);

                return ApiResponse<List<EmployeeGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetNameAsync(string name, params string[] includeList)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<List<EmployeeGetDto>>> GetSurnameAsync(string surname, params string[] includeList)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<Employee>> InsertAsync(EmployeePostDto dto)
        {
            if (dto.Name.Length < 2)
                throw new BadRequestException(" adı en az 2 karakterden oluşmalıdır");

            if (dto.Surname.Length < 2)
                throw new BadRequestException(" soyadı en az 2 karakterden oluşmalıdır");

            if (dto.Email.Length < 2)
                throw new BadRequestException(" email adresi en az 2 karakterden oluşmalıdır");

            var entity = _mapper.Map<Employee>(dto);

            var insertedEmployee = await _repo.InsertAsync(entity);

            return ApiResponse<Employee>.Success(StatusCodes.Status201Created, insertedEmployee);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(EmployeePutDto dto)
        {
            if (dto.Name.Length < 2)
                throw new BadRequestException(" adı en az 2 karakterden oluşmalıdır");

            if (dto.Surname.Length < 2)
                throw new BadRequestException(" soyadı en az 2 karakterden oluşmalıdır");

            if (dto.Email.Length < 2)
                throw new BadRequestException(" email adresi en az 2 karakterden oluşmalıdır");

            var entity = _mapper.Map<Employee>(dto);

            await _repo.UpdateAsync(entity);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id pozitif bir değer olmalıdır");

            var entity = await _repo.GetByIdAsync(id);

            // IsActive False döndürme
            entity.IsActive = false;

            await _repo.UpdateAsync(entity);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
