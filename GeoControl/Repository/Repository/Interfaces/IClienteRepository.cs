﻿using Common;
using Dapper;
using Model.Cliente;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IClienteRepository
    {
      Task<CommonResult<ClienteModel>> Cliente_Crea(ClienteModel clienteModel);
      Task<CommonResult<ClienteModel>> Cliente_Elim(string CodCliente);
      Task<CommonResult<ClienteModel>> Cliente_ConsUn(string CodCliente);
      Task<CommonResult<ClienteListModel>> Cliente_Cons();
      Task<CommonResult<GrupoCorpListModel>> GrupoCorporativo_Cons();
      Task<CommonResult<TipDocIdnListModel>> TipoDocIdn_Cons();
     





        Task<CommonResult<SucursalModel>> Sucursal_Crea(SucursalModel sucursalModel);
        Task<CommonResult<SucursalModel>> Sucursal_ConsUn(int IdSucursal);
        Task<CommonResult<SucursalModel>> Sucursal_Elim(int IdSucursal);
        Task<CommonResult<SucursalListModel>> Sucursal_Cons();
        Task<CommonResult<SucursalxcodcliListModel>> Sucursal_XCodClienteCons(string CodCliente);



    }
}
