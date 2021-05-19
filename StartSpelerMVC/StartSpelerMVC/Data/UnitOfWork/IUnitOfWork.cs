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
        IGenericRepo<Drankkaart> DrankkaartRepository { get; }
        IGenericRepo<Evenement> EvenementRepository { get; }
        IGenericRepo<Inschrijving> InschrijvingRepository { get; }
        IGenericRepo<Orderlijn> OrderlijnRepository { get; }
        IGenericRepo<Persoon> PersoonRepository { get; }
        IGenericRepo<Product> ProductRepository { get; }
        IGenericRepo<ProductType> ProductTypeRepository { get; }

        Task Save();
    }
}
