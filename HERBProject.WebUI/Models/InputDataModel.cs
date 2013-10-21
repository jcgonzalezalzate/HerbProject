using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HERBProject.WebUI.Models
{
    public class InputDataModel
    {

        #region .: variables :.

        protected string _inputDataModelVariable;

        #endregion


        #region .: constructors :.

        public InputDataModel()
        {
            _inputDataModelVariable = string.Empty;
        }

        public InputDataModel(string inputEntityParam)
        {
            _inputDataModelVariable = inputEntityParam;
        }

        #endregion


        #region .: properties

        public string InputDataModelProperty
        {
            get { return _inputDataModelVariable; }
            protected set { _inputDataModelVariable = value; }
        }

        #endregion


        #region .: methods :.

        public void InputDataModelMethod()
        {

        }

        #endregion

    }
}