using System;
using TenedorYPalillos.Model.Contract;


namespace TenedorYPalillos.Model.DTO
{

    public abstract class BaseRequest
    {

        private string _proceso;


        protected BaseRequest()
        {
            Proceso = "BASE_ACTION_UNDEFINED";
        }


        private string Proceso { get => _proceso; set => _proceso = value; }





        public void DefineAccion(string proceso)
        {
            Proceso = proceso;
        }

        public string TraeAccion()
        {
            return Proceso;
        }

    }
}
