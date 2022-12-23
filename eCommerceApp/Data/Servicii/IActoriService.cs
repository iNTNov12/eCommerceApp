using eCommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Data.Servicii
{
    public interface IActoriService
    {
        Task<IEnumerable<Actor>> GetAllAsync(); // preia toti actorii din db

        Task<Actor> GetByIdAsync(int id); // intoarce un sg actor

        Task AddAsync(Actor actor); // adauga date in db

        Task<Actor> UpdateAsync(int id, Actor newActor); // updateaza data in bd

        Task DeleteAsync(int id); //sterge data din bd
    }
}
