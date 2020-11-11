using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovitumHomeTask.Model;

namespace NovitumHomeTask.DataAccess
{
    public interface IRegionRepository
    {
        /// <summary>
        /// Gets all Novads from the database
        public List<Novads> GetAllNovads();
    }
}
