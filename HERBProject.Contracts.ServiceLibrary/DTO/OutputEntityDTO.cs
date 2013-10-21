using System;
using System.Text;
using System.Runtime.Serialization;

namespace HERBProject.Contracts.ServiceLibrary.DTO
{
    public class OutputEntityDTO
    {
        #region .: variables :.

        protected string _entityDTOVariable;

        #endregion


        #region .: constructors :.

        public OutputEntityDTO()
        {
            _entityDTOVariable = string.Empty;
        }

        public OutputEntityDTO(string outputEntityParam)
        {
            _entityDTOVariable = outputEntityParam;
        }

        #endregion


        #region .: properties :.

        public string OutputEntityDTOProperty
        {
            get { return _entityDTOVariable; }
            protected set { _entityDTOVariable = value; }
        }

        #endregion


        #region .: methods :.

        public void EntityDTOMethod()
        {

        }

        #endregion
    }
}
