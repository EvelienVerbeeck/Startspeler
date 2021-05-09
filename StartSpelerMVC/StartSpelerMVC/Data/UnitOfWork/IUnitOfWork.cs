using StartSpelerMVC.Data.Repository;
using StartSpelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSpelerMVC.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepo<Bestelling> BestellingRepository { get; }
        IGenericRepo<Drankkaart> Drankkaart { get; }
        IGenericRepo<Evenement> Evenement { get; }
        IGenericRepo<Inschrijving> Inschrijving { get; }
        IGenericRepo<Orderlijn> Orderlijn { get; }
        IGenericRepo<Persoon> Persoon { get; }
        IGenericRepo<Product> Product { get; }
        IGenericRepo<ProductType> ProductType { get; }

        Task Save();
    }
}
