using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    class ApplicationUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Identificacion { get; set; }
        public string CiudadOrigen { get; set; }
        public string? Telefono { get; set; }
    }
}
