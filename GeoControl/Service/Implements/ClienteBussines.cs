using Bussines.Interfaces;
using Common;
using Model.Cliente;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Implements
{
  public  class ClienteBussines : IClienteBussines
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteBussines(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Task<CommonResult<ClienteListModel>> Cliente_Cons()
        {
            return _clienteRepository.Cliente_Cons();
        }

        public Task<CommonResult<ClienteModel>> Cliente_ConsUn(string CodCliente)
        {
            return _clienteRepository.Cliente_ConsUn(CodCliente);
        }

        public Task<CommonResult<ClienteModel>> Cliente_Crea(ClienteModel clienteModel)
        {
            return _clienteRepository.Cliente_Crea(clienteModel);
        }

        public Task<CommonResult<ClienteModel>> Cliente_Elim(string CodCliente)
        {
            return _clienteRepository.Cliente_Elim(CodCliente);
        }

        public Task<CommonResult<GrupoCorpListModel>> GrupoCorporativo_Cons()
        {
            return _clienteRepository.GrupoCorporativo_Cons();
        }

        public Task<CommonResult<TipDocIdnListModel>> TipoDocIdn_Cons()
        {
            return _clienteRepository.TipoDocIdn_Cons();
        }




        public Task<CommonResult<SucursalListModel>> Sucursal_Cons()
        {
            return _clienteRepository.Sucursal_Cons();
        }

        public Task<CommonResult<SucursalModel>> Sucursal_ConsUn(int IdSucursal)
        {
            return _clienteRepository.Sucursal_ConsUn(IdSucursal);
        }

        public Task<CommonResult<SucursalModel>> Sucursal_Crea(SucursalModel sucursalModel)
        {
            return _clienteRepository.Sucursal_Crea(sucursalModel);
        }

        public Task<CommonResult<SucursalModel>> Sucursal_Elim(int IdSucursal)
        {
            return _clienteRepository.Sucursal_Elim(IdSucursal);
        }

        public Task<CommonResult<SucursalxcodcliListModel>> Sucursal_XCodClienteCons(string CodCliente)
        {
            return _clienteRepository.Sucursal_XCodClienteCons(CodCliente);
        }


    }
}
