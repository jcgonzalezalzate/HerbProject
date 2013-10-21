using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HERBProject.WebUI.Models
{
    public class OutputDataModel
    {

        #region .: variables :.

        protected string _outputDataModelVariable;

        #endregion


        #region .: constructors :.

        public OutputDataModel()
        {
            _outputDataModelVariable = string.Empty;
        }

        public OutputDataModel(string outputEntityParam)
        {
            _outputDataModelVariable = outputEntityParam;
        }

        #endregion


        #region .: properties

        public string OutputDataModelProperty
        {
            get { return _outputDataModelVariable; }
            protected set { _outputDataModelVariable = value; }
        }

        #endregion


        #region .: methods :.

        public void OutputDataModelMethod()
        {

        }

        #endregion

    }
}