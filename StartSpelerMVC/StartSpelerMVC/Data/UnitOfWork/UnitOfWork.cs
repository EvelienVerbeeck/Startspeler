using StartSpelerMVC.Data.Repository;
using StartSpelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSpelerMVC.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StartSpelerContext _context;

        private IGenericRepo<Bestelling> _bestellingRepository;
        private IGenericRepo<Drankkaart> _drankkaart;
        private IGenericRepo<Evenement> _evenement;
        private IGenericRepo<Inschrijving> _inschrijving;
        private IGenericRepo<Orderlijn> _orderlijn;
        private IGenericRepo<Persoon> _persoon;
        private IGenericRepo<Product> _product;
        private IGenericRepo<ProductType> _productType;

        public UnitOfWork(StartSpelerContext context)
        {
            _context = context;
        }

        public IGenericRepo<Bestelling> BestellingRepository
        {
            get
            {
                if (this._bestellingRepository == null)
                {
                    this._bestellingRepository = new GenericRepo<Bestelling>(_context);
                }
                return _bestellingRepository;
            }
        }

        public IGenericRepo<Drankkaart> DrankkaartRepository
        {
            get
            {
                if (this._drankkaart == null)
                {
                    this._drankkaart = new GenericRepo<Drankkaart>(_context);
                }
                return _drankkaart;
            }
        }

        public IGenericRepo<Evenement> EvenementRepository
        {
            get
            {
                if (this._evenement == null)
                {
                    this._evenement = new GenericRepo<Evenement>(_context);
                }
                return _evenement;
            }
        }

        public IGenericRepo<Inschrijving> InschrijvingRepository
        {
            get
            {
                if (this._inschrijving == null)
                {
                    this._inschrijving = new GenericRepo<Inschrijving>(_context);
                }
                return _inschrijving;
            }
        }

        public IGenericRepo<Orderlijn> OrderlijnRepository
        {
            get
            {
                if (this._orderlijn == null)
                {
                    this._orderlijn = new GenericRepo<Orderlijn>(_context);
                }
                return _orderlijn;
            }
        }

        public IGenericRepo<Persoon> PersoonRepository
        {
            get
            {
                if (this._persoon == null)
                {
                    this._persoon = new GenericRepo<Persoon>(_context);
                }
                return _persoon;
            }
        }

        public IGenericRepo<Product> ProductRepository
        {
            get
            {
                if (this._product == null)
                {
                    this._product = new GenericRepo<Product>(_context);
                }
                return _product;
            }
        }

        public IGenericRepo<ProductType> ProductTypeRepository
        {
            get
            {
                if (this._productType == null)
                {
                    this._productType = new GenericRepo<ProductType>(_context);
                }
                return _productType;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
