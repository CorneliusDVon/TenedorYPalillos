using Microsoft.EntityFrameworkCore;
using TenedorYPalillos.Model.DTO.Resto;
using TenedorYPalillos.Model.DAO.Resto;
using TenedorYPalillosDBContext;


namespace LLegoCarta.Controller
{

    [Serializable]
    public class TenedorYPalillosController
    {

        private List<RestoDTO> _restoDTOList;


        public TenedorYPalillosController()
        {
            RestoDTOList = new List<RestoDTO>();
        }


        public List<RestoDTO> RestoDTOList { get => _restoDTOList; set => _restoDTOList = value; }



        public void CargaTodoResto(string rutSociedad)
        {

            try
            {

                RestoDTOList = new List<RestoDTO>();

                using (TenedorYPalillosContext db = new TenedorYPalillosContext())
                {

                    db.RutSociedad = rutSociedad;

                    //IQueryable<RestoDAO> resto = db.Resto.AsNoTracking();
                    IQueryable<Resto> resto = 
                        db.Resto.
                        Include(rtr => rtr.Resto_Tipo_Resto).
                        ThenInclude(tr => tr.Tipo_Resto).AsNoTracking();


                    foreach (Resto restos in resto)
                    {

                        RestoDTO oResto = new RestoDTO();

                        oResto.ID = restos.ID;
                        oResto.Nombre = restos.Nombre;
                        oResto.Descripcion = restos.Descripcion;
                        oResto.Resto_Tipo_Resto = new List<RestoTipoRestoDTO>();

                        foreach (Resto_Tipo_Resto restoTipoResto in restos.Resto_Tipo_Resto)
                        {
                            RestoTipoRestoDTO restoTipoRestoDTO = new RestoTipoRestoDTO()
                            {
                                ID_Resto = restoTipoResto.ID_Resto,
                                ID_Tipo_Resto = restoTipoResto.ID_Resto,
                                Tipo_Resto = new TipoRestoDTO()
                                {
                                    ID = restoTipoResto.Tipo_Resto.ID,
                                    Nombre = restoTipoResto.Tipo_Resto.Nombre
                                }
                            };

                            oResto.Resto_Tipo_Resto.Add(restoTipoRestoDTO);

                        }

                        RestoDTOList.Add(oResto);

                    }
                }
            }
            catch (Exception ex)
            {
                //Log.Error("Msg:[Ha ocurrido un error al intentar manipular los datos] Det:[" + ex.Message + "]", rutSociedad);
            }

        }


        public void CargaRestoPorID(string rutSociedad, int idResto)
        {

            try
            {

                RestoDTOList = new List<RestoDTO>();

                using (TenedorYPalillosContext db = new TenedorYPalillosContext())
                {

                    db.RutSociedad = rutSociedad;

                    //IQueryable<RestoDAO> resto = db.Resto.AsNoTracking();
                    IQueryable<Resto> resto = 
                        db.Resto.
                        Include(rtr => rtr.Resto_Tipo_Resto).
                        ThenInclude(tr => tr.Tipo_Resto).
                        Where(r => r.ID == idResto).AsNoTracking();


                    foreach (Resto restos in resto)
                    {

                        RestoDTO oResto = new RestoDTO();

                        oResto.ID = restos.ID;
                        oResto.Nombre = restos.Nombre;
                        oResto.Descripcion = restos.Descripcion;
                        oResto.Resto_Tipo_Resto = new List<RestoTipoRestoDTO>();

                        foreach (Resto_Tipo_Resto restoTipoResto in restos.Resto_Tipo_Resto)
                        {
                            RestoTipoRestoDTO restoTipoRestoDTO = new RestoTipoRestoDTO()
                            {
                                ID_Resto = restoTipoResto.ID_Resto,
                                ID_Tipo_Resto = restoTipoResto.ID_Resto,
                                Tipo_Resto = new TipoRestoDTO()
                                {
                                    ID = restoTipoResto.Tipo_Resto.ID,
                                    Nombre = restoTipoResto.Tipo_Resto.Nombre
                                }
                            };

                            oResto.Resto_Tipo_Resto.Add(restoTipoRestoDTO);

                        }

                        RestoDTOList.Add(oResto);

                    }
                }
            }
            catch (Exception ex)
            {
                //Log.Error("Msg:[Ha ocurrido un error al intentar manipular los datos] Det:[" + ex.Message + "]", rutSociedad);
            }

        }



    }
}
