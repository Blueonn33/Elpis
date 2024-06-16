namespace Elpis.Data.Repositories.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
	using Elpis.Data;
	using Elpis.Data.Repositories.Interfaces;
	using Elpis.Data.Models;

    public interface IUsersRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsers();
    }
}
