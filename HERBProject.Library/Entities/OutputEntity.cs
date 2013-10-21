using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HERBProject.Library.Entities
{
    public class OutputEntity
    {

        #region .: variables :.

        protected string _entityVariable;

        #endregion


        #region .: constructors :.

        public OutputEntity()
        {
            _entityVariable = string.Empty;
        }

        public OutputEntity(string outputEntityParam)
        {
            _entityVariable = outputEntityParam;
        }

        #endregion


        #region .: properties

        public string OutEntityProperty
        {
            get { return _entityVariable; }
            protected set { _entityVariable = value; }
        }

        #endregion


        #region .: methods :.

        public void EntityMethod()
        {

        }

        #endregion

    }
}
