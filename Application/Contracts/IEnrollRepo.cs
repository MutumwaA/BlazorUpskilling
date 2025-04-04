using Domain.EntityVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IEnrollRepo
    {
        Task<bool> EnrollStudentAsync(EnrollmentVM request);
    }
}
