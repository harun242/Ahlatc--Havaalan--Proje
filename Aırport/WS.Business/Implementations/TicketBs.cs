using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WS.Business.CustomExceptions;
using WS.Business.Interfaces;
using WS.DataAccess.Interfaces;
using WS.Model.Dtos.Ticket;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class TicketBs : ITicketBs
    {
        private readonly ITicketRepository _repo;
        private readonly IMapper _mapper;

        public TicketBs(ITicketRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

       

        public async Task<ApiResponse<TicketGetDto>> GetByIdAsync(int ticketId, params string[] includeList)
        {
            if (ticketId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var ticket = await _repo.GetByIdAsync(ticketId, includeList);

            if (ticket == null)
                throw new NotFoundException("bu id li ürün bulunamadı");

            var dto = _mapper.Map<TicketGetDto>(ticket);

            return ApiResponse<TicketGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<TicketGetDto>>> GetFeeAsync(decimal min, decimal max, params string[] includeList)
        {
            if (min > max)
                throw new BadRequestException("min değer max değerden büyük olamaz");

            if (min < 0 || max < 0)
                throw new BadRequestException("fiyatlar pozitif değer olmalıdır");

            var tickets = await _repo.GetByFeeAsync(min, max, includeList);

            if (tickets.Count > 0)
            {
                var returnList = _mapper.Map<List<TicketGetDto>>(tickets);

                return ApiResponse<List<TicketGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<TicketGetDto>>> GetPassengerNameAsync(string passengerName, params string[] includeList)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<List<TicketGetDto>>> GetPassengerSurnameAsync(string passengerSurname, params string[] includeList)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<List<TicketGetDto>>> GetTicketAsync(params string[] includeList)
        {
            // IsActive eklemesi
            var tickets = await _repo.GetAllAsync(p => p.IsActive == true, includeList: includeList);

            if (tickets.Count > 0)
            {
                var returnList = _mapper.Map<List<TicketGetDto>>(tickets);

                return ApiResponse<List<TicketGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<Ticket>> InsertAsync(TicketPostDto dto)
        {
            if (dto.PassengerName.Length < 2)
                throw new BadRequestException("yolcu adı en az 2 karakterden oluşmalıdır");

            if (dto.PassengerSurname.Length < 2)
                throw new BadRequestException("yolcu soyadı en az 2 karakterden oluşmalıdır");

            var entity = _mapper.Map<Ticket>(dto);

            var insertedTicket = await _repo.InsertAsync(entity);

            return ApiResponse<Ticket>.Success(StatusCodes.Status201Created, insertedTicket);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(TicketPutDto dto)
        {
            if (dto.PassengerName.Length < 2)
                throw new BadRequestException("yolcu adı en az 2 karakterden oluşmalıdır");

            if (dto.PassengerSurname.Length < 2)
                throw new BadRequestException("yolcu soyadı en az 2 karakterden oluşmalıdır");


            var entity = _mapper.Map<Ticket>(dto);

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
