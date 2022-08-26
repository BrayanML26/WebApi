using ServiciosWeb.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiciosWeb.WebApi.Controllers
{
    public class ClienteController : ApiController
    {
        InventarioConnection BD = new InventarioConnection();

        /// <summary>
        /// Permite consultar la informacion de todos los clientes
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
        public IEnumerable<clientes> Get()
        {
            var listado = BD.clientes.ToList();
            return listado;
        }

        [HttpGet]
        public clientes Get(int id)
        {
            var cliente = BD.clientes.FirstOrDefault(x=> x.codcli == id);
            return cliente;
        }

        [HttpPost]
        public bool Post(clientes clientes)
        {
            BD.clientes.Add(clientes);
            return BD.SaveChanges() > 0;
        }

        [HttpPut]
        public bool Put(clientes clientes)
        {
            var clienteActualizar = BD.clientes.FirstOrDefault(x => x.codcli == clientes.codcli);
            clienteActualizar.nomcli = clientes.nomcli;
            clienteActualizar.email = clientes.email;
            clienteActualizar.direccion = clientes.direccion;
            clienteActualizar.status = clientes.status;

            return BD.SaveChanges() > 0;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            var clienteEliminar = BD.clientes.FirstOrDefault(x => x.codcli == id);
            BD.clientes.Remove(clienteEliminar);

            return BD.SaveChanges() > 0;
        }

    }
}
