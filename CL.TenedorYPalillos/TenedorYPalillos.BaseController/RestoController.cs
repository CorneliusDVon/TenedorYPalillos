using Microsoft.EntityFrameworkCore;
using TenedorYPalillos.Model.DTO.Resto;
using TenedorYPalillos.Model.DAO.RestoEntity;
using TenedorYPalillos.Connection.Context;

namespace LLegoCarta.Controller
{

    [Serializable]
    public class RestoController
    {

        private List<RestoDTOResponse> _restoDTOList;


        public RestoController()
        {
            RestoDTOList = new List<RestoDTOResponse>();
        }


        public List<RestoDTOResponse> RestoDTOList { get => _restoDTOList; set => _restoDTOList = value; }



        public List<RestoDTOResponse> CargaTodoResto(RestoDTORequest request)
        {

            try
            {

                RestoDTOList = new List<RestoDTOResponse>();

                using (RestoContext db = new RestoContext())
                {

                    db.RutSociedad = request.Sociedad.Trim();

                    //IQueryable<RestoDAO> resto = db.Resto.AsNoTracking();
                    IQueryable<Resto> resto =
                        db.Resto.
                        Include(rtr => rtr.Resto_Tipo_Resto).
                        ThenInclude(tr => tr.Tipo_Resto).AsNoTracking();


                    foreach (Resto restos in resto)
                    {

                        RestoDTOResponse response = new RestoDTOResponse();

                        response.ID = restos.ID;
                        response.Nombre = restos.Nombre;
                        response.Descripcion = restos.Descripcion;
                        response.TipoResto = new List<TipoRestoDTOResponse>();

                        foreach (Resto_Tipo_Resto restoTipoResto in restos.Resto_Tipo_Resto)
                        {
                            TipoRestoDTOResponse restoTipoRestoDTO = new TipoRestoDTOResponse()
                            {
                                ID = restoTipoResto.Tipo_Resto.ID,
                                Nombre = restoTipoResto.Tipo_Resto.Nombre
                            };

                            response.TipoResto.Add(restoTipoRestoDTO);

                        }

                        RestoDTOList.Add(response);

                    }
                }
            }
            catch (Exception ex)
            {
                //Log.Error("Msg:[Ha ocurrido un error al intentar manipular los datos] Det:[" + ex.Message + "]", rutSociedad);
            }

            return RestoDTOList;

        }


        public List<RestoDTOResponse> CargaRestoPorID(RestoDTORequest request)
        {

            try
            {

                RestoDTOList = new List<RestoDTOResponse>();

                using (RestoContext db = new RestoContext())
                {

                    db.RutSociedad = request.Sociedad.Trim();

                    //IQueryable<RestoDAO> resto = db.Resto.AsNoTracking();
                    IQueryable<Resto> resto =
                        db.Resto.
                        Include(rtr => rtr.Resto_Tipo_Resto).
                        ThenInclude(tr => tr.Tipo_Resto).
                        Where(r => r.ID == request.ID).AsNoTracking();


                    foreach (Resto restos in resto)
                    {

                        RestoDTOResponse oResto = new RestoDTOResponse();

                        oResto.ID = restos.ID;
                        oResto.Nombre = restos.Nombre;
                        oResto.Descripcion = restos.Descripcion;
                        oResto.TipoResto = new List<TipoRestoDTOResponse>();

                        foreach (Resto_Tipo_Resto restoTipoResto in restos.Resto_Tipo_Resto)
                        {
                            TipoRestoDTOResponse restoTipoRestoDTO = new TipoRestoDTOResponse()
                            {
                                ID = restoTipoResto.Tipo_Resto.ID,
                                Nombre = restoTipoResto.Tipo_Resto.Nombre
                            };

                            oResto.TipoResto.Add(restoTipoRestoDTO);

                        }

                        RestoDTOList.Add(oResto);

                    }
                }
            }
            catch (Exception ex)
            {
                //Log.Error("Msg:[Ha ocurrido un error al intentar manipular los datos] Det:[" + ex.Message + "]", rutSociedad);
            }

            return RestoDTOList;


        }



    }
}
