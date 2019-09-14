using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implements
{
  public  class Conexion:IConexion
    {
        private readonly IConfiguration _Configuration;
        public Conexion(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        string Ccn = "";
        public string GetConexion()
        {
            Ccn = _Configuration.GetConnectionString("DefaultConnection");
            return Ccn;
        }


    }
}
