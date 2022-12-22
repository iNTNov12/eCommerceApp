using eCommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Data.Servicii
{
    public interface IActoriService
    {
        Task<IEnumerable<Actor>> GetAll(); // preia toti actorii din db

        Actor GetById(int id); // intoarce un sg actor

        void Add(Actor actor); // adauga date in db

        Actor Update(int id, Actor newActor); // updateaza data in bd

        void Delete(int id); //sterge data din bd
    }
}
