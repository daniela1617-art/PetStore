using System;
using System.Collections.Generic;
using System.Text;

namespace DTCMKEMG.BusinessLogic.DTOs
{
    public class RolesResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }

    public class CreateRoleRequest
    {
        public string Name { get; set; } = null!;
    }

    public class UpdateRoleRequest
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}