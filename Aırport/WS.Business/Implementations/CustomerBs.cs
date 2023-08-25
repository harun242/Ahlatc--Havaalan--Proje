using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WS.Business.CustomExceptions;
using WS.Business.Interfaces;
using WS.DataAccess.Interfaces;
using WS.Model.Dtos.Customer;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class CustomerBs : ICustomerBs
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public CustomerBs(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
  

        public async Task<ApiResponse<List<CustomerGetDto>>> GetAddressAsync(string address, params string[] includeList)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<CustomerGetDto>> GetByIdAsync(int customerId, params string[] includeList)
        {

            if (customerId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var customer = await _repo.GetByIdAsync(customerId, includeList);

            if (customer == null)
                throw new NotFoundException("bu id li ürün bulunamadı");

            var dto = _mapper.Map<CustomerGetDto>(customer);

            return ApiResponse<CustomerGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetCustomerAsync(params string[] includeList)
        {
            // IsActive eklemesi
            var customers = await _repo.GetAllAsync(p => p.IsActive == true, includeList: includeList);

            if (customers.Count > 0)
            {
                var returnList = _mapper.Map<List<CustomerGetDto>>(customers);

                return ApiResponse<List<CustomerGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetNameAsync(string name, params string[] includeList)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetSurnameAsync(string surname, params string[] includeList)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<Customer>> InsertAsync(CustomerPostDto dto)
        {
            if (dto.Name.Length < 2)
                throw new BadRequestException(" adı en az 2 karakterden oluşmalıdır");

            if (dto.Surname.Length < 2)
                throw new BadRequestException(" soyadı en az 2 karakterden oluşmalıdır");

            if (dto.Address.Length < 2)
                throw new BadRequestException(" adres en az 2 karakterden oluşmalıdır");

            var entity = _mapper.Map<Customer>(dto);

            var insertedCustomer = await _repo.InsertAsync(entity);

            return ApiResponse<Customer>.Success(StatusCodes.Status201Created, insertedCustomer);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CustomerPutDto dto)
        {
            if (dto.Address.Length <= 0)
                throw new BadRequestException("adres en az 2 karakterden oluşmalıdır");

            if (dto.Name.Length < 2)
                throw new BadRequestException(" adı en az 2 karakterden oluşmalıdır");

            if (dto.Surname.Length < 2)
                throw new BadRequestException(" soyadı en az 2 karakterden oluşmalıdır");


            var entity = _mapper.Map<Customer>(dto);

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
