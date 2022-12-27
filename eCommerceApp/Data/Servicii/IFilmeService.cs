using eCommerceApp.Data.Base;
using eCommerceApp.Data.ViewModels;
using eCommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Data.Servicii
{
    public interface IFilmeService : IEntityBaseRepository<Film>
    {
        Task<Film> GetFilmByIdAsync(int id);
        Task<NFilmDropdownVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NFilmVM data);
        Task UpdateMovieAsync(NFilmVM data);
    }
}
