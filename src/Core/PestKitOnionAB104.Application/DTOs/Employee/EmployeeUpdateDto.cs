using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PestKitOnionAB104.Application.DTOs.Employee
{
    public record EmployeeUpdateDto(string Name, int DepartmentId, int PositionId);
}
