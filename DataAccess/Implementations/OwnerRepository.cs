using Core;
using DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class OwnerRepository : IRepository<Owner>
    {
        private static int Id { get; set; }
        public Owner Create(Owner entity)
        {
            try
            {
            Id++;
            entity.Id = Id;
            DataContext.Owners.Add(entity);

            }
            catch (Exception)
            {

                throw;
            }
            return entity;
        }

        public void Delete(Owner entity)
        {
            try
            {
                DataContext.Owners.Remove(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Owner Get(Predicate<Owner> filter = null)
        {
            try
            {
                if (filter!=null)
                {
                    return DataContext.Owners.Find(filter);
                }
                else
                {
                    return DataContext.Owners[0];
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Owner> GetAll(Predicate<Owner> filter=null)
        {
            try
            {
                if (filter != null)
                {
                return DataContext.Owners.FindAll(filter);

                }
                else
                {
                    return DataContext.Owners;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Owner entity)
        {
            try
            {
                var owner = DataContext.Owners.Find(o=>o.Id==entity.Id);
                if (owner!=null)
                {
                    
                    owner.Name = entity.Name;
                    owner.Surname = entity.Surname;
                    owner.Age = entity.Age;
                    
                }
              
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
