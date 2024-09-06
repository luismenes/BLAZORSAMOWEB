using BlazorServer.Business.Interfaces.Contratacion;
using BlazorServer.DataAccess.Context;
using BlazorServer.DataAccess.Models;
using BlazorServer.DTO.Request.Contratacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.Business.BLL.Contratacion
{
    public class ConveniosSAM : IConveniosSAM
    {
        private readonly SamoContext _samoContext;

        public ConveniosSAM()
        {
            //_samoContext = new SamoContext();
        }
        public async Task<bool> SaveManagement(ConvenioDTO Register)
        {
            try
            {
                using (SamoContext db = new SamoContext())
                {
                    Convenio oRegister = new Convenio()
                    {
                        Codigo = Register.Codigo,
                        Nombre = Register.Nombre,
                        ClaseId = Register.ClaseId,
                        EntidadId = Register.EntidadId,
                        CodigoEapb = Register.CodigoEapb,
                        TipoConvenioId = Register.TipoConvenioId,
                        OrigenConvenioId = Register.OrigenConvenioId,
                        TipoUserRegimen = Register.TipoUserRegimen,
                        PoblacionAtiende = Register.PoblacionAtiende,
                        FechaInicio = Register.FechaInicio,
                        FechaFin = Register.FechaFin,
                        FechaPrestaInicio = Register.FechaPrestaInicio,
                        FechaPrestaFin = Register.FechaPrestaFin,
                        EsTodaSede = Register.EsTodaSede,
                        EsConBeneficiarios = Register.EsConBeneficiarios,
                        EsJustNoPos = Register.EsJustNoPos,
                        UsuarioId = Register.UsuarioId,
                        OperacionId = Register.OperacionId,
                        FechaCreacion = DateTime.Now,
                        Activo = true
                    };

                    db.Convenios.Add(oRegister);
                    await db.SaveChangesAsync();

                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
