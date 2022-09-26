using Microsoft.EntityFrameworkCore;
using TenedorYPalillos.Model.DTO.Resto;
using TenedorYPalillos.Model.DAO.RestoEntity;
using TenedorYPalillos.Connection.Context;
using MediatR;


namespace TenedorYPalillos.BaseController
{


    public class RestoController : IRequestHandler<RestoDTORequest>
    {


        private List<RestoDTOResponse> _restoDTOList;
        private readonly TenedorYPalillosContext _restoContext;



        public RestoController()
        {
            RestoDTOList = new List<RestoDTOResponse>();
        }

        public RestoController(TenedorYPalillosContext restoContext)
        {
            _restoContext = restoContext;
        }



        private List<RestoDTOResponse> RestoDTOList { get => _restoDTOList; set => _restoDTOList = value; }





        public async Task<List<RestoDTOResponse>> CargaTodoResto(RestoDTORequest request)
        {

            try
            {

                using (TenedorYPalillosContext db = new TenedorYPalillosContext())
                {

                    db.RutSociedad = request.Sociedad.Trim();

                    //IQueryable<RestoDAO> resto = db.Resto.AsNoTracking();
                    List<Resto> resto = await
                        db.Resto.
                        Include(rtr => rtr.Resto_Tipo_Resto).
                        ThenInclude(tr => tr.Tipo_Resto).AsNoTracking().ToListAsync();


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
                int stop = 0;
                //Log.Error("Msg:[Ha ocurrido un error al intentar manipular los datos] Det:[" + ex.Message + "]", rutSociedad);
            }

            return RestoDTOList;

        }


        public async Task<List<RestoDTOResponse>> CargaRestoPorID(RestoDTORequest request)
        {

            try
            {

                using (TenedorYPalillosContext db = new TenedorYPalillosContext())
                {

                    db.RutSociedad = request.Sociedad.Trim();

                    //IQueryable<RestoDAO> resto = db.Resto.AsNoTracking();
                    List<Resto> resto = await
                        db.Resto.
                        Include(rtr => rtr.Resto_Tipo_Resto).
                        ThenInclude(tr => tr.Tipo_Resto).
                        Where(r => r.ID == request.ID).AsNoTracking().ToListAsync();


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


        public async Task<List<RestoDTOResponse>> ActualizaRestoPorID(RestoDTORequest request)
        {

            int retorno = 0;

            try
            {

                using (TenedorYPalillosContext db = new TenedorYPalillosContext())
                {

                    db.RutSociedad = request.Sociedad.Trim();

                    //IQueryable<RestoDAO> resto = db.Resto.AsNoTracking();
                    List<Resto> resto = await
                        db.Resto.
                        Include(rtr => rtr.Resto_Tipo_Resto).
                        ThenInclude(tr => tr.Tipo_Resto).
                        Where(r => r.ID == request.ID).AsNoTracking().ToListAsync();


                    foreach (Resto restos in resto)
                    {

                        restos.Nombre = request.Nombre ?? restos.Nombre;
                        restos.Descripcion = request.Descripcion ?? restos.Descripcion;

                        db.Resto.UpdateRange(restos);
                        retorno = await db.SaveChangesAsync();


                        if (retorno > 0)
                        {

                            //IQueryable<RestoDAO> resto = db.Resto.AsNoTracking();
                            resto = await
                                db.Resto.
                                Include(rtr => rtr.Resto_Tipo_Resto).
                                ThenInclude(tr => tr.Tipo_Resto).
                                Where(r => r.ID == request.ID).AsNoTracking().ToListAsync();


                            foreach (Resto restoResponse in resto)
                            {

                                RestoDTOResponse oResto = new RestoDTOResponse();

                                oResto.ID = restoResponse.ID;
                                oResto.Nombre = restoResponse.Nombre;
                                oResto.Descripcion = restoResponse.Descripcion;
                                oResto.TipoResto = new List<TipoRestoDTOResponse>();

                                foreach (Resto_Tipo_Resto restoTipoResto in restoResponse.Resto_Tipo_Resto)
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
                        else
                        {
                            throw new Exception("No se ha podido modificar el Restaurant.");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //Log.Error("Msg:[Ha ocurrido un error al intentar manipular los datos] Det:[" + ex.Message + "]", rutSociedad);
            }

            return RestoDTOList;

        }


        public async Task<List<RestoDTOResponse>> EliminaRestoPorID(RestoDTORequest request)
        {

            int retorno = 0;

            try
            {

                using (TenedorYPalillosContext db = new TenedorYPalillosContext())
                {

                    db.RutSociedad = request.Sociedad.Trim();

                    //IQueryable<RestoDAO> resto = db.Resto.AsNoTracking();
                    List<Resto> resto = await
                        db.Resto.
                        Include(rtr => rtr.Resto_Tipo_Resto).
                        ThenInclude(tr => tr.Tipo_Resto).
                        Where(r => r.ID == request.ID).AsNoTracking().ToListAsync();


                    foreach (Resto restos in resto)
                    {

                        restos.Nombre = request.Nombre ?? restos.Nombre;
                        restos.Descripcion = request.Descripcion ?? restos.Descripcion;

                        db.Resto.Remove(restos);
                        retorno = await db.SaveChangesAsync();


                        if (retorno > 0)
                        {

                            //IQueryable<RestoDAO> resto = db.Resto.AsNoTracking();
                            resto = await
                                db.Resto.
                                Include(rtr => rtr.Resto_Tipo_Resto).
                                ThenInclude(tr => tr.Tipo_Resto).
                                Where(r => r.ID == request.ID).AsNoTracking().ToListAsync();


                            foreach (Resto restoResponse in resto)
                            {

                                RestoDTOResponse oResto = new RestoDTOResponse();

                                oResto.ID = restoResponse.ID;
                                oResto.Nombre = restoResponse.Nombre;
                                oResto.Descripcion = restoResponse.Descripcion;
                                oResto.TipoResto = new List<TipoRestoDTOResponse>();

                                foreach (Resto_Tipo_Resto restoTipoResto in restoResponse.Resto_Tipo_Resto)
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
                        else
                        {
                            throw new Exception("No se ha podido Eliminar el Restaurant.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Log.Error("Msg:[Ha ocurrido un error al intentar manipular los datos] Det:[" + ex.Message + "]", rutSociedad);
            }

            return RestoDTOList;

        }


        public async Task<List<RestoDTOResponse>> CreaResto(RestoDTORequest request)
        {

            int retorno = 0;

            try
            {

                using (TenedorYPalillosContext db = new TenedorYPalillosContext())
                {


                    db.RutSociedad = request.Sociedad.Trim();

                    Resto resto = new Resto();
                    resto.Nombre = request.Nombre;
                    resto.Descripcion = request.Descripcion;

                    db.Resto.Add(resto);
                    retorno = await db.SaveChangesAsync();


                    if (retorno > 0)
                    {

                        //IQueryable<RestoDAO> resto = db.Resto.AsNoTracking();
                        List<Resto> restos = await
                        db.Resto.
                        Include(rtr => rtr.Resto_Tipo_Resto).
                        ThenInclude(tr => tr.Tipo_Resto).AsNoTracking().ToListAsync();


                        foreach (Resto restoResponse in restos)
                        {

                            RestoDTOResponse oResto = new RestoDTOResponse();

                            oResto.ID = restoResponse.ID;
                            oResto.Nombre = restoResponse.Nombre;
                            oResto.Descripcion = restoResponse.Descripcion;
                            oResto.TipoResto = new List<TipoRestoDTOResponse>();

                            foreach (Resto_Tipo_Resto restoTipoResto in restoResponse.Resto_Tipo_Resto)
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
                    else
                    {
                        throw new Exception("No se ha podido Crear el nuevo Restaurant.");
                    }

                }
            }
            catch (Exception ex)
            {
                //Log.Error("Msg:[Ha ocurrido un error al intentar manipular los datos] Det:[" + ex.Message + "]", rutSociedad);
            }

            return RestoDTOList;


        }





        public async Task<Unit> Handle(RestoDTORequest request, CancellationToken cancellationToken)
        {
            int retorno = 0;

            Resto resto = new Resto()
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion
            };

            _restoContext.Resto.Add(resto);
            retorno = await _restoContext.SaveChangesAsync();

            if (retorno > 0)
            {
                return Unit.Value;
            }
            else
            {
                throw new Exception("No se ha podido crear el nuevo Restaurant.");
            }
        }


    }
}
