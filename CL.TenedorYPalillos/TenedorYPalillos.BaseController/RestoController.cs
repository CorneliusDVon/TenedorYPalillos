using Microsoft.EntityFrameworkCore;
using TenedorYPalillos.Model.DTO.Resto;
using TenedorYPalillos.Model.DAO.RestoEntity;
using TenedorYPalillos.Connection.Context;
using MediatR;


namespace TenedorYPalillos.BaseController
{


    public class RestoController : IRequestHandler<RestoRequestDTO, List<RestoResponseDTO>>
    {


        private List<RestoResponseDTO> _restoDTOList;
        private readonly TenedorYPalillosContext _restoContext;


        public RestoController(TenedorYPalillosContext restoContext)
        {
            RestoDTOList = new List<RestoResponseDTO>();
            _restoContext = restoContext;
        }


        private List<RestoResponseDTO> RestoDTOList { get => _restoDTOList; set => _restoDTOList = value; }





        public async Task<List<RestoResponseDTO>> Handle(RestoRequestDTO request, CancellationToken cancellationToken)
        {

            string proceso = request.TraeAccion();

            return proceso switch
            {
                "CARGA_RESTO" => await CargaTodoResto(request),
                "CARGA_RESTO_ID" => await CargaRestoPorID(request),
                "ACTUALIZA_RESTO_ID" => await ActualizaRestoPorID(request),
                "ELIMINA_RESTO_ID" => await EliminaRestoPorID(request),
                "CREA_RESTO" => await CreaResto(request),
                _ => throw new Exception("No se ha especificado una funcion a la operacion solicitada."),
            };

        }





        private async Task<List<RestoResponseDTO>> CargaTodoResto(RestoRequestDTO request)
        {

            try
            {

                _restoContext.RutSociedad = request.Sociedad.Trim();

                //IQueryable<RestoDAO> resto = db.Resto.AsNoTracking();
                List<Resto> resto = await
                    _restoContext.Resto.
                    Include(rtr => rtr.Resto_Tipo_Resto).
                    ThenInclude(tr => tr.Tipo_Resto).AsNoTracking().ToListAsync();


                foreach (Resto restos in resto)
                {

                    RestoResponseDTO response = new RestoResponseDTO();

                    response.ID = restos.ID;
                    response.Nombre = restos.Nombre;
                    response.Descripcion = restos.Descripcion;
                    response.TipoResto = new List<TipoRestoResponseDTO>();

                    foreach (Resto_Tipo_Resto restoTipoResto in restos.Resto_Tipo_Resto)
                    {
                        TipoRestoResponseDTO restoTipoRestoDTO = new TipoRestoResponseDTO()
                        {
                            ID = restoTipoResto.Tipo_Resto.ID,
                            Nombre = restoTipoResto.Tipo_Resto.Nombre
                        };

                        response.TipoResto.Add(restoTipoRestoDTO);

                    }

                    RestoDTOList.Add(response);

                }

            }
            catch (Exception ex)
            {
                int stop = 0;
                //Log.Error("Msg:[Ha ocurrido un error al intentar manipular los datos] Det:[" + ex.Message + "]", rutSociedad);
            }

            return RestoDTOList;

        }


        private async Task<List<RestoResponseDTO>> CargaRestoPorID(RestoRequestDTO request)
        {

            try
            {

                _restoContext.RutSociedad = request.Sociedad.Trim();

                //IQueryable<RestoDAO> resto = db.Resto.AsNoTracking();
                List<Resto> resto = await
                    _restoContext.Resto.
                    Include(rtr => rtr.Resto_Tipo_Resto).
                    ThenInclude(tr => tr.Tipo_Resto).
                    Where(r => r.ID == request.ID).AsNoTracking().ToListAsync();


                foreach (Resto restos in resto)
                {

                    RestoResponseDTO oResto = new RestoResponseDTO();

                    oResto.ID = restos.ID;
                    oResto.Nombre = restos.Nombre;
                    oResto.Descripcion = restos.Descripcion;
                    oResto.TipoResto = new List<TipoRestoResponseDTO>();

                    foreach (Resto_Tipo_Resto restoTipoResto in restos.Resto_Tipo_Resto)
                    {
                        TipoRestoResponseDTO restoTipoRestoDTO = new TipoRestoResponseDTO()
                        {
                            ID = restoTipoResto.Tipo_Resto.ID,
                            Nombre = restoTipoResto.Tipo_Resto.Nombre
                        };

                        oResto.TipoResto.Add(restoTipoRestoDTO);

                    }

                    RestoDTOList.Add(oResto);

                }
            }
            catch (Exception ex)
            {
                //Log.Error("Msg:[Ha ocurrido un error al intentar manipular los datos] Det:[" + ex.Message + "]", rutSociedad);
            }

            return RestoDTOList;

        }


        private async Task<List<RestoResponseDTO>> ActualizaRestoPorID(RestoRequestDTO request)
        {

            int retorno = 0;

            try
            {

                _restoContext.RutSociedad = request.Sociedad.Trim();

                //IQueryable<RestoDAO> resto = db.Resto.AsNoTracking();
                List<Resto> resto = await
                    _restoContext.Resto.
                    Include(rtr => rtr.Resto_Tipo_Resto).
                    ThenInclude(tr => tr.Tipo_Resto).
                    Where(r => r.ID == request.ID).AsNoTracking().ToListAsync();


                foreach (Resto restos in resto)
                {

                    restos.Nombre = request.Nombre ?? restos.Nombre;
                    restos.Descripcion = request.Descripcion ?? restos.Descripcion;

                    _restoContext.Resto.UpdateRange(restos);
                    retorno = await _restoContext.SaveChangesAsync();


                    if (retorno > 0)
                    {

                        //IQueryable<RestoDAO> resto = db.Resto.AsNoTracking();
                        resto = await
                            _restoContext.Resto.
                            Include(rtr => rtr.Resto_Tipo_Resto).
                            ThenInclude(tr => tr.Tipo_Resto).
                            Where(r => r.ID == request.ID).AsNoTracking().ToListAsync();


                        foreach (Resto restoResponse in resto)
                        {

                            RestoResponseDTO oResto = new RestoResponseDTO();

                            oResto.ID = restoResponse.ID;
                            oResto.Nombre = restoResponse.Nombre;
                            oResto.Descripcion = restoResponse.Descripcion;
                            oResto.TipoResto = new List<TipoRestoResponseDTO>();

                            foreach (Resto_Tipo_Resto restoTipoResto in restoResponse.Resto_Tipo_Resto)
                            {
                                TipoRestoResponseDTO restoTipoRestoDTO = new TipoRestoResponseDTO()
                                {
                                    ID = restoTipoResto.Tipo_Resto.ID,
                                    Nombre = restoTipoResto.Tipo_Resto.Nombre
                                };

                                oResto.TipoResto.Add(restoTipoRestoDTO);

                            }

                            RestoDTOList.Add(oResto);

                        }
                    }
                    else
                    {
                        throw new Exception("No se ha podido modificar el Restaurant.");
                    }
                }
            }
            catch (Exception ex)
            {
                //Log.Error("Msg:[Ha ocurrido un error al intentar manipular los datos] Det:[" + ex.Message + "]", rutSociedad);
            }

            return RestoDTOList;

        }


        private async Task<List<RestoResponseDTO>> EliminaRestoPorID(RestoRequestDTO request)
        {

            int retorno = 0;

            try
            {

                _restoContext.RutSociedad = request.Sociedad.Trim();

                //IQueryable<RestoDAO> resto = db.Resto.AsNoTracking();
                List<Resto> resto = await
                    _restoContext.Resto.
                    Include(rtr => rtr.Resto_Tipo_Resto).
                    ThenInclude(tr => tr.Tipo_Resto).
                    Where(r => r.ID == request.ID).AsNoTracking().ToListAsync();


                foreach (Resto restos in resto)
                {

                    restos.Nombre = request.Nombre ?? restos.Nombre;
                    restos.Descripcion = request.Descripcion ?? restos.Descripcion;

                    _restoContext.Resto.Remove(restos);
                    retorno = await _restoContext.SaveChangesAsync();


                    if (retorno > 0)
                    {

                        //IQueryable<RestoDAO> resto = db.Resto.AsNoTracking();
                        resto = await
                            _restoContext.Resto.
                            Include(rtr => rtr.Resto_Tipo_Resto).
                            ThenInclude(tr => tr.Tipo_Resto).
                            Where(r => r.ID == request.ID).AsNoTracking().ToListAsync();


                        foreach (Resto restoResponse in resto)
                        {

                            RestoResponseDTO oResto = new RestoResponseDTO();

                            oResto.ID = restoResponse.ID;
                            oResto.Nombre = restoResponse.Nombre;
                            oResto.Descripcion = restoResponse.Descripcion;
                            oResto.TipoResto = new List<TipoRestoResponseDTO>();

                            foreach (Resto_Tipo_Resto restoTipoResto in restoResponse.Resto_Tipo_Resto)
                            {
                                TipoRestoResponseDTO restoTipoRestoDTO = new TipoRestoResponseDTO()
                                {
                                    ID = restoTipoResto.Tipo_Resto.ID,
                                    Nombre = restoTipoResto.Tipo_Resto.Nombre
                                };

                                oResto.TipoResto.Add(restoTipoRestoDTO);

                            }

                            RestoDTOList.Add(oResto);

                        }
                    }
                    else
                    {
                        throw new Exception("No se ha podido Eliminar el Restaurant.");
                    }
                }
            }
            catch (Exception ex)
            {
                //Log.Error("Msg:[Ha ocurrido un error al intentar manipular los datos] Det:[" + ex.Message + "]", rutSociedad);
            }

            return RestoDTOList;

        }


        private async Task<List<RestoResponseDTO>> CreaResto(RestoRequestDTO request)
        {

            int retorno = 0;

            try
            {



                _restoContext.RutSociedad = request.Sociedad.Trim();

                Resto resto = new Resto();
                resto.Nombre = request.Nombre;
                resto.Descripcion = request.Descripcion;

                _restoContext.Resto.Add(resto);
                retorno = await _restoContext.SaveChangesAsync();


                if (retorno > 0)
                {

                    //IQueryable<RestoDAO> resto = db.Resto.AsNoTracking();
                    List<Resto> restos = await
                    _restoContext.Resto.
                    Include(rtr => rtr.Resto_Tipo_Resto).
                    ThenInclude(tr => tr.Tipo_Resto).AsNoTracking().ToListAsync();


                    foreach (Resto restoResponse in restos)
                    {

                        RestoResponseDTO oResto = new RestoResponseDTO();

                        oResto.ID = restoResponse.ID;
                        oResto.Nombre = restoResponse.Nombre;
                        oResto.Descripcion = restoResponse.Descripcion;
                        oResto.TipoResto = new List<TipoRestoResponseDTO>();

                        foreach (Resto_Tipo_Resto restoTipoResto in restoResponse.Resto_Tipo_Resto)
                        {
                            TipoRestoResponseDTO restoTipoRestoDTO = new TipoRestoResponseDTO()
                            {
                                ID = restoTipoResto.Tipo_Resto.ID,
                                Nombre = restoTipoResto.Tipo_Resto.Nombre
                            };

                            oResto.TipoResto.Add(restoTipoRestoDTO);

                        }

                        RestoDTOList.Add(oResto);

                    }
                }
                else
                {
                    throw new Exception("No se ha podido Crear el nuevo Restaurant.");
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
