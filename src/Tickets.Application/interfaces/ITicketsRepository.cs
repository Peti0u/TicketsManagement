using Tickets.Domain.entities;
namespace Tickets.Application.interfaces;
public interface ITicketsRepository
{
    Task<List<Tickets>>  GetAllAsync();         // R.etrieve (R) from C.R.U.D
    Task<Tickets?>       GetByIdAsync(int id);  // GUID R.etrieve (R) from C.R.U.D 
    Task<Tickets>        AddAsync(Tickets request); // C.reate (C).R.U.D 
    Task<Tickets?>       UpdateAsync(Tickets request); //U.pdate(U) C.R.U.D 
    Task<bool>                  DeleteAsync(int id);                 //D.elete(D) C.R.U.D 
}